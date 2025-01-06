using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Melody.Data.Migrations
{
    /// <inheritdoc />
    public partial class appuserfirstnamelastname2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Playlist_AspNetUsers_UserId",
                table: "Playlist");

            migrationBuilder.DropForeignKey(
                name: "FK_PlaylistSong_Playlist_PlaylistsId",
                table: "PlaylistSong");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Playlist",
                table: "Playlist");

            migrationBuilder.RenameTable(
                name: "Playlist",
                newName: "Playlists");

            migrationBuilder.RenameIndex(
                name: "IX_Playlist_UserId",
                table: "Playlists",
                newName: "IX_Playlists_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Playlists",
                table: "Playlists",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Playlists_AspNetUsers_UserId",
                table: "Playlists",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlaylistSong_Playlists_PlaylistsId",
                table: "PlaylistSong",
                column: "PlaylistsId",
                principalTable: "Playlists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Playlists_AspNetUsers_UserId",
                table: "Playlists");

            migrationBuilder.DropForeignKey(
                name: "FK_PlaylistSong_Playlists_PlaylistsId",
                table: "PlaylistSong");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Playlists",
                table: "Playlists");

            migrationBuilder.RenameTable(
                name: "Playlists",
                newName: "Playlist");

            migrationBuilder.RenameIndex(
                name: "IX_Playlists_UserId",
                table: "Playlist",
                newName: "IX_Playlist_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Playlist",
                table: "Playlist",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Playlist_AspNetUsers_UserId",
                table: "Playlist",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlaylistSong_Playlist_PlaylistsId",
                table: "PlaylistSong",
                column: "PlaylistsId",
                principalTable: "Playlist",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
