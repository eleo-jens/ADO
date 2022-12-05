﻿CREATE TABLE [dbo].[Client]
(
	[id] INT NOT NULL IDENTITY, 
	[email] NVARCHAR(255) NOT NULL,
	[pass] VARBINARY(64) NOT NULL,
	[nom] NVARCHAR(50) NOT NULL,
	[prenom] NVARCHAR(50) NOT NULL,
	[adresse] NVARCHAR(MAX),
    CONSTRAINT [PK_Client] PRIMARY KEY ([id]), 
    CONSTRAINT [CK_Client_nom] CHECK (LEN([nom]) >= 1),
	CONSTRAINT [CK_Client_prenom] CHECK (LEN([prenom]) >= 1)

)

GO

CREATE UNIQUE INDEX [UK_Client_email] ON [dbo].[Client] ([email])
