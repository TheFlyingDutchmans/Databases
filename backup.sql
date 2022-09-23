--- Backup: Full on Disk, append all existing data
BACKUP DATABASE [theflyingdutchman] TO  DISK = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\Backup\theflyingdutchman.bak' WITH NOFORMAT, NOINIT, 
NAME = N'theFlyingDutchMan-Full Database Backup', SKIP, NOREWIND, NOUNLOAD,  STATS = 10
GO

--- Transactional Log Backup
BACKUP LOG [theflyingdutchman]
TO DISK
= 
'C:\Program Files\Microsoft SQL Sever\MSSQL15.SQLEXPRESS\MSSQL\Backup\theflyingdutchman.trn'
WITH
NOFORMAT, NOINIT, MEDIANAME = 'Native_SQLSeverLogBackup', NAME = 'theFlyingDutchMan Log backup',
SKIP, NOREWIND, NOUNLOAD, STATS = 10
GO

--- Differential Backup, verify backup when finished, compressed the backup
BACKUP DATABASE [theflyingdutchman] TO  DISK = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\Backup\defferential_theflyingdutchman.bak' WITH  DIFFERENTIAL , NOFORMAT, NOINIT,  
NAME = N'theFlyingDutchMan Differential Database Backup', SKIP, NOREWIND, NOUNLOAD, COMPRESSION,  STATS = 10
GO
declare @backupSetId as int
select @backupSetId = position from msdb..backupset where database_name=N'theflyingdutchman' and backup_set_id=(select max(backup_set_id) from msdb..backupset
 where database_name=N'Netflix' )
if @backupSetId is null begin raiserror(N'Verify failed. Backup information for database ''theflyingdutchman'' not found.', 16, 1) end
RESTORE VERIFYONLY FROM  DISK = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\Backup\theflyingdutchman.bak' WITH  FILE = @backupSetId,  NOUNLOAD,  NOREWIND
GO
