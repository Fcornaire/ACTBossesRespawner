using System;

namespace ACTBossRespawner.Extensions
{
    public static class LevelExtensions
    {
        public static MSSCollectable ToMSSCollectable(this Level level)
        {
            switch (level)
            {
                case Level.Scuttleport:
                    return GameManager.instance.mssCollection.Scuttleport[0];
                case Level.TheShallows:
                    return GameManager.instance.mssCollection.TheShallows[0];
                case Level.TheExpiredGrove:
                    return GameManager.instance.mssCollection.TheExpiredGrove[0];
                case Level.TheOpenOcean:
                    return GameManager.instance.mssCollection.OpenOcean[0];
                case Level.PinBarge:
                    return GameManager.instance.mssCollection.PinBarge[0];
                case Level.TheUnfathom:
                    return GameManager.instance.mssCollection.TheUnfathom[0];
                case Level.TheBleachedCity:
                    return GameManager.instance.mssCollection.TheBleachedCity[0];
                default:
                    throw new ArgumentOutOfRangeException(nameof(level), level, null);
            }
        }
    }
}
