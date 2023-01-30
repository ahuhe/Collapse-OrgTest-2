﻿using Hi3Helper.Preset;
using Hi3Helper.Shared.ClassStruct;
using System.Collections.Generic;

namespace CollapseLauncher.Interfaces
{
    internal interface IGameVersionCheck
    {
        /// <summary>
        /// Returns or sets the path of the game
        /// </summary>
        string GameDirPath { get; set; }

        /// <summary>
        /// Returns or sets the game preset
        /// </summary>
        PresetConfigV2 GamePreset { get; set; }

        /// <summary>
        /// Returns or set the API properties
        /// </summary>
        RegionResourceProp GameAPIProp { get; set; }

        /// <summary>
        /// Returns the current version of the game as provided by miHoYo's API.
        /// </summary>
        /// <returns>The current version of the game</returns>
        GameVersion GetGameVersionAPI();

        /// <summary>
        /// Returns the version of the game installed.<br/>
        /// It will return a <c>null</c> if the game doesn't installed.
        /// </summary>
        /// <returns>The version of the game installed</returns>
        GameVersion? GetGameExistingVersion();

        /// <summary>
        /// Checks if the game version is installed or matches the version provided from miHoYo's API.
        /// </summary>
        bool IsGameVersionMatch();

        /// <summary>
        /// Check if the game version is installed.
        /// </summary>
        bool IsGameInstalled();

        /// <summary>
        /// Check if the game has a pre-load.
        /// </summary>
        bool IsGameHasPreload();

        /// <summary>
        /// Check if the game has a delta-patch. (For Honkai only)
        /// </summary>
        bool IsGameHasDeltaPatch();

        /// <summary>
        /// Returns the state of the game.
        /// </summary>
        GameInstallStateEnum GetGameState();

        /// <summary>
        /// Returns the Delta-patch file property.
        /// If the Delta-patch file doesn't exist, then it will return a null.<br/><br/>
        /// This method is only available for Honkai.
        /// </summary>
        DeltaPatchProperty GetDeltaPatchInfo();

        /// <summary>
        /// Returns the <c>List</c> of the Resource Version for the Latest Zip.
        /// </summary>
        List<RegionResourceVersion> GetGameLatestZip();

        /// <summary>
        /// Returns the <c>List</c> of the Resource Version for the Pre-load Zip.
        /// If the Pre-load doesn't exist, then it will return a null.
        /// </summary>
        List<RegionResourceVersion> GetGamePreloadZip();

        /// <summary>
        /// Update the location of the game folder and also save it to the Game Profile's Ini file.
        /// </summary>
        /// <param name="path">The path of the game folder</param>
        void UpdateGamePath(string path);

        /// <summary>
        /// Update the version of the game to the latest one provided by miHoYo's API and also save it to the Game Profile's Ini file.
        /// </summary>
        void UpdateGameVersionToLatest();

        /// <summary>
        /// Update the version of the game to the given value and also save it to the Game Profile's Ini file.
        /// </summary>
        /// <param name="version">The version to change</param>
        void UpdateGameVersion(GameVersion version);
    }
}