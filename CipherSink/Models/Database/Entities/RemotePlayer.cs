using System.ComponentModel.DataAnnotations;

namespace CipherSink.Models.Database.Entities;

public class RemotePlayer
{
    public int Id { get; set; }
    [Required]
    public string Username { get; set; } = string.Empty;
    [Required]
    public string PublicKey { get; set; } = string.Empty;
    public bool IsFriend { get; set; }
}
