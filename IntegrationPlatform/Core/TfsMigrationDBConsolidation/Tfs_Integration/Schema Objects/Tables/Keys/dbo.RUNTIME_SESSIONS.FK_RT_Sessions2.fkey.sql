﻿ALTER TABLE [dbo].[RUNTIME_SESSIONS]
	ADD CONSTRAINT [FK_RT_Sessions2] 
	FOREIGN KEY (RightSourceId)
	REFERENCES MIGRATION_SOURCES (Id)	
