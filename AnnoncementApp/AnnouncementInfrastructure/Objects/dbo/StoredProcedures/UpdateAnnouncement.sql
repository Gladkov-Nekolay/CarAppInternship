CREATE PROCEDURE [dbo].[UpdateAnnouncement]
	@ID bigint,
	@OwnerID bigint,
	@IsSold bit,
	@CarID bigint,
	@Description nvarchar(MAX),
	@Price float
AS
BEGIN
	SET NOCOUNT ON
	UPDATE Announcement
	SET
		OwnerID = @OwnerID,
		IsSold = @IsSold,
		CarID = @CarID,
		Description = @Description,
		Price = @Price
	WHERE ID = @ID
END
