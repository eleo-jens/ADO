CREATE PROCEDURE [dbo].[SP_SpectacleAdd]
	@nom NVARCHAR(50),
	@description NVARCHAR(MAX)
AS
	INSERT INTO [Spectacle] ([nom], [description])
	OUTPUT [inserted].[id]
	VALUES (@nom, @description)
