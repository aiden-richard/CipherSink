using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;

namespace CipherSink.Models;

public class LocalUser
{
    public int Id { get; set; }
    [Required]
    public string Username { get; set; } = string.Empty;

    // Store private key securely (e.g., encrypted, or use DPAPI)
    [Required]
    public string EncryptedPrivateKey { get; set; } = string.Empty;
    [Required]
    public string PublicKey { get; set; } = string.Empty;

    public int Wins { get; set; }
    public int Losses { get; set; }
    public int Hits { get; set; }
    public int Misses { get; set; }
    public int SunkShips { get; set; }

    [NotMapped]
    public RSA? RsaObject { get; set; } // Not stored in DB
}
