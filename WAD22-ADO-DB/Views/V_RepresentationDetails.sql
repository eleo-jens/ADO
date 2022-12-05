CREATE VIEW [dbo].[V_RepresentationDetails]
	AS SELECT	R.[id], 
				[dateRepresentation],
				[heureRepresentation],
				S.[nom] AS [nomSpectacle]
		FROM [Representation] as R 
			JOIN [Spectacle] as S
			ON R.idSpectacle = S.id
