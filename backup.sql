--- Backup: Full on Disk, append all existing data
BACKUP DATABASE theflyingdutchman TO  DISK = 'D:\MySQLBackups\theflyingdutchman.bak' WITH NOFORMAT, NOINIT, NAME = 'TheFlyingDutchMan-Full Database Backup', SKIP, NOREWIND, NOUNLOAD, STATS = 10
GO

--- Transactional Log Backup
BACKUP LOG theflyingdutchman
TO DISK = 'D:\MySQLBackups\theflyingdutchman.trn' WITH NOFORMAT, NOINIT, NAME = 'TheFlyingDutchMan Log backup', SKIP, NOREWIND, NOUNLOAD, STATS = 10
GO

--- Differential Backup, verify backup when finished, compressed the backup
BACKUP DATABASE theflyingdutchman TO  DISK = 'D:\MySQLBackups\theflyingdutchman.bak' WITH  DIFFERENTIAL , NOFORMAT, NOINIT, NAME = 'TheFlyingDutchMan Differential Database Backup', SKIP, NOREWIND, NOUNLOAD, COMPRESSION,  STATS = 10
GO

