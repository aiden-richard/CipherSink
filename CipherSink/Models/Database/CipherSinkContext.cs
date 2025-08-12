using CipherSink.Models.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace CipherSink.Models.Database;

public class CipherSinkContext : DbContext
{
    public CipherSinkContext()
    {
        Database.EnsureCreated();
    }

    public DbSet<LocalUser> LocalUsers { get; set; }
    public DbSet<RemotePlayer> RemotePlayers { get; set; }
    public DbSet<PastGame> PastGames { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite("Data Source=CipherSink.db");


}
