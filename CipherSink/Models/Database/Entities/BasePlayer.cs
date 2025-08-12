using System.ComponentModel.DataAnnotations;

namespace CipherSink.Models.Database.Entities;

public abstract class BasePlayer
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Username { get; set; } = string.Empty;

    /// <summary>
    /// The User's public key stored as a byte array.
    /// </summary>
    [Required]
    public required byte[] PublicKeyBytes { get; set; }
}
