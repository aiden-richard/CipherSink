using CipherSink.Models.Cryptography.MerkleTree;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;

namespace CipherSink.Models.Database.Entities;

public class RemotePlayer : BasePlayer
{
    public RemotePlayer()
    {
        RsaObject = RSA.Create();
    }

    [Required]
    public bool IsFriend { get; set; }

    [NotMapped]
    public MerkleValidator? MerkleValidator { get; set; }

    public bool importPublicKey(byte[] publicKeyBytes) 
    { 
        try 
        {
            RsaObject.ImportRSAPublicKey(publicKeyBytes, out _);
            PublicKeyBytes = RsaObject.ExportRSAPublicKey();
            return true;
        }
        catch
        {
            return false;
        }
    }
}
