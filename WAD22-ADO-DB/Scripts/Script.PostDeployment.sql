/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

INSERT INTO [Spectacle]([nom], [description])
VALUES (N'Inauguration', N'Ouverture du théâtre')

GO

INSERT INTO [Type] ([nom], [prix])
VALUES (N'Enfant', 5), 
       (N'Étudiant', 8),
       (N'Adulte', 10)

GO

--INSERT INTO [Type] ([nom], [prix])
--VALUES (N'Enfant', 5)

--INSERT INTO [Type] ([nom], [prix])
--VALUES (N'Étudiant', 8)

--INSERT INTO [Type] ([nom], [prix])
--VALUES (N'Adulte', 10)