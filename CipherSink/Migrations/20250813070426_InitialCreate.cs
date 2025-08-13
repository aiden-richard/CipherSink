using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CipherSink.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LocalPlayers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EncryptedPrivateKeyBytes = table.Column<byte[]>(type: "BLOB", nullable: false),
                    TotalWins = table.Column<int>(type: "INTEGER", nullable: false),
                    TotalLosses = table.Column<int>(type: "INTEGER", nullable: false),
                    TotalHits = table.Column<int>(type: "INTEGER", nullable: false),
                    TotalMisses = table.Column<int>(type: "INTEGER", nullable: false),
                    TotalSunkShips = table.Column<int>(type: "INTEGER", nullable: false),
                    Username = table.Column<string>(type: "TEXT", nullable: false),
                    PublicKeyBytes = table.Column<byte[]>(type: "BLOB", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocalPlayers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PastGames",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LocalUserId = table.Column<int>(type: "INTEGER", nullable: false),
                    RemotePlayerId = table.Column<int>(type: "INTEGER", nullable: false),
                    GameLengthSeconds = table.Column<int>(type: "INTEGER", nullable: false),
                    TurnsTaken = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PastGames", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RemotePlayers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IsFriend = table.Column<bool>(type: "INTEGER", nullable: false),
                    Username = table.Column<string>(type: "TEXT", nullable: false),
                    PublicKeyBytes = table.Column<byte[]>(type: "BLOB", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RemotePlayers", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LocalPlayers");

            migrationBuilder.DropTable(
                name: "PastGames");

            migrationBuilder.DropTable(
                name: "RemotePlayers");
        }
    }
}
