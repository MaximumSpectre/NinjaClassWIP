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
		public bool NinjaDodge;
		public bool NinjaEvaded;
		public int NinjaCount;
		public bool NinjaItemWorn;

		public override void ResetEffects()
		{
			Wound = false;
			Rot = false;
			Slowed = false;
			NinjaDodge = false;
			NinjaEvaded = false;
			NinjaItemWorn = false;
		}


		public override void UpdateDead()
		{
			Wound = false;
			Rot = false;
			Slowed = false;
			NinjaDodge = false;
			NinjaEvaded = false;
			NinjaItemWorn = false;
			NinjaCount = 0;
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

		public override bool PreHurt(bool pvp, bool quiet, ref int damage, ref int hitDirection, ref bool crit, ref bool customDamage, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
		{
			if (NinjaEvaded)
			{
				customDamage = true;
				damage = 0;
				
			}
			if (NinjaDodge)
            {
				player.AddBuff(BuffType<Buffs.NinjaEvaded>(), 30);
				
				damage = 0;
				customDamage = true;
				if (NinjaCount > 5)
				{
					NinjaCount = 0;
					if (player.HasBuff(mod.BuffType("NinjaExpertise")))
					{
						player.AddBuff(BuffType<Buffs.NinjaMastery>(), 1800);
					}
					else if (player.HasBuff(mod.BuffType("NinjaMastery")))
					{
						player.AddBuff(BuffType<Buffs.MegaAttack>(), 600);
					}
					else if (player.HasBuff(mod.BuffType("MegaAttack")))
					{
					}
					else
					{
						player.AddBuff(BuffType<Buffs.NinjaExpertise>(), 2400);
					}

				}
			}
			return base.PreHurt(pvp, quiet, ref damage, ref hitDirection, ref crit, ref customDamage, ref playSound, ref genGore, ref damageSource);
		}
		public override void PreUpdateBuffs(){
		}
		public override void ProcessTriggers(TriggersSet triggersSet)
		{
			if (NinjaItemWorn)
            {
				if (NinjaClass.NinjaEvasion.JustPressed)
				{
					if (player.HasBuff(mod.BuffType("NinjaExausted")))
					{
					}
					else
					{
						player.AddBuff(BuffType<Buffs.NinjaDodge>(), 15);
						player.AddBuff(BuffType<Buffs.NinjaExausted>(), 600);
						for (int d = 0; d < 70; d++)
						{
							Dust dust = Dust.NewDustDirect(player.position, player.width, player.height, 31, 0f, 0f, 150, default(Color), 1.6f);
							dust.velocity /= 1.6f;
						}
					}
				}
			}
		}
		public override void PostUpdate()
        {
			NinjaCount++;
        }
	}
}
