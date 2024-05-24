using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ACTBossRespawner
{
    public class RespawnContext
    {
        public List<RespawnInfo> RespawnInfos { get; }
        public string SaveStateToReEnable { get; set; } = string.Empty;
        public string ActiveBossName { get; set; } = string.Empty;

        public RespawnContext()
        {
            RespawnInfos =
            [
                new RespawnInfo()
                {
                    BossName = "The Consortium",
                    SaveState = "Boss_Consortium",
                    RespawnPlayerAt = new Vector3(-184, 57, 918),
                    Level = Level.Scuttleport,
                },
                new RespawnInfo()
                {
                    BossName = "Royal Shellsplitter",
                    SaveState = "Enemy_Executioner Boss Variant",
                    RespawnPlayerAt = new Vector3(614, 33, 438),
                    Level = Level.TheShallows
                },
                new RespawnInfo()
                {
                    BossName = "Curled Carbonara Connolsseur",
                    SaveState = "Enemy_BruiserGrove",
                    RespawnPlayerAt = new Vector3(1393, 38.5f, 681),
                    Level = Level.TheExpiredGrove
                },
                new RespawnInfo()
                {
                    BossName = "Grovekeeper Topoda",
                    SaveState = "Topoda",
                    RespawnPlayerAt = new Vector3(1209, 304, 1216),
                    Level = Level.TheExpiredGrove,
                    UpdateProgressIfNeeded = () =>
                    {
                        var topoda = CrabFile.current.progressData.expiredGroveLT.Single(data => data == ProgressData.ExpiredGroveProgress.TopodaDefeated);
                        var topodaR = CrabFile.current.progressData.expiredGroveLT.Single(data => data == ProgressData.ExpiredGroveProgress.TopodaReset);

                        var progress = CrabFile.current.progressData.expiredGroveBools.Single(data => data.id == topoda);
                        var progressR = CrabFile.current.progressData.expiredGroveBools.Single(data => data.id == topodaR);

                        progress.unlocked = false;
                        progressR.unlocked = false;
                    }
                },
                new RespawnInfo()
                {
                    BossName = "Scuttling Sludge Steamroller",
                    SaveState = "Enemy_BruiserScuttleport_Boss",
                    RespawnPlayerAt = new Vector3(621, 68, 352),
                    Level = Level.Scuttleport
                },
                new RespawnInfo()
                {
                    BossName = "Nephro",
                    RespawnPlayerAt = new Vector3(952, 25, 1105),
                    Level = Level.TheShallows,
                    UpdateProgressIfNeeded = () =>
                    {
                        var nephro = CrabFile.current.progressData.shallowsLT.Single(data => data == ProgressData.ShallowsProgress.NephroDefeated);
                        var progress = CrabFile.current.progressData.shallowsBools.Single(data => data.id == nephro);

                        progress.unlocked = false;
                    }
                },
                new RespawnInfo()
                {
                    BossName = "Polluted Platoon Pathfinder",
                    SaveState = "Enemy_Bruiser_Boss Variant",
                    RespawnPlayerAt = new Vector3(-314, 55, 849),
                    Level = Level.TheShallows
                },
                new RespawnInfo()
                {
                    BossName = "Magista",
                    SaveState = "Duchess",
                    RespawnPlayerAt = new Vector3(547, 71, 1399),
                    Level = Level.TheShallows,
                    UpdateProgressIfNeeded = () =>
                    {
                        var magista = CrabFile.current.progressData.shallowsLT.Single(data => data == ProgressData.ShallowsProgress.DuchessDefeated);

                        var progress = CrabFile.current.progressData.shallowsBools.Single(data => data.id == magista);

                        progress.unlocked = false;
                    }
                },
                new RespawnInfo()
                {
                    BossName = "Diseased Licenthrope",
                    SaveState = "Enemy_Lichenthrope",
                    RespawnPlayerAt = new Vector3(1631, 24, 429),
                    Level = Level.TheExpiredGrove,
                },
                 new RespawnInfo()
                {
                    BossName = "Heikea",
                    SaveState = "Heikea",
                    RespawnPlayerAt = new Vector3(1330, 123, 906),
                    Level = Level.TheExpiredGrove,
                    UpdateProgressIfNeeded = () =>
                    {
                        //For disabling the shell
                        var heika = CrabFile.current.progressData.expiredGroveLT.Single(data => data == ProgressData.ExpiredGroveProgress.HeikeaDefeated);

                        var progress = CrabFile.current.progressData.expiredGroveBools.Single(data => data.id == heika);

                        progress.unlocked = false;
                    }
                },
                new RespawnInfo()
                {
                    BossName = "Pagurus",
                    SaveState = "Boss_Pagurus",
                    RespawnPlayerAt = new Vector3(358, -62, 4553),
                    Level = Level.TheOpenOcean,
                },
                new RespawnInfo()
                {
                    IsEnabled = false,
                    BossName = "Inkerton 1st",
                    SaveState = "InkertonPreFight",
                    RespawnPlayerAt = new Vector3(-454, 51, 383),
                    Level = Level.Scuttleport,
                    UpdateProgressIfNeeded = () => //TODO: not working :/
                    {
                        var inkerton = CrabFile.current.progressData.scuttleportLT.Single(data => data == ProgressData.ScuttleportProgress.InkertonFought);

                        var progress = CrabFile.current.progressData.scuttleportBools.Single(data => data.id == inkerton);

                        progress.unlocked = false;
                    }
                },
                new RespawnInfo()
                {
                    SaveState = "Enemy_CevicheSister Variant",
                    BossName = "Ceviche Sisters",
                    RespawnPlayerAt = new Vector3(489, 90, 50),
                    Level = Level.Scuttleport,
                    UpdateProgressIfNeeded = () =>
                    {
                        var ceviche = CrabFile.current.progressData.scuttleportLT.Single(data => data == ProgressData.ScuttleportProgress.TwinPistolsDefeated);

                        var progress = CrabFile.current.progressData.scuttleportBools.Single(data => data.id == ceviche);

                        progress.unlocked = false;
                    }
                },
                new RespawnInfo()
                {
                    BossName = "Voltai",
                    RespawnPlayerAt = new Vector3(581, 261, 1030),
                    Level = Level.Scuttleport,
                    UpdateProgressIfNeeded = () =>
                    {
                        var voltai = CrabFile.current.progressData.scuttleportLT.Single(data => data == ProgressData.ScuttleportProgress.VoltaiDefeated);

                        var progress = CrabFile.current.progressData.scuttleportBools.Single(data => data.id == voltai);

                        progress.unlocked = false;
                    }
                },
                new RespawnInfo()
                {
                    BossName = "Roland",
                    RespawnPlayerAt = new Vector3(404, 115, 354),
                    Level = Level.PinBarge,
                    UpdateProgressIfNeeded = () =>
                    {
                        var roland = CrabFile.current.progressData.scuttleportLT.Single(data => data == ProgressData.ScuttleportProgress.RolandDefeated);
                        var sawDeepIntroScene = CrabFile.current.progressData.theUnfathomLT.Single(data => data == ProgressData.TheUnfathomProgress.SawDeepIntroScene);

                        var progress = CrabFile.current.progressData.scuttleportBools.Single(data => data.id == roland);
                        var progressScene = CrabFile.current.progressData.theUnfathomBools.Single(data => data.id == sawDeepIntroScene);

                        progress.unlocked = false;
                        progressScene.unlocked = false;
                    }
                },
                new RespawnInfo()
                {
                    BossName = "Petroch",
                    RespawnPlayerAt = new Vector3(1809, -1, 1121),
                    Level = Level.TheUnfathom,
                    UpdateProgressIfNeeded = () =>
                    {
                        var petroch = CrabFile.current.progressData.theUnfathomLT.Single(data => data == ProgressData.TheUnfathomProgress.PetrochDefeated);

                        var progress = CrabFile.current.progressData.theUnfathomBools.Single(data => data.id == petroch);

                        progress.unlocked = false;
                    }
                },
                new RespawnInfo()
                {
                    BossName = "Inkerton",
                    RespawnPlayerAt = new Vector3(3207, -9, 1376),
                    Level = Level.TheUnfathom,
                    UpdateProgressIfNeeded = () =>
                    {
                        var petroch = CrabFile.current.progressData.theUnfathomLT.Single(data => data == ProgressData.TheUnfathomProgress.InkertonDefeated);

                        var progress = CrabFile.current.progressData.theUnfathomBools.Single(data => data.id == petroch);

                        progress.unlocked = false;
                    }
                },
                new RespawnInfo()
                {
                    BossName = "Camtscha",
                    SaveState = "Boss_MoltedKing1",
                    RespawnPlayerAt = new Vector3(2794, 517, -435),
                    Level = Level.TheBleachedCity,
                    UpdateProgressIfNeeded = () =>
                    {
                        var bleachedKing = CrabFile.current.progressData.theBleachedCityLT.Single(data => data == ProgressData.TheBleachedCityProgress.BleachedKingKilled);
                        var bleachedKingPhase2 = CrabFile.current.progressData.theBleachedCityLT.Single(data => data == ProgressData.TheBleachedCityProgress.BleachedKingFakeKilled);

                        var progress = CrabFile.current.progressData.theBleachedCityBools.Single(data => data.id == bleachedKing);
                        var progressPhase2 = CrabFile.current.progressData.theBleachedCityBools.Single(data => data.id == bleachedKingPhase2);

                        progress.unlocked = false;
                        progressPhase2.unlocked = false;
                    }
                },
                new RespawnInfo()
                {
                    BossName = "Praya Dubia",
                    SaveState = "Boss_PrayaDubia_Phase2_Real",
                    RespawnPlayerAt = new Vector3(8680, 157, -2559),
                    Level = Level.TheBleachedCity,
                    UpdateProgressIfNeeded = () =>
                    {
                        var bleachedKing = CrabFile.current.progressData.theBleachedCityLT.Single(data => data == ProgressData.TheBleachedCityProgress.PrayaDubiaKilled);
                        var bleachedKingPhase2 = CrabFile.current.progressData.theBleachedCityLT.Single(data => data == ProgressData.TheBleachedCityProgress.PrayaDubiaPhase2Killed);

                        var progress = CrabFile.current.progressData.theBleachedCityBools.Single(data => data.id == bleachedKing);
                        var progressPhase2 = CrabFile.current.progressData.theBleachedCityBools.Single(data => data.id == bleachedKingPhase2);

                        progress.unlocked = false;
                        progressPhase2.unlocked = false;
                    }
                },
            ];
        }
    }

    public class RespawnInfo
    {
        public string BossName { get; set; }
        public string SaveState { get; set; } = string.Empty;
        public Vector3 RespawnPlayerAt { get; set; } = Vector3.zero;

        public Level Level { get; set; } = Level.NoLevel;

        public Action UpdateProgressIfNeeded { get; set; } = () => { };

        public bool IsEnabled { get; set; } = true;
    }
}
