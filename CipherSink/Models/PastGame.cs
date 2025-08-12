using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CipherSink.Models;

public class PastGame
{
    public int Id { get; set; }

    [ForeignKey("LocalUser")]
    public int LocalUserId { get; set; }
    public LocalUser LocalUser { get; set; }

    [ForeignKey("RemotePlayer")]
    public int RemotePlayerId { get; set; }
    public RemotePlayer RemotePlayer { get; set; }

    // Not needed for testing nor at the immediate moment, but useful for later on
    /*[Required]
    public string ShipPlacementsJson { get; set; } = string.Empty; // Store as JSON

    [Required]
    public string LossSignature { get; set; } = string.Empty;
    */

    public int GameLengthSeconds { get; set; }
    public int TurnsTaken { get; set; }
}
