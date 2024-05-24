namespace ACTBossRespawner
{
    public static class BackupInfo
    {
        public static readonly string Folder = "/BackupByModBossesRespawner/";
        public static readonly string Filename = "SaveFile_bak";

        public static string BackupPath => $"{GameManager.persistentDataPath}{Folder}{Filename}.CRAB";
    }
}
