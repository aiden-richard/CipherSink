namespace CipherSink.Models.Cryptography.MerkleTree;

/// <summary>
/// This struct represents a single element in a Merkle proof.
/// </summary>
public struct MerkleProofElement
{
    public byte[] Hash { get; init; } // The hash for this element
    public bool IsLeft { get; init; } // We need to kknow if this hash is a left sibling or right sibling
                                      // This matters for the order of concatenation when computing the combined hash
    public MerkleProofElement(byte[] hash, bool isLeftSibling)
    {
        this.Hash = hash;
        IsLeft = isLeftSibling;
    }
}