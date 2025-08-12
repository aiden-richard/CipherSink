using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;

namespace CipherSink.Models.Database.Entities;

public class LocalPlayer : BasePlayer
{
    // Store private key securely (e.g., encrypted, or use DPAPI)
    [Required]
    public required byte[] EncryptedPrivateKeyBytes { get; set; }

    public int Wins { get; private set; }

    public int IncrementWins()
    {
        return Wins++;
    }

    public int Losses { get; set; }

    public int IncrementLosses()
    {
        return Losses++;
    }

    public int Hits { get; private set; }

    public int AddMisses(int numHits)
    {
        return Hits += numHits;
    }

    public int Misses { get; private set; }

    public int AddHits(int numMisses)
    {
        return Misses += numMisses;
    }

    public int SunkShips { get; set; }
    
    public int AddSunkShips(int numSunkShips)
    {
        return SunkShips += numSunkShips;
    }


    [NotMapped]
    public RSA? RsaObject { get; set; } // Not stored in DB
}
