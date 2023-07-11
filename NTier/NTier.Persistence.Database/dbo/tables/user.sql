CREATE TABLE [dbo].[user]
(
	[id]				INT NOT NULL IDENTITY(1,1),
	[name]				NVARCHAR(200) NOT NULL,
	[email]				NVARCHAR(200) NOT NULL,
	[created_date]		DATETIME NOT NULL,
	[created_by]		NVARCHAR(100) NOT NULL,
	[modified_date]		DATETIME NULL,
	[modified_by]		NVARCHAR(100) NULL,
	CONSTRAINT [pk_user] PRIMARY KEY CLUSTERED ([id] ASC)
)
