using JNNJMods.CrabGameCheat.Modules;
using JNNJMods.UI;
using JNNJMods.UI.Elements;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace JNNJMods.CrabGameCheat.Util
{
    // Single Element Module Base, Serializable
    // I was too lazy to make a custom converter
    public class SEMBSerializable
    {
        private static readonly string AssemblyName = Assembly.GetExecutingAssembly().GetName().Name;
        public string Name { get; set; }
        public KeyCode KeyBind { get; set; }
        public object value { get; set; }

        [JsonConstructor]
        public SEMBSerializable(string nm, KeyCode keyCode, object val)
        {
            Name = nm;
            KeyBind = keyCode;
            value = val;
        }

        public SEMBSerializable(SingleElementModuleBase module)
        {
            Name = module.Name;
            KeyBind = module.KeyBind;
            value = module.Element.value;
        }

        // TODO: make this an actual conversion operator
        public SingleElementModuleBase AsSEMB(ClickGUI gui)
        {
            SingleElementModuleBase MappedModule = default;
            foreach(var module in Config.Instance.Modules)
            {
                if(module is SingleElementModuleBase && Name == module.Name)
                {
                    MappedModule = (SingleElementModuleBase)module;
                    MappedModule.KeyBind = KeyBind;
                    MappedModule.Element.SetValue(value);
                }
            }
            return MappedModule;
        }
    }

    public class MEMBSerializable
    {
        // Multi Element Module
        public string Name { get; set; }
        public List<SEMBSerializable> options { get; set; }

        public MEMBSerializable(string nm, List<SEMBSerializable> opts)
        {
            Name = nm;
            options = opts;
        }
        // TODO: implement multi element config save
    }

    public class ConfigSerializable
    {
        // Single Element Module
        public List<SEMBSerializable> SEMOptions { get; set; }
        // Multi Element Module
        public List<MEMBSerializable> MEMOptions { get; set; }
        public KeyCode ClickGuiKeyBind = KeyCode.RightShift; 

        public ConfigSerializable(List<SEMBSerializable> SEMOpts, List<MEMBSerializable> MEMOpts)
        {
            SEMOptions = SEMOpts;
            MEMOptions = MEMOpts;
        }

        public ConfigSerializable() {
            SEMOptions = new List<SEMBSerializable>();
            MEMOptions = new List<MEMBSerializable>();
        }
    }
}
