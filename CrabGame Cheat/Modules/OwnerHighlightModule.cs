﻿using JNNJMods.CrabGameCheat.Util;
using JNNJMods.Render;
using JNNJMods.UI;
using JNNJMods.UI.Elements;
using UnityEngine;

namespace JNNJMods.CrabGameCheat.Modules
{
    [CheatModule]
    public class OwnerHighlightModule : SingleElementModule<ToggleInfo>
    {

        private Chams chams;

        public OwnerHighlightModule(ClickGUI gui) : base("Owner Highlight", gui, WindowIDs.RENDER)
        {
        }

        public override void Init(ClickGUI gui, bool json = false)
        {
            base.Init(gui, json);
            chams = new Chams();
        }

        public override ElementInfo CreateElement(int windowId)
        {
            Element = new ToggleInfo(windowId, Name, false, true);

            Element.ToggleChanged += Element_ToggleChanged;

            return Element;
        }

        private void Element_ToggleChanged(bool toggled)
        {

            if(!InGame && toggled)
            {
                Element.SetValue(false);
                return;
            }

            if(InGame)
            {
                if (toggled)
                    chams.ChamTargets(new Component[] { FindOwner() }, new Color(1F, 0.5333F, 0F));
                else
                    chams.UnChamTargets();
            }
        }

        private static PlayerManager FindOwner()
        {
            var players = GameManager.Instance.activePlayers;

            if (players.ContainsKey(SteamManager.Instance.lobbyOwnerSteamId.m_SteamID))
            {
                return GameManager.Instance.activePlayers[SteamManager.Instance.lobbyOwnerSteamId.m_SteamID];
            }
            else
                return null;
        }

    }
}
