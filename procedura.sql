CREATE OR ALTER PROCEDURE RemoveFromPlaylist
	@SongId INT,
	@PlaylistId INT
AS
	BEGIN
		DELETE FROM PlaylistSong WHERE PlaylistsId = @PlaylistId AND SongsSongID = @SongId
	END
GO