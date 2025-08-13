using CipherSink.Models.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace CipherSink.Models.Database;

public class CipherSinkContext : DbContext
{
    public CipherSinkContext() { }

    public DbSet<LocalPlayer> LocalPlayers { get; set; }
    public DbSet<RemotePlayer> RemotePlayers { get; set; }
    public DbSet<PastGame> PastGames { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
       #if DEBUG
        // Development: Store in project folder
        string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
        string solutionDirectory = Directory.GetParent(baseDirectory)?.Parent?.Parent?.Parent?.FullName ?? baseDirectory;
        string databaseDirectory = Path.Combine(solutionDirectory, "Database");
        string databasePath = Path.Combine(databaseDirectory, "CipherSink.db");
       #else
        // Production: Store in user app data
        string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        string appFolder = Path.Combine(appDataPath, "CipherSink");
        string databasePath = Path.Combine(appFolder, "CipherSink.db");
       #endif

        Directory.CreateDirectory(Path.GetDirectoryName(databasePath)!);
        options.UseSqlite($"Data Source={databasePath}");
    }
}
