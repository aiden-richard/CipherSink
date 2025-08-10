using CipherSink.Models.Cryptography;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;

namespace CipherSink.Models.GameLogic;

/// <summary>
/// Represents a player in the CipherSink game, encapsulating their Id, Name, cryptographic credentials, and game state.
/// </summary>
internal class Player
{
    /// <summary>
    /// Gets or sets the unique identifier for this player in the database.
    /// This serves as the primary key for Entity Framework Core persistence.
    /// </summary>
    /// <value>The unique database identifier for the player.</value>
    [Key]
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the cryptographic key pair associated with this player.
    /// </summary>
    /// <value>The player's cryptographic key pair. This property is required and cannot be null.</value>
    public required string Name { get; set; }

    public RSA Rsa { get; set; } = RSA.Create();

    public byte[] PublicKey => Rsa.ExportRSAPublicKey();

    /// <summary>
    /// Gets or sets the game board currently associated with this player.
    /// </summary>
    /// <value>The player's game board instance. Defaults to a new <see cref="Gameboard"/> instance.</value>
    /// <seealso cref="Gameboard"/>
    public Gameboard GameBoard { get; set; } = new Gameboard();

    public Player(string name, RSA rsa)
    {
        Name = name;
        Rsa = rsa;
    }

    public Player() { }
}