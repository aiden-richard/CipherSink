using System.ComponentModel.DataAnnotations;

namespace CipherSink.Models.Database.Entities;

public class RemotePlayer : BasePlayer
{
    [Required]
    public bool IsFriend { get; set; }
}
