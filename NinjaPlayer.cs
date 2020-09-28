using NinjaClass.Buffs;
using NinjaClass.Items;
using NinjaClass.Projectiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using static Terraria.ModLoader.ModContent;

namespace NinjaClass
{
	// ModPlayer classes provide a way to attach data to Players and act on that data. ExamplePlayer has a lot of functionality related to 
	// several effects and items in ExampleMod. See SimpleModPlayer for a very simple example of how ModPlayer classes work.
	public class NinjaPlayer : ModPlayer
	{
		public bool Wound;
		public bool Rot;
		public bool Slowed;



		public override void ResetEffects()
		{
			Wound = false;
			Rot = false;
			Slowed = false;
		}


		public override void UpdateDead()
		{
			Wound = false;
			Rot = false;
			Slowed = false;
		}

		public override void UpdateBadLifeRegen()
		{
			if (Wound)
			{
				// These lines zero out any positive lifeRegen. This is expected for all bad life regeneration effects.
				if (player.lifeRegen > 0)
				{
					player.lifeRegen = 0;
				}
				player.lifeRegenTime = 0;
				// lifeRegen is measured in 1/2 life per second. Therefore, this effect causes 8 life lost per second.
				player.lifeRegen -= 8;
			}
			if (Rot)
			{
				// These lines zero out any positive lifeRegen. This is expected for all bad life regeneration effects.
				if (player.lifeRegen > 0)
				{
					player.lifeRegen = 0;
				}
				player.lifeRegenTime = 0;
				// lifeRegen is measured in 1/2 life per second. Therefore, this effect causes 8 life lost per second.
				player.lifeRegen -= 18;
			}
		}
	}
}
