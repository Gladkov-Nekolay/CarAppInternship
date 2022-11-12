CREATE PROCEDURE [dbo].[AddAnnouncement]
	@OwnerID bigint,
	@IsSold bit,
	@CarID bigint,
	@Description nvarchar(MAX),
	@Price float
AS
BEGIN
	SET NOCOUNT ON
	INSERT INTO Announcement (
		OwnerID,
		IsSold,
		CarID,
		Description,
		Price
	)
	VALUES (
		@OwnerID,
		@IsSold,
		@CarID,
		@Description,
		@Price
)
END
