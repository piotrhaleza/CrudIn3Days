﻿CREATE TABLE [dbo].[ORDER_ORDERARTICLES]
(
	[ID]            INT                 IDENTITY (1, 1) NOT NULL,
	[ORDERID]			INT									NULL,
	[ORDERARTICLEID]      INT								 NULL

	CONSTRAINT [PK_ORDER_ORDERARTICLE] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_ORDER_ORDERARTICLE_ORDERID] FOREIGN KEY ([ORDERID]) REFERENCES [dbo].[ORDERS] ([ID]),
	CONSTRAINT [FK_ORDER_ORDERARTICLE_ORDERARTICLES] FOREIGN KEY ([ORDERARTICLEID]) REFERENCES [dbo].[ORDERARTICLES] ([ID]),

)
