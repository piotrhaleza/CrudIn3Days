CREATE TABLE [dbo].[CLIENTS]
(
	[ID]            INT            IDENTITY (1, 1) NOT NULL,
    [NAME]       NVARCHAR (260)                    NOT NULL,
    [SURNAME]       NVARCHAR (260)                 NOT NULL,
    [CITY]          NVARCHAR (260)                     NULL,
    [POSTCODE]      NVARCHAR (260)                     NULL,
    [HOUSENUMBER]   NVARCHAR (260)                     NULL,


    CONSTRAINT [PK_CLIENTS] PRIMARY KEY CLUSTERED ([ID] ASC),
)
