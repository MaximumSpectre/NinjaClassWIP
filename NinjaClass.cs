using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using NinjaClass.HotKeys;

namespace NinjaClass
{
	public class NinjaClass : Mod
	{
		public static NinjaClass instance;
        public static Terraria.ModLoader.ModHotKey NinjaEvasion;

        public NinjaClass()
        {
            Properties = new ModProperties()
            {
                Autoload = true
            };
        }
        public static bool thoriumLoaded;
        public override void Load()
        {
            NinjaEvasion = RegisterHotKey("Ninja Evasion", "Q");
            instance = this;
            thoriumLoaded = ModLoader.GetMod("ThoriumMod") != null;
        }
        public override void Unload()
        {
            NinjaEvasion = null;
            instance = null;
        }

    }
}