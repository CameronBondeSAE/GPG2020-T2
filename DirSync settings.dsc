<?xml version="1.0" encoding="UTF-8"?>
<!DOCTYPE dirsyncpro [
<!ELEMENT dirsyncpro (job*)>
<!ATTLIST dirsyncpro logfile CDATA ''>

<!ELEMENT job (schedule*)>
<!ELEMENT job (filter*)>
<!ATTLIST job name CDATA #REQUIRED>
<!ATTLIST job enabled (true|false) 'true'>
<!ATTLIST job src CDATA #REQUIRED>
<!ATTLIST job dst CDATA #REQUIRED>
<!ATTLIST job syncMode CDATA #REQUIRED>
<!ATTLIST job recursive (true|false) 'false'>
<!ATTLIST job verify (true|false) 'false'>
<!ATTLIST job realtimeSync (true|false) 'false'>
<!ATTLIST job realtimeSyncOnStart (true|false) 'false'>
<!ATTLIST job realtimeDelayValue CDATA #REQUIRED>
<!ATTLIST job logfile CDATA ''>
<!ATTLIST job compareMode CDATA ''>
<!ATTLIST job copyAll (true|false) 'false'>
<!ATTLIST job copyLarger (true|false) 'false'>
<!ATTLIST job copyModified (true|false) 'false'>
<!ATTLIST job copyLargerAndModified (true|false) 'false'>
<!ATTLIST job copyNew (true|false) 'false'>
<!ATTLIST job delFiles (true|false) 'false'>
<!ATTLIST job delDirs (true|false) 'false'>
<!ATTLIST job delExcludedFilesA (true|false) 'false'>
<!ATTLIST job delExcludedDirsA (true|false) 'false'>
<!ATTLIST job delExcludedFilesB (true|false) 'false'>
<!ATTLIST job delExcludedDirsB (true|false) 'false'>
<!ATTLIST job syncConflictResolutionMode CDATA ''>
<!ATTLIST job symLinkMode CDATA ''>
<!ATTLIST job granularity CDATA '0'>
<!ATTLIST job timestampWriteBack (true|false) 'false'>
<!ATTLIST job backups CDATA ''>
<!ATTLIST job backupInline (true|false) 'false'>
<!ATTLIST job backupDir CDATA ''>
<!ATTLIST job preserveDOSAttributes (true|false) 'false'>
<!ATTLIST job preservePOSIXFilePermissions (true|false) 'false'>
<!ATTLIST job preservePOSIXFileOwnership (true|false) 'false'>
<!ATTLIST job overrideReadOnly (true|false) 'false'>

<!ELEMENT schedule EMPTY>
<!ATTLIST schedule type CDATA #REQUIRED>
<!ATTLIST schedule timeFrameFrom CDATA '01-01-1970 01:00'>
<!ATTLIST schedule timeFrameTo CDATA '01-01-1970 01:00'>
<!ATTLIST schedule interval CDATA '1'>
<!ATTLIST schedule time CDATA '01:00'>
<!ATTLIST schedule date CDATA '01-01-1970 01:00'>
<!ATTLIST schedule day CDATA '1'>
<!ATTLIST schedule monday (true|false) 'true'>
<!ATTLIST schedule tuesday (true|false) 'false'>
<!ATTLIST schedule wednesday (true|false) 'false'>
<!ATTLIST schedule thursday (true|false) 'false'>
<!ATTLIST schedule friday (true|false) 'false'>
<!ATTLIST schedule saturday (true|false) 'false'>
<!ATTLIST schedule sunday (true|false) 'false'>
<!ATTLIST schedule january (true|false) 'true'>
<!ATTLIST schedule february (true|false) 'false'>
<!ATTLIST schedule march (true|false) 'false'>
<!ATTLIST schedule april (true|false) 'false'>
<!ATTLIST schedule may (true|false) 'false'>
<!ATTLIST schedule june (true|false) 'false'>
<!ATTLIST schedule july (true|false) 'false'>
<!ATTLIST schedule august (true|false) 'false'>
<!ATTLIST schedule september (true|false) 'false'>
<!ATTLIST schedule october (true|false) 'false'>
<!ATTLIST schedule november (true|false) 'false'>
<!ATTLIST schedule december (true|false) 'false'>
<!ELEMENT filter EMPTY>
<!ATTLIST filter type CDATA #REQUIRED>
<!ATTLIST filter action CDATA #REQUIRED>
<!ATTLIST filter date CDATA ''>
<!ATTLIST filter dateType CDATA ''>
<!ATTLIST filter dateMode CDATA ''>
<!ATTLIST filter timeUnitValue CDATA ''>
<!ATTLIST filter readonly (true|false) 'true'>
<!ATTLIST filter hidden (true|false) 'true'>
<!ATTLIST filter system (true|false) 'true'>
<!ATTLIST filter archive (true|false) 'true'>
<!ATTLIST filter owner CDATA ''>
<!ATTLIST filter group CDATA ''>
<!ATTLIST filter permissionValue CDATA ''>
<!ATTLIST filter fileSizeValue CDATA ''>
<!ATTLIST filter fileSizeType CDATA ''>
<!ATTLIST filter path CDATA ''>
<!ATTLIST filter pattern CDATA ''>
<!ATTLIST filter patternType CDATA ''>
<!ATTLIST filter regularExpression (true|false) 'false'>
]>
<dirsyncpro logfile="">
  <meta program="DirSync Pro 1.53" os="Windows 10-10.0-amd64" java="1.8.0_131-Oracle Corporation"/>
  <job name="Job 1" enabled="true" src="C:\Users\Cameron\Documents\School\GPG2020-T2\Assets" dst="C:\Users\Cameron\Documents\School\GPG2020-T2 - Salve\Assets" syncMode="ABMirror" recursive="true" verify="false" realtimeSync="true" realtimeSyncOnStart="true" realtimeDelayValue='1' logfile="" compareMode="CompareFileSizesDates" copyAll="false" copyLarger="false" copyLargerAndModified="false" copyModified="true" copyNew="true" delFiles="true" delDirs="true" delExcludedFilesA="false" delExcludedDirsA="false" delExcludedFilesB="false" delExcludedDirsB="false" syncConflictResolutionMode="CopySource" backups="0" backupInline="true" backupDir="" timestampWriteBack="false" ignoreDaylightSavingGarnularity="false" syncDirTimeStamp="false" granularity='0' symLinkMode="SkipSymLinks" preserveDOSAttributes="false" preservePOSIXFilePermissions="false" preservePOSIXFileOwnership="false" overrideReadOnly="false">
    <filter type="ByPattern" action="Include" patternType="File" pattern="*" regularExpression="false"/>
    <filter type="ByPattern" action="Include" patternType="Directory" pattern="*" regularExpression="false"/>
  </job>
  <job name="Job 2" enabled="true" src="C:\Users\Cameron\Documents\School\GPG2020-T2\Packages" dst="C:\Users\Cameron\Documents\School\GPG2020-T2 - Salve\Packages" syncMode="ABMirror" recursive="true" verify="false" realtimeSync="true" realtimeSyncOnStart="true" realtimeDelayValue='1' logfile="" compareMode="CompareFileSizesDates" copyAll="false" copyLarger="false" copyLargerAndModified="false" copyModified="true" copyNew="true" delFiles="true" delDirs="true" delExcludedFilesA="false" delExcludedDirsA="false" delExcludedFilesB="false" delExcludedDirsB="false" syncConflictResolutionMode="CopySource" backups="0" backupInline="true" backupDir="" timestampWriteBack="false" ignoreDaylightSavingGarnularity="false" syncDirTimeStamp="false" granularity='0' symLinkMode="SkipSymLinks" preserveDOSAttributes="false" preservePOSIXFilePermissions="false" preservePOSIXFileOwnership="false" overrideReadOnly="false">
    <filter type="ByPattern" action="Include" patternType="File" pattern="*" regularExpression="false"/>
    <filter type="ByPattern" action="Include" patternType="Directory" pattern="*" regularExpression="false"/>
  </job>
  <job name="Job 3" enabled="true" src="C:\Users\Cameron\Documents\School\GPG2020-T2\ProjectSettings" dst="C:\Users\Cameron\Documents\School\GPG2020-T2 - Salve\ProjectSettings" syncMode="ABMirror" recursive="true" verify="false" realtimeSync="true" realtimeSyncOnStart="true" realtimeDelayValue='1' logfile="" compareMode="CompareFileSizesDates" copyAll="false" copyLarger="false" copyLargerAndModified="false" copyModified="true" copyNew="true" delFiles="true" delDirs="true" delExcludedFilesA="false" delExcludedDirsA="false" delExcludedFilesB="false" delExcludedDirsB="false" syncConflictResolutionMode="CopySource" backups="0" backupInline="true" backupDir="" timestampWriteBack="false" ignoreDaylightSavingGarnularity="false" syncDirTimeStamp="false" granularity='0' symLinkMode="SkipSymLinks" preserveDOSAttributes="false" preservePOSIXFilePermissions="false" preservePOSIXFileOwnership="false" overrideReadOnly="false">
    <filter type="ByPattern" action="Include" patternType="File" pattern="*" regularExpression="false"/>
    <filter type="ByPattern" action="Include" patternType="Directory" pattern="*" regularExpression="false"/>
  </job>
</dirsyncpro>
