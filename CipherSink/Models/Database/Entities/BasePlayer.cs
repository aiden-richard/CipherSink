using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;

namespace CipherSink.Models.Database.Entities;

public abstract class BasePlayer
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Username { get; set; }

    /// <summary>
    /// The User's public key stored as a byte array.
    /// </summary>
    [Required]
    public byte[] PublicKeyBytes { get; set; }

    [NotMapped]
    public RSA RsaObject { get; set; }

    [NotMapped]
    public Gameboard? GameBoard { get; set; }
}
