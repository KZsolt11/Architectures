CREATE TABLE [dbo].[todo_item]
(
	[id]				INT NOT NULL IDENTITY(1,1),
	[text]				NVARCHAR(200) NOT NULL,
	[todo_list_id]		INT NOT NULL,
	[created_date]		DATETIME NOT NULL,
	[created_by]		NVARCHAR(100) NOT NULL,
	[modified_date]		DATETIME NULL,
	[modified_by]		NVARCHAR(100) NULL,
	CONSTRAINT [pk_todo_item] PRIMARY KEY CLUSTERED ([id] ASC),
	CONSTRAINT [fk_todo_item_todo_list_01] FOREIGN KEY ([todo_list_id]) REFERENCES [dbo].[todo_list] ([id])
)
