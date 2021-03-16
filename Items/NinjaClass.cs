using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using NinjaClass.HotKeys;
using Terraria.UI;
using NinjaClass.UI;
using Terraria;

namespace NinjaClass
{
    public class NinjaClass : Mod
	{
        internal EvasionUI evasionUI;
        public UserInterface evasionInterface;

        public static NinjaClass instance;
        public static Terraria.ModLoader.ModHotKey NinjaEvasion;
        public override void Load()
        {
            // this makes sure that the UI doesn't get opened on the server
            // the server can't see UI, can it? it's just a command prompt
            if (!Main.dedServ)
            {
                evasionUI = new EvasionUI();
                evasionUI.Initialize();
                evasionInterface = new UserInterface();
                evasionInterface.SetState(evasionUI);
            }
            NinjaEvasion = RegisterHotKey("Ninja Evasion", "Q");
            instance = this;
            thoriumLoaded = ModLoader.GetMod("ThoriumMod") != null;
        }
        public override void UpdateUI(GameTime gameTime)
        {
            // it will only draw if the player is not on the main menu
            if (!Main.gameMenu
                && EvasionUI.visible)
            {
                evasionInterface?.Update(gameTime);
            }
        }
        public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
        {
            layers.Add(new LegacyGameInterfaceLayer("Ninja Class: Evasion UI", DrawEvasionUI, InterfaceScaleType.UI));
        }
        private bool DrawEvasionUI()
        {
            // it will only draw if the player is not on the main menu
            if (!Main.gameMenu
                && EvasionUI.visible)
            {
                evasionInterface.Draw(Main.spriteBatch, new GameTime());
            }
            return true;
        }
        public NinjaClass()
        {
            Properties = new ModProperties()
            {
                Autoload = true
            };
        }
        public static bool thoriumLoaded;
        public override void Unload()
        {
            NinjaEvasion = null;
            instance = null;
        }

    }
}