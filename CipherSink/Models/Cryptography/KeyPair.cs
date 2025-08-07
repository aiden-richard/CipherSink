namespace CipherSink.Models.Cryptography;

/// <summary>
/// Represents a cryptographic key pair consisting of a public and a private key
/// </summary>
internal class KeyPair
{
    /// <summary>
    /// Gets or sets the unique identifier for this key pair.
    /// </summary>
    /// <value>The unique identifier for the key pair.</value>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the public key component of the cryptographic key pair.
    /// The public key can be shared with other players for identity verification and encryption purposes.
    /// </summary>
    /// <value>A byte array containing the public key data. Defaults to an empty array.</value>
    public byte[] PublicKey { get; set; } = Array.Empty<byte>();

    /// <summary>
    /// Gets or sets the private key component of the cryptographic key pair.
    /// The private key must be kept secure and is used for decryption and digital signing.
    /// </summary>
    /// <value>A byte array containing the private key data. Defaults to an empty array.</value>
    public byte[] PrivateKey { get; set; } = Array.Empty<byte>();

    /// <summary>
    /// Initializes a new instance of the <see cref="KeyPair"/> class with the specified public and private keys.
    /// </summary>
    /// <param name="publicKey">The public key component as a byte array.</param>
    /// <param name="privateKey">The private key component as a byte array.</param>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="publicKey"/> or <paramref name="privateKey"/> is null.</exception>
    public KeyPair(byte[] publicKey, byte[] privateKey)
    {
        PublicKey = publicKey ?? throw new ArgumentNullException(nameof(publicKey));
        PrivateKey = privateKey ?? throw new ArgumentNullException(nameof(privateKey));
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="KeyPair"/> class with empty key values.
    /// EF Core requires a parameterless constructor 
    /// </summary>
    public KeyPair() { }
}
