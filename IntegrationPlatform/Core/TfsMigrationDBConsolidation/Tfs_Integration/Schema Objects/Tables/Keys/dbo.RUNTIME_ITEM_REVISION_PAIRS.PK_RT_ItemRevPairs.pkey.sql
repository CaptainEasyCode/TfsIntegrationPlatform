﻿ALTER TABLE [dbo].[RUNTIME_ITEM_REVISION_PAIRS]
	ADD CONSTRAINT [PK_RT_ItemRevPairs]
	PRIMARY KEY (LeftMigrationItemId, RightMigrationItemId)