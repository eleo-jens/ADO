/*Insert d'un client dans la DB avec le hashage/ cryptage du mot de passe*/

CREATE PROCEDURE [dbo].[SP_ClientAdd]
	@email NVARCHAR(255),
	@pass NVARCHAR(32),
	@nom NVARCHAR(50),
	@prenom NVARCHAR(50),
	@adresse NVARCHAR(MAX)
AS
	INSERT INTO [Client] ([email], [pass], [nom], [prenom], [adresse])
	OUTPUT [inserted].[id]
	VALUES (@email, HASHBYTES('SHA2_512', @pass), @nom, @prenom, @adresse)

