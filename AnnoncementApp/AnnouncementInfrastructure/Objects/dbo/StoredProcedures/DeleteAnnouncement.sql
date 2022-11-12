CREATE PROCEDURE [dbo].[DeleteAnnouncement]
	@ID bigint
AS
BEGIN
	SET NOCOUNT ON

	DELETE
	FROM Announcement

	WHERE ID = @ID
END
