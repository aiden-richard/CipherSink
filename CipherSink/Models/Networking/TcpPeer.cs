using CipherSink.Models.Cryptography;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;

namespace CipherSink.Models.Networking;

public class TcpPeer : IDisposable
{
    private RSA Rsa;
    private byte[] PublicKey;
    private byte[]? PeerPublicKey;

    private Socket? Connection;
    public const int Port = 57575;
    public bool IsHost;
    public bool ConnectionVerified = false;

    public TcpPeer(RSA rsa)
    {
        Rsa = rsa;
        PublicKey = Rsa.ExportRSAPublicKey();
    }

    public async Task<bool> TryConnect(string host)
    {
        try
        {
            IsHost = false;
            IPEndPoint EndPoint = new(IPAddress.Parse(host), Port);
            Connection = new Socket(EndPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            await Connection.ConnectAsync(EndPoint);

            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public async Task<bool> TryAcceptConnection()
    {
        try
        {
            IsHost = true;
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

    private async Task SendMessage(byte[] message)
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
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    private async Task<byte[]> ReceiveMessage()
    {
        if (Connection == null)
        {
            throw new InvalidOperationException("No connection established");
        }

        byte[] lengthBytes = await ReadExact(4);
        int messageLength = BitConverter.ToInt32(lengthBytes, 0);

        return await ReadExact(messageLength);
    }

    private async Task<byte[]> ReadExact(int numBytes)
    {
        if (Connection == null)
        {
            throw new InvalidOperationException("No connection established");
        }

        byte[] buffer = new byte[numBytes];
        int bytesRead = 0;

        while (bytesRead < numBytes)
        {
            int received = await Connection.ReceiveAsync(new ArraySegment<byte>(buffer, bytesRead, numBytes - bytesRead), SocketFlags.None);
            if (received == 0)
            {
                throw new SocketException((int)SocketError.ConnectionReset);
            }
            bytesRead += received;
        }

        return buffer;
    }

    public async Task ExchangeKeys()
    {
        Task sendTask = SendPublicKey();
        Task receiveTask = ReceivePublicKey();

        await Task.WhenAll(sendTask, receiveTask);
    }

    private async Task SendPublicKey()
    {
        await SendMessage(PublicKey);
    }

    private async Task ReceivePublicKey()
    {
        PeerPublicKey = await ReceiveMessage();
    }

    public async Task<bool> ValidateConnection()
    {
        if (PeerPublicKey == null)
        {
            throw new InvalidOperationException("Peer public key not received");
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
        Console.WriteLine("Challenge sent to peer.");

        byte[] signature = await ReceiveMessage();

        return Helpers.VerifySignature(challenge, signature, PeerPublicKey);
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
    }
}