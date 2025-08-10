using System.Security.Cryptography;

namespace CipherSink.Models.Cryptography;

internal class Helpers
{
    public static bool VerifySignature(byte[] data, byte[] signature, byte[] publicKey)
    {
        using RSA rsa = RSA.Create();
        rsa.ImportRSAPublicKey(publicKey, out _);

        return rsa.VerifyData(data, signature, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
    }
}