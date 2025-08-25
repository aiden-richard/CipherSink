using System.Security.Cryptography;
using System.Text;

namespace CipherSink.Models.Cryptography.MerkleTree;

public class MerkleTreeNode
{
    public byte[]? Salt { get; init; } // Salt for leaf nodes

    public byte[] Hash { get; set; }

    public MerkleTreeNode? Left { get; set; } // Left child node (Null for leaf nodes)

    public MerkleTreeNode? Right { get; set; }  // Right child node (Null for leaf nodes)

    /// <summary>
    /// Constructor for non-leaf nodes
    /// </summary>
    /// <param name="left">Left node</param>
    /// <param name="right">Right node</param>
    public MerkleTreeNode(MerkleTreeNode left, MerkleTreeNode right)
    {
        Left = left;
        Right = right;
        Hash = SHA256.HashData(left.Hash.Concat(right.Hash).ToArray());
    }

    /// <summary>
    /// Constructor for leaf nodes
    /// Takes in the cell data, generates a random salt, and computes the hash of the salt concatenated with the cell data
    /// Stores both the salt and the hash
    /// </summary>
    /// <param name="cellData">Data to create hash from</param>
    public MerkleTreeNode(string cellData)
    {
        byte[] cellDataBytes = Encoding.UTF8.GetBytes(cellData);
        Salt = RandomNumberGenerator.GetBytes(16); // Generate a random salt for each leaf node
        Hash = SHA256.HashData(Salt.Concat(cellDataBytes).ToArray());
    }

    public bool IsLeaf => Left == null && Right == null;
}