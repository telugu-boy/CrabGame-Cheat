﻿using System;
using System.IO;

namespace JNNJMods.CrabGameCheat.Util
{
    public class ConfigPaths
    {

        public static readonly string ConfigDirectory = Utilities.GetAssemblyLocation();

        public static readonly string ConfigFile =
            Path.Combine(ConfigDirectory, "config.json");

    }
}
