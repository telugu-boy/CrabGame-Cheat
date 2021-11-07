using JNNJMods.CrabGameCheat.Modules;
using JNNJMods.UI;
using JNNJMods.UI.Elements;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

namespace JNNJMods.CrabGameCheat.Util
{

    public class Config
    {
        public static Config Instance { get; private set; }

        public List<ModuleBase> Modules { get; private set; }

        public KeyCode ClickGuiKeyBind = KeyCode.RightShift;

        public void ExecuteForModules(Action<ModuleBase> action)
        {
            foreach (ModuleBase module in Modules)
            {
                action.Invoke(module);
            }
        }

        public T GetModule<T>() where T : ModuleBase
        {
            return Modules.OfType<T>().FirstOrDefault();
        }

        private List<ModuleBase> GetModules(ClickGUI gui)
        {
            return new List<ModuleBase>(CheatModuleAttribute.InstantiateAll(gui));
        }

        public Config(ClickGUI gui)
        {
            Instance = this;
            Modules = GetModules(gui);
        }

        public void WriteToFile(string file)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(file));
            // fires succesfully
            //File.AppendAllText(file, "poop\n");
            string serialized = GetConfigJson();
            //File.AppendAllText(file, serialized + '\n');
            File.WriteAllText(file, serialized);
        }

        public static Config FromFile(string file, ClickGUI gui)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(file));

            if (!File.Exists(file))
            {
                return CreateFile(file, gui);
            }

            try
            {
                return FromJson(File.ReadAllText(file), gui);
            }
            catch (JsonException)
            {
                File.Delete(file);
                return CreateFile(file, gui);
            }
        }

        private static Config CreateFile(string file, ClickGUI gui)
        {
            File.CreateText(file);

            Config config = new Config(gui);
            config.WriteToFile(file);

            return config;
        }

        public string GetConfigJson()
        {
            ConfigSerializable cfg = new ConfigSerializable();
            foreach (ModuleBase module in Modules)
            {
                if (module is SingleElementModuleBase)
                {
                    SEMBSerializable ms = new SEMBSerializable((SingleElementModuleBase)module);
                    cfg.SEMOptions.Add(ms);
                }
            }
            return JsonConvert.SerializeObject(cfg, Formatting.Indented);
        }

        public static Config FromJson(string json, ClickGUI gui)
        {
            try
            {
                Config cfg = new Config(gui);
                ConfigSerializable deserialized = JsonConvert.DeserializeObject<ConfigSerializable>(json);
                // Set menu key
                cfg.ClickGuiKeyBind = deserialized.ClickGuiKeyBind;
                // Set keybinds/statuses
                for (int i = 0; i < cfg.Modules.Count; i++)
                {
                    var mb = cfg.Modules[i];
                    if (mb is SingleElementModuleBase)
                    {
                        SEMBSerializable semb = deserialized.SEMOptions.Find(x => x.Name == mb.Name);
                        cfg.Modules[i] = semb.AsSEMB(gui);
                    }
                    // TODO: Implement MEMBs
                }

                return Instance = cfg;
            }
            catch (Exception e)
            {
                return new Config(gui);
            }
        }
    }
}
