

# CrabGame Cheat
A Cheat for the Game [CrabGame](https://store.steampowered.com/app/1782210/Crab_Game/) by [DaniDev](https://www.youtube.com/c/DaniDev).

**Also join my Discord Server:** https://discord.gg/UUhXmhPWfq

## Installation BepInEx (RECOMMENDED)
 1. Download the [lastest BepInEx Build](https://builds.bepis.io/projects/bepinex_be), the file name should start with "BepInEx_UnityIL2CPP".
 2. Dowload [CrabGame_Cheat_BepInEx.dll](https://github.com/DasJNNJ/CrabGame-Cheat/releases/latest/download/CrabGame_Cheat_BepInEx.dll)
 3. Extract the Zip archive in your Crab Game Installation Folder(Steam -> Right Click Crab Game -> Manage -> Browse local Files).
 4. Start the Game and then close it once you are in the Main Menu.
 5. Create a new Folder in "/BepInEx/plugins" and name it "CrabGame Cheat", then copy the [CrabGame_Cheat_BepInEx.dll](https://github.com/DasJNNJ/CrabGame-Cheat/releases/latest/download/CrabGame_Cheat_BepInEx.dll) into it.

## Installation MelonLoader (NOT RECOMMENDED & WON'T WORK ALWAYS)

 1. Download [MelonLoader Installer](https://github.com/LavaGang/MelonLoader.Installer/releases/latest/download/MelonLoader.Installer.exe) and install it for CrabGame.
 2. Then copy [CrabGame_Cheat_MelonLoader.dll](https://github.com/DasJNNJ/CrabGame-Cheat/releases/latest/download/CrabGame_Cheat_MelonLoader.dll) in the "Mods" folder contained in the CrabGame Installation directory.

**NOTE: The latest MelonLoader Version(v0.4.3 Open-Beta) is glitched.**

### MelonLoader fix

 1. Download [the Fix](https://cdn.discordapp.com/attachments/904583783594995712/904584155919163432/Il2CppAssemblyGenerator.dll).
 2. Open the Game Folder(Steam -> Right Click Crab Game -> Manage -> Browse local Files).
 3. Go into MelonLoader -> Dependencies -> Il2CppAssemblyGenerator
 4. Delete Il2CppAssemblyGenerator.dll
 5. Paste the downloaded File.

## Features
 - ClickGUI
 - ChatCommands
 - AirJump
 - AntiBoundKills
 - ClickTP
 - ESP
 - Fly
 - GlassBreaker
 - GodMode
 - Mega Jump
 - Mega Slap
 - NoFall
 - NoFreeze
 - NoPush
 - OwnerHighlight
 - Speed
 - Give Weapons
 - ...and more to come

## Building
One might need to build the cheat if they want the latest features or if they want to contribute to the project.

 1. Install [Visual Studio](https://visualstudio.microsoft.com/). Visual Studio is an integrated development environment (IDE) used to develop the cheat.
 2. Obtain the source code by cloning this repository with `git` or through other means.
 3. Create a folder named `Libraries` in the root of the source tree.
 4. Go to your game installation folder.
 5. Copy the contents of: `BepInEx\unhollowed`, `BepInEx\unity-libs`, `BepInEx\core` and `Newtonsoft.Json.dll` in the cheat's plugin folder to `Libraries`.
 6. In your source tree, open the solution (`Crab Game Cheat.sln`).
 7. Select the configuration BepInEx in the second ribbon in Visual Studio.
 8. Activate Ctrl+Shift+B to build the DLL.
 9. Copy the DLL to the cheat's plugin folder.

## DISCLAIMER
This software is for __educational__ purposes solely.
We encourage you to browse the source code of this software to gain an understanding of the tools, system and practices employed in game modifications.
We do not, however, encourage hacking where you are not allowed, and will not bear liability for your actions.

CrabGame-Cheat is GPLv3 licensed. Please read [LICENSE](LICENSE) before thinking of [skidding](https://www.urbandictionary.com/define.php?term=script%20kiddie) (e.g. infringing copyright, selling modified versions of the software without also providing modified source code) or you might be **sued** by the copyright holders.
