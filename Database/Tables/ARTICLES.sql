CREATE TABLE [dbo].[ARTICLES]
(
	[ID]            INT                 IDENTITY (1, 1) NOT NULL,
    [NAME]          NVARCHAR (260)                      NOT NULL,
    [NETTOVALUE]    INT                                  NULL,
    [VATTAX]        INT                                  NULL,
  

    CONSTRAINT [PK_ARTICLES] PRIMARY KEY CLUSTERED ([ID] ASC),
)


