/*
USE MASTER
GO
CREATE DATABASE DappperBenchmark
GO
*/

USE DappperBenchmark;

IF EXISTS(SELECT 1  FROM sys.all_objects WHERE Object_ID = Object_ID(N'dbo.ColigadaFake'))
	DROP TABLE [dbo].[ColigadaFake]
   
GO

CREATE TABLE [dbo].[ColigadaFake](
	[ID] bigint NOT NULL identity(1, 1),
	[CODE] [varchar](20) NOT NULL,
	[DESCRIPTION] [varchar](max) NULL,
	[RECCREATEDBY] [varchar](50) NULL,
	[RECCREATEDON] [datetime] NULL,
 CONSTRAINT [PKColigadaFake] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO

DECLARE @CONTADOR bigint, @DESCRIPTION VARCHAR(MAX)
SET @CONTADOR = 0

SET @DESCRIPTION = ' - purus semper eget duis at tellus at urna condimentum mattis pellentesque id nibh tortor id aliquet lectus proin nibh nisl condimentum id venenatis a condimentum vitae sapien pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas sed tempus urna et pharetra pharetra massa massa ultricies mi quis hendrerit dolor magna eget est lorem ipsum dolor sit amet consectetur adipiscing elit pellentesque'

WHILE ( @CONTADOR < 1000)
BEGIN
    SET @CONTADOR = @CONTADOR + 1
    PRINT @CONTADOR

	INSERT INTO ColigadaFake(CODE, DESCRIPTION, RECCREATEDON, RECCREATEDBY)
	VALUES(
		RIGHT(CONCAT('000', @CONTADOR), 4), 
		CAST(@CONTADOR  AS VARCHAR) + @DESCRIPTION, getdate(), 'mestre')

END

GO

SELECT COUNT(1) FROM ColigadaFake

SELECT TOP 1100 * FROM ColigadaFake order by ID DESC