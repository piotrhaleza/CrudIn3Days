﻿CREATE VIEW [dbo].[V_ORDERARTICLES]
	AS 
	SELECT 
	O.ID,
	O.NAME,
	AR.NAME ARTICLENAME,
	O.AMOUNT,
	AR.BRUTTOVALUE * O.AMOUNT VALUEBRUTTO,
	AR.NETTOVALUE * O.AMOUNT VALUENETTO
	FROM [ORDERARTICLES] O
	JOIN dbo.V_ARTICLES AR ON AR.ID = O.ARTICLEID
