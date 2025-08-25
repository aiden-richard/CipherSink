using System.Security.Cryptography;
using System.Text;

namespace CipherSink.Models.Cryptography.MerkleTree;

/// <summary>
/// This class provides functionality to validate a cell's data against a Merkle root hash using a proof path.
/// 
/// The Proof path is a list of hashes that, when combined in the right order with the hash of the cell data, produce the Merkle root.
/// </summary>
public class MerkleValidator
{
    public byte[] RootHash;

    public MerkleValidator(byte[] rootHash) 
    {
        RootHash = rootHash;
    }

    /// <summary>
    /// This method validates a cell's data against the Merkle root hash using the provided salt and proof path.
    /// This logic allows us to verify that a specific cell is part of the original grid without revealing the entire grid.
    /// 
    /// A proof path is a list of byte arrays that you
    /// </summary>
    /// <param name="cellDataString">A string representation of a cell in the grid. We validate this cell is from the grid that produced the merkle root.</param>
    /// <param name="salt">Byte array that stores the salt that we hash with the cellDataString to produce a leaf node in the merkle tree.</param>
    /// <param name="proofPath">List of MerkleProofElements that make up the proof path</param>
    /// <returns>True if cellDataString is a leaf node in the merkle tree that produced the root hash.</returns>
    /// <exception cref="ArgumentException">Invalid proof paths throw exception</exception>
    public bool Validate(string cellDataString, byte[] salt, List<MerkleProofElement> proofPath)
    {
        if (proofPath == null || proofPath.Count < 1)
        {
            throw new ArgumentException("Proof path cannot be null or empty.");
        }

        // Start by hashing the cell data with its salt
        var cellData = Encoding.UTF8.GetBytes(cellDataString);
        var saltedCellData = salt.Concat(cellData).ToArray();
        byte[] currentHash = SHA256.HashData(saltedCellData);

        var siblings = proofPath.ToList();
        while (siblings.Count > 0)
        {
            var sibling = siblings[0];
            siblings.RemoveAt(0);
            byte[] combined;
            if (sibling.IsLeft)
                combined = sibling.Hash.Concat(currentHash).ToArray();
            else
                combined = currentHash.Concat(sibling.Hash).ToArray();

            currentHash = SHA256.HashData(combined); // Hash the combined data
        }

        return currentHash.SequenceEqual(RootHash);
    }

}
