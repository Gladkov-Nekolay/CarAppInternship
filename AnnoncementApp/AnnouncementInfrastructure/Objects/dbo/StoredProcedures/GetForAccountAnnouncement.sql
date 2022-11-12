CREATE PROCEDURE [dbo].[GetForAccountAnnouncement]
	@AccountID bigint,
	@PageNum int,
	@PageSize int
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
	WHERE @AccountID = OwnerID

	ORDER BY ID
	OFFSET (@PageNum - 1) * @PageSize ROWS
	FETCH NEXT @PageSize ROWS ONLY
END
