CREATE TABLE [dbo].[Ticket]
(
	[id] INT NOT NULL IDENTITY, 
    [dateTicket] DATETIME2 NOT NULL DEFAULT GETDATE(), 
    [idClient] INT NOT NULL, 
    [idRepresentation] INT NOT NULL, 
    [idType] INT NOT NULL, 
    CONSTRAINT [PK_Ticket] PRIMARY KEY ([id]), 
    CONSTRAINT [FK_Ticket_Client] FOREIGN KEY ([idClient]) REFERENCES [Client]([id]), 
    CONSTRAINT [FK_Ticket_Representation] FOREIGN KEY ([idRepresentation]) REFERENCES [Representation]([id]), 
    CONSTRAINT [FK_Ticket_Type] FOREIGN KEY ([idType]) REFERENCES [Type]([id])

)
