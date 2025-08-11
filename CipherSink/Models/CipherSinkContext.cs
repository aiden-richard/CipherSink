using Microsoft.EntityFrameworkCore;

namespace CipherSink.Models;

public class CipherSinkContext : DbContext
{
    public DbSet<LocalUser> LocalUsers { get; set; }
    public DbSet<RemotePlayer> RemotePlayers { get; set; }
    public DbSet<PastGame> PastGames { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlServer(@"Server=(localdb)\\mssqllocaldb;Database=CipherSinkDb;Trusted_Connection=True;");
}
