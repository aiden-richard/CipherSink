using CipherSink.Models.GameBoard;
using CipherSink.Models.Cryptography.MerkleTree;

namespace CipherSinkTests;

[TestClass]
public class MerkleTreeTests
{
    [TestMethod]
    public void MerkleTree_Validate_ValidProof_ReturnsTrue()
    {
        // Arrange
        Gameboard gameboard = new Gameboard(); // Initialize a new gameboard
        gameboard.RandomizeShipPositions(); // Randomly place ships on the board
        gameboard.LockShips(); // This will generate the Merkle tree and root

        MerkleValidator merkleValidator = new MerkleValidator(gameboard.MerkleTree.RootHash);

        Cell cell = gameboard.Grid[0, 0]; // Get a specific cell to test
        string cellDataString = $"{cell.Coordinates.ToString()}:{cell.OccupationType}";
        byte[] salt = gameboard.MerkleTree.GetSalt(cell.Coordinates);

        List<MerkleProofElement> proofPath = gameboard.MerkleTree.ConstructMerkleProof(cell.Coordinates);

        // Act
        bool isValid = merkleValidator.Validate(cellDataString, salt, proofPath);

        // Assert
        Assert.IsTrue(isValid);
    }
}
