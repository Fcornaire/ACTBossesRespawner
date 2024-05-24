<!-- PROJECT LOGO -->
<br />
<div align="center">
  <h3 align="center">ACTBossesRespawner</h3>
</div>

<!-- Shield -->

[![Contributors][contributors-shield]][contributors-url]
[![Download][download-shield]][download-url]
[![Forks][forks-shield]][forks-url]
[![Stargazers][stars-shield]][stars-url]
[![Issues][issues-shield]][issues-url]
[![MIT License][license-shield]][license-url]

<!-- ABOUT THE PROJECT -->

# About The Project

A mod (steam version) for the game `another crab's treasure` ,for re fighting mandatory/optionnal bosses ,no less no more.

# Disclaimer

- ⚠️ Backup your save data ⚠️ . It's not mandatory but since the mod edit the in game save data (and the game will auto save most of the time), you might be able for some reason to corrupt your save data.
  The game save data are located at `{your disk}:\Users\{your windows user name}\AppData\LocalLow\Aggro Crab\AnotherCrabsTreasure` with the 3 save folder. You can manually make a copy of the `.crab` files or just copy the whole `AnotherCrabsTreasure` folder somewhere (you will have to manually copying back for restoring)

- The mod was built/tested for windows and for the game version `1.0.102.5` (latest as 24/05/2024) meaning it might not work for older nor next update

# Usage

It fairly easy to install this mod:

1. Install [BepInEx](https://github.com/BepInEx/BepInEx/releases) to your game. You can follow this [guide](https://docs.bepinex.dev/articles/user_guide/installation/index.html) for help .
2. Run the game once (to like at least to tilte screen) and confirm that you have the file at `{your game directory location}/BepInEx/LogOutput.txt` . This is for confirming that BepInEx is correctly installed
3. Download the latest mod [release](https://github.com/Fcornaire/ACTBR/releases)
4. Install the mod by copying the mod to `{your game directory location}/BepInEx/plugins` (meaning you now should have `{your game directory location}/BepInEx/plugins/ACTBossesRespawner.dll` )

If all done correctly, when entering the pause menu and navigating the menu tabs, you should be able to see the respawn tab.

<p align="center">
  <img src="imgs/work.png" alt="screen with the mod" />
</p>

Select a boss to be teleported to the boss location and start the fight !

You might be too strong for the boss depending of your level, it's advised to re balance a bit at least your attack stat.

Depending of the boss, it also advised to finish all related next event (dialogue, re acquiring power up, etc) related to the boss before going to another boss. You might get some unexpected behaviour if not.

Also the mod offer 2 other features that cab be activated by hotkey:

- F5: Restore your initial save data. The mod will backup your original save data the first time you try to re load a boss. This is another backup just in case that will be located at `{your disk}:\Users\{your windows user name}\AppData\LocalLow\Aggro Crab\AnotherCrabsTreasure/BackupByModBossesRespawner`. F5 to restore that save (nothing will happen if you didn't re load a boss yet since the backup happen the first re load). Again , ⚠️ Backup your save data ⚠️ to be safe , you have been warned (to be fair, i don't think you can corrupt your save data that easily but you never know...)

- F6: Toggle the dev debug mode, open the pause menu and navigate throught the tabs to see the debup tab . You will acces debug feature. (You don't need that by the way, i mostly use the `warp to shell` feature and was lazy enough to remove the feature properly)

# Known bugs

- Out of place environnement music

<!-- MARKDOWN LINKS & IMAGES -->
<!-- https://www.markdownguide.org/basic-syntax/#reference-style-links -->

[contributors-shield]: https://img.shields.io/github/contributors/Fcornaire/ACTBR.svg?style=for-the-badge
[contributors-url]: https://github.com/Fcornaire/ACTBR/graphs/contributors
[forks-shield]: https://img.shields.io/github/forks/Fcornaire/ACTBR.svg?style=for-the-badge
[forks-url]: https://github.com/Fcornaire/ACTBR/network/members
[stars-shield]: https://img.shields.io/github/stars/Fcornaire/ACTBR.svg?style=for-the-badge
[stars-url]: https://github.com/Fcornaire/ACTBR/stargazers
[issues-shield]: https://img.shields.io/github/issues/Fcornaire/ACTBR.svg?style=for-the-badge
[issues-url]: https://github.com/Fcornaire/ACTBR/issues
[license-shield]: https://img.shields.io/github/license/Fcornaire/ACTBR.svg?style=for-the-badge
[download-shield]: https://img.shields.io/github/downloads/Fcornaire/ACTBR/total?style=for-the-badge
[download-url]: https://github.com/Fcornaire/ACTBR/releases
[license-url]: https://github.com/Fcornaire/ACTBR/blob/master/LICENSE.txt