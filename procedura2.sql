CREATE OR ALTER PROCEDURE RemoveFromPlaylist
    @SongId INT,
    @PlaylistId INT
AS
    BEGIN
        DECLARE @Title VARCHAR(100);

        SELECT TOP 1 @Title = Title FROM Songs WHERE SongId = @SongId;

        INSERT INTO RemovedFromPlaylists(SongId, Title, DateRemoved) VALUES(@SongId, @Title, GETDATE());

        DELETE FROM PlaylistSong WHERE PlaylistsId = @PlaylistId AND SongsSongID = @SongId
    END
GO
