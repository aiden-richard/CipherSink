using CipherSink.Models.Cryptography;
using CipherSink.Models.Database;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;

namespace CipherSink.Models.Networking;

public class TcpPeer : IDisposable
{
    // db context for storing player data
    private CipherSinkContext dbContext;

    // RSA instance for cryptographic operations
    private RSA Rsa;

    // byte arrays for public keys
    public byte[] PublicKeyBytes { get; private set; }
    public byte[]? PeerPublicKeyBytes { get; private set; }

    // Socket connection for TCP communication
    // Hard coded port number for the TCP connection
    private Socket? Connection;
    public const int Port = 57575;

    public bool IsHost { get; private init; }
    public string? HostIp { get; private set; } = null;
    public bool IsPrivateMatch { get; private set; }
    public bool ConnectionVerified { get; private set; } = false;

    public TcpPeer(RSA rsa, bool isPrivateMatch, string? hostIp)
    {
        IsPrivateMatch = isPrivateMatch;
        Rsa = rsa;
        PublicKeyBytes = Rsa.ExportRSAPublicKey();

        this.dbContext = new CipherSinkContext();
        this.dbContext.Database.EnsureCreated();

        if (hostIp != null)
        {
            HostIp = hostIp;
            IsHost = false; // If host IP is provided, this instance is not the host
        }
        else
        {
            IsHost = true; // If no host IP is provided, this instance is the host
        }
    }

