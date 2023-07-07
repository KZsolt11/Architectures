CREATE TABLE [dbo].[todo_list]
(
	[id]				INT NOT NULL IDENTITY(1,1),
	[title]				NVARCHAR(200) NOT NULL,
	[created_date]		DATETIME NOT NULL,
	[created_by]		NVARCHAR(100) NOT NULL,
	[modified_date]		DATETIME NULL,
	[modified_by]		NVARCHAR(100) NULL,
	CONSTRAINT [pk_todo_list] PRIMARY KEY CLUSTERED ([id] ASC)
)
