/*Vérifie si le compte utilisateur est déjà encodé dans la DB*/

CREATE PROCEDURE [dbo].[SP_ClientCheck]
	@email NVARCHAR(255),
	@pass NVARCHAR(32)
AS
	SELECT [id] FROM [Client] WHERE [email] = @email AND [pass] = HASHBYTES('SHA2_512', @pass)
