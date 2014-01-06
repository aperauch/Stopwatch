CREATE TABLE [dbo].[Members] (
    [ID]         INT            IDENTITY (1, 1) NOT NULL,
    [FirstName]  NVARCHAR (MAX) NULL,
    [LastName]   NVARCHAR (MAX) NULL,
    [Email]      NVARCHAR (MAX) NULL,
	[StartTime]  DATETIME       NOT NULL,
    [StopTime]    DATETIME       NOT NULL,
    [TotalHours] FLOAT (53)     NOT NULL,
    CONSTRAINT [PK_dbo.Members] PRIMARY KEY CLUSTERED ([ID] ASC)
);

