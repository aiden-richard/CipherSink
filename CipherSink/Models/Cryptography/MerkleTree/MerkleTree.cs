using CipherSink.Models.GameBoard;

namespace CipherSink.Models.Cryptography.MerkleTree;

/// <summary>
/// This class represents a Merkle Tree constructed from a 2D grid of Cell objects.
/// A Merkle Tree is a binary tree where each leaf node contains the hash of a data block (in this case, a Cell),
/// Each non-leaf node contains the hash of the concatenation of its children's hashes,
/// The root node contains the hash representing the entire dataset.
/// 
/// We use a Merkle Tree to allow players to prove a specific cell's state (e.g., whether it contains part of a ship)
/// </summary>
public class MerkleTree
{
    public List<MerkleTreeNode> Leaves { get; }

    public MerkleTreeNode Root { get; }

    public byte[] RootHash => Root.Hash;

    public MerkleTree(Cell[,] grid)
    {
        // Initialize Leaves list of MerkleTreeNodes
        Leaves = new();
        for (int y = 0; y < Gameboard.BoardSize; y++)
        {
            for (int x = 0; x < Gameboard.BoardSize; x++)
            {
                var cell = grid[x, y];
                string cellDataString = $"{cell.Coordinates}:{(cell.IsOccupied ? "X" : "O")}";
                Leaves.Add(new MerkleTreeNode(cellDataString));
            }
        }

        Root = BuildMerkleRoot(Leaves);
    }

    /// <summary>
    /// This method builds the Merkle Tree from the list of leaf nodes and returns the root node.
    /// </summary>
    /// <param name="leaves">The list of leaf nodes</param>
    /// <returns>The root node</returns>
    /// <exception cref="ArgumentException">Throws exception if leaves are not valid</exception>
    private static MerkleTreeNode BuildMerkleRoot(List<MerkleTreeNode> leaves)
    {
        if (leaves == null || leaves.Count == 0 || leaves.Any(n => !n.IsLeaf))
        {
            throw new ArgumentException("Leaf nodes cannot be null or empty.");
        }

        List<MerkleTreeNode> nodes = leaves.ToList();
        while (nodes.Count > 1)
        {
            List<MerkleTreeNode> nextLevel = new();
            for (int i = 0; i < nodes.Count; i += 2)
            {
                if (i + 1 < nodes.Count)
                {
                    nextLevel.Add(new MerkleTreeNode(nodes[i], nodes[i + 1]));
                }
                else
                {
                    nextLevel.Add(new MerkleTreeNode(nodes[i], nodes[i]));
                }
            }
            nodes = nextLevel;
        }

        return nodes[0];
    }

    /// <summary>
    /// This method constructs a Merkle proof for the cell at the given coordinates.
    /// 
    /// A merkle proof is a sequence of hashes that allows one to prove that a specific leaf node is part of the Merkle tree
    /// The method takes in the coordinates of the cell and returns a list of MerkleProofElements
    /// 
    /// The validator will take these proof elements, along with the cell data and salt, to reconstruct the path up to the root hash
    /// If the reconstructed root hash matches the known root hash, the proof is valid
    /// </summary>
    /// <param name="coords"></param>
    /// <returns></returns>
    public List<MerkleProofElement> ConstructMerkleProof(Coordinates coords)
    {
        if (coords == null)
        {
            return new List<MerkleProofElement>(); // empty proof for null coordinates
        }

        int index = coords.Y * Gameboard.BoardSize + coords.X;
        MerkleTreeNode? leaf = (index >= 0 && index < Leaves.Count) ? Leaves[index] : null;

        if (leaf == null || !leaf.IsLeaf || !Leaves.Contains(leaf))
        {
            return new List<MerkleProofElement>(); // empty proof for null, non-leaf, or leaf not in tree
        }

        List<MerkleProofElement> proof = new();
        List<MerkleTreeNode> nodes = Leaves.ToList();
        MerkleTreeNode targetLeaf = leaf;

        while (nodes.Count > 1)
        {
            List<MerkleTreeNode> nextLevel = new();

            for (int i = 0; i < nodes.Count; i += 2)
            {
                MerkleTreeNode left = nodes[i];
                MerkleTreeNode right = (i + 1 < nodes.Count) ? nodes[i + 1] : null;

                MerkleTreeNode combinedNode = right != null
                    ? new MerkleTreeNode(left, right)
                    : new MerkleTreeNode(left, left);

                if (right != null)
                {
                    if (left.Hash.SequenceEqual(targetLeaf.Hash))
                    {
                        proof.Add(new MerkleProofElement(right.Hash, false));
                        targetLeaf = combinedNode;
                    }
                    else if (right.Hash.SequenceEqual(targetLeaf.Hash))
                    {
                        proof.Add(new MerkleProofElement(left.Hash, true));
                        targetLeaf = combinedNode;
                    }
                }
                else
                {
                    if (left.Hash.SequenceEqual(targetLeaf.Hash))
                    {
                        proof.Add(new MerkleProofElement(left.Hash, false));
                        targetLeaf = combinedNode;
                    }
                }

                nextLevel.Add(combinedNode);
            }
            nodes = nextLevel;
        }

        return proof;
    }

    public byte[] GetSalt(Coordinates coords)
    {
        int index = coords.Y * Gameboard.BoardSize + coords.X;

        if (index < 0 || index >= Leaves.Count)
        {
            throw new ArgumentOutOfRangeException(nameof(coords), "Coordinates are out of bounds.");
        }

        return Leaves[index].Salt;
    }
}