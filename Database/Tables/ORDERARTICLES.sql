CREATE TABLE [dbo].[ORDERARTICLES]
(
	[ID]            INT                 IDENTITY (1, 1) NOT NULL,
    [NAME]          NVARCHAR (260)                      NOT NULL,
    [AMOUNT]        INT                                 NOT NULL,
    [ARTICLEID]     INT                                 NOT NULL,

    CONSTRAINT [PK_ORDERARTICLES] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_ORDERARTICLES_ARTICLEID] FOREIGN KEY ([ARTICLEID]) REFERENCES [dbo].[ARTICLES] ([ID]),

)
