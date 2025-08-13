using Microsoft.VisualBasic.ApplicationServices;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;

namespace CipherSink.Models.Database.Entities;

public class LocalPlayer : BasePlayer
{
    public LocalPlayer(string username, string password)
    {
        Username = username;
        RsaObject = RSA.Create();
        PublicKeyBytes = RsaObject.ExportRSAPublicKey();
        EncryptedPrivateKeyBytes = RsaObject.ExportEncryptedPkcs8PrivateKey(
            password.ToCharArray(),
            new PbeParameters(
                PbeEncryptionAlgorithm.Aes256Cbc,
                HashAlgorithmName.SHA256, 600000)
        );
    }

    public LocalPlayer()
    {
        RsaObject = RSA.Create();

        if (PublicKeyBytes != null)
        {
            RsaObject.ImportRSAPublicKey(PublicKeyBytes, out _);
        }
    }

    public bool LoadPrivatekey(string password)
    {
        if (EncryptedPrivateKeyBytes != null && password != null)
        {
            try
            {
                RsaObject.ImportEncryptedPkcs8PrivateKey(
                    password: password.ToCharArray(),
                    source: EncryptedPrivateKeyBytes,
                    bytesRead: out _);
                return true;
            }
            catch
            {
                return false;
            }
        }

        return false;
    }

    // Store private key securely (e.g., encrypted, or use DPAPI)
    [Required]
    public byte[] EncryptedPrivateKeyBytes { get; set; }

    public int TotalWins { get; private set; } = 0;

    public int IncrementWins()
    {
        return TotalWins++;
    }

    public int TotalLosses { get; private set; } = 0;

    public int IncrementLosses()
    {
        return TotalLosses++;
    }

    public int TotalHits { get; private set; } = 0;

    public int AddHits(int numHits)
    {
        return TotalHits += numHits;
    }

    public int TotalMisses { get; private set; } = 0;

    public int AddMisses(int numMisses)
    {
        return TotalMisses += numMisses;
    }

    public int TotalSunkShips { get; private set; } = 0;
    
    public int AddSunkShips(int numSunkShips)
    {
        return TotalSunkShips += numSunkShips;
    }
}
