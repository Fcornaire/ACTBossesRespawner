namespace ACTBossRespawner.Extensions
{
    public static class PlayerExtensions
    {
        public static void ResetStats(this Player player)
        {
            player.ResetHealth();
            player.playerStatBlock.Init();
        }
    }
}
