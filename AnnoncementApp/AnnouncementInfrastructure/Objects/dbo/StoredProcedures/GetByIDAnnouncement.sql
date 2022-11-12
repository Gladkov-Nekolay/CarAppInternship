CREATE PROCEDURE [dbo].[GetByIDAnnouncement]
	@ID bigint
AS
BEGIN
	SET NOCOUNT ON

	SELECT 
		ID,
		OwnerID,
		IsSold,
		CarID,
		Description,
		Price
	
	FROM Announcement
	WHERE @ID = ID
END
