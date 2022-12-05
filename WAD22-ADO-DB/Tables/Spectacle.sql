CREATE TABLE [dbo].[Spectacle]
(
	[id] INT NOT NULL IDENTITY , 
    [nom] NVARCHAR(50) NOT NULL, 
    [description] NVARCHAR(MAX) NOT NULL, 
    CONSTRAINT [PK_Spectacle] PRIMARY KEY ([id]), 
    CONSTRAINT [CK_Spectacle_nom] CHECK (LEN([nom]) >=3) 
)

GO

CREATE UNIQUE INDEX [UK_Spectacle_nom] ON [dbo].[Spectacle] ([nom])
