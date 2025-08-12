using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;

namespace CipherSink.Models.Database.Entities;

public class LocalPlayer : BasePlayer
{
    public LocalPlayer()
    {
        RsaObject = RSA.Create(2048);
        PublicKeyBytes = RsaObject.ExportRSAPublicKey();
        EncryptedPrivateKeyBytes = RsaObject.ExportRSAPrivateKey();
    }

    // Store private key securely (e.g., encrypted, or use DPAPI)
    [Required]
    public byte[] EncryptedPrivateKeyBytes { get; set; }

    public int Wins { get; private set; } = 0;

    public int IncrementWins()
    {
        return Wins++;
    }

    public int Losses { get; private set; } = 0;

    public int IncrementLosses()
    {
        return Losses++;
    }

    public int Hits { get; private set; } = 0;

    public int AddMisses(int numMisses)
    {
        return Hits += numMisses;
    }

    public int Misses { get; private set; } = 0;

    public int AddHits(int numMisses)
    {
        return Misses += numMisses;
    }

    public int SunkShips { get; private set; } = 0;
    
    public int AddSunkShips(int numSunkShips)
    {
        return SunkShips += numSunkShips;
    }


    [NotMapped]
    public RSA? RsaObject { get; set; } // Not stored in DB
}