    /// <summary>
    /// This is the method for a client peer to connect to a host peer.
    /// It will attempt to create a TCP connection to the host's IP address and port.
    /// This method should be called AFTER the server peer has been initialized and is ready to accept connections.
    /// </summary>
    /// <returns>true if connected; false otherwise</returns>
    public async Task<bool> TryConnect()
    {
        try
        {
            IPEndPoint EndPoint = new(IPAddress.Parse(HostIp), Port);
            Connection = new Socket(EndPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            await Connection.ConnectAsync(EndPoint);

            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    /// <summary>
    /// This is the method for a server peer to accept incoming connections.
    /// It will create a TCP listener on the specified port and wait for a client to connect.
    /// This method should be called before any client attempts to connect.
    /// </summary>
    /// <returns>True if connected, false otherwise</returns>
    public async Task<bool> TryAcceptConnection()
    {
        try
        {
            IPEndPoint EndPoint = new(IPAddress.Any, Port);
            Socket listener = new(EndPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            listener.Bind(EndPoint);
            listener.Listen(1);

            Connection = await listener.AcceptAsync();

            listener.Close();
            listener.Dispose();

            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    /// <summary>
    /// This method takes a byte array message and sends it over the established TCP connection.
    /// It first sends the length of the message as a 4-byte integer, followed by the actual message bytes.
    /// </summary>
    /// <param name="message">Byte array to send to the peer</param>
    /// <returns>true if message sent; false otherwise</returns>
    /// <exception cref="InvalidOperationException">Will throw exception if there is no connection established</exception>
    private async Task<bool> SendMessage(byte[] message)
    {
        if (Connection == null)
        {
            throw new InvalidOperationException("No connection established");
        }

        try
        {
            byte[] lengthBytes = BitConverter.GetBytes(message.Length);
            await Connection.SendAsync(new ArraySegment<byte>(lengthBytes), SocketFlags.None);
            await Connection.SendAsync(new ArraySegment<byte>(message), SocketFlags.None);

            return true;
        }
        catch
        {
            return false;
        }
    }

    /// <summary>
    /// This method receives a message from the peer over the established TCP connection.
    /// It will first read the length of the message as a 4-byte integer,
    /// then read the actual message bytes based on that length.
    /// </summary>
    /// <returns>The byte array received</returns>
    private async Task<byte[]> ReceiveMessage()
    {
        byte[] lengthBytes = await ReadExact(4);
        int messageLength = BitConverter.ToInt32(lengthBytes, 0);

        return await ReadExact(messageLength);
    }

    /// <summary>
    /// This method reads an exact number of bytes from the TCP connection.
    /// </summary>
    /// <param name="numBytes">The number of bytes to receive</param>
    /// <returns>The bytes that were read</returns>
    /// <exception cref="InvalidOperationException">Thrown when no connection is established</exception>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when numBytes is out of range (less than 0 bytes or more than one million)</exception>
    /// <exception cref="SocketException">Thrown when connection is reset or network error occurs</exception>
    private async Task<byte[]> ReadExact(int numBytes)
    {
        if (Connection == null)
        {
            throw new InvalidOperationException("No connection established");
        }

        if (numBytes < 0 || numBytes > 1_000_000)
        {
            throw new ArgumentOutOfRangeException(nameof(numBytes), "Number of bytes cannot be negative and cannot be more than one million (1 Megabyte)");
        }
        
        if (numBytes == 0)
        {
            return Array.Empty<byte>();
        }

        byte[] buffer = new byte[numBytes];
        int bytesRead = 0;

        while (bytesRead < numBytes)
        {
            try
            {
                int received = await Connection.ReceiveAsync(
                    new ArraySegment<byte>(buffer, bytesRead, numBytes - bytesRead), 
                    SocketFlags.None);
                    
                if (received == 0)
                {
                    throw new SocketException((int)SocketError.ConnectionReset);
                }
                
                bytesRead += received;
            }
            catch (SocketException)
            {
                throw;
            }
        }

        return buffer;
    }

    /// <summary>
    /// asynchronously exchanges public keys with the peer.
    /// </summary>
    /// <returns>A task that can be awaited</returns>
    public async Task ExchangeKeys()
    {
        Task sendTask = SendPublicKey();
        Task receiveTask = ReceivePublicKey();

        await Task.WhenAll(sendTask, receiveTask);
    }

    /// <summary>
    /// Sends public key to the peer.
    /// </summary>
    /// <returns></returns>
    private async Task SendPublicKey()
    {
        await SendMessage(PublicKeyBytes);
    }

    /// <summary>
    /// Receives the peer's public key.
    /// </summary>
    /// <returns></returns>
    private async Task ReceivePublicKey()
    {
        PeerPublicKeyBytes = await ReceiveMessage();
    }

    /// <summary>
    /// Validates the connection with the peer.
    /// First, it checks if the match is private and if the peer's public key is in the list of friends' public keys.
    /// Then, it performs a challenge-response handshake to verify the connection.
    /// The Host will validate the peer first, then respond to the peer's challenge.
    /// The Peer will respond to the Host's challenge first, then validate the Host's response.
    /// </summary>
    /// <returns>True if validated; false otherwise</returns>
    /// <exception cref="InvalidOperationException">Thrown if we don't have the peer's public key</exception>
    public async Task<bool> ValidateConnection()
    {
        if (PeerPublicKeyBytes == null)
        {
            throw new InvalidOperationException("Peer public key not received");
        }

        if (IsPrivateMatch)
        {
            var friendPlayers = await dbContext.RemotePlayers
            .Where(remotePlayer => remotePlayer.IsFriend == true)
            .Select(remotePlayer => remotePlayer.PublicKeyBytes)
            .ToListAsync();

            if (!friendPlayers.Contains(PeerPublicKeyBytes))
            {
                return false;
            }
        }


        bool isValid;

        if (IsHost)
        {
            // Host validates peer first, then responds to peer's challenge
            isValid = await SendChallenge();
            if (isValid)
            {
                await RespondToChallenge();
            }
        }
        else
        {
            await RespondToChallenge();
            isValid = await SendChallenge();
        }

        ConnectionVerified = isValid;
        return isValid;
    }

    private async Task<bool> SendChallenge()
    {
        byte[] challenge = new byte[32];
        using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(challenge);
        }

        await SendMessage(challenge);

        byte[] signature = await ReceiveMessage();

        return Helpers.VerifySignature(challenge, signature, PeerPublicKeyBytes);
    }

    private async Task RespondToChallenge()
    {
        byte[] challenge = await ReceiveMessage();

        byte[] signature = Rsa.SignData(challenge, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
        await SendMessage(signature);
    }

    public void Dispose()
    {
        Connection?.Close();
        Connection?.Dispose();
        Rsa.Dispose();
        GC.SuppressFinalize(this);
        dbContext.Dispose();
    }
}