using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.Utilities;
using Terraria.ModLoader;
using System;
using static Terraria.ModLoader.ModContent;
using NinjaClass.Projectiles.PreMega;

namespace NinjaClass.Items.Weapons
{
	public class WoodenDagger : NinjaItem
	{
		public string Projectile = "WoodenDaggerProjectile";           // the main projectile
		public string MegaProjectile = "WoodenDaggerProjectileMega";   // the MEGA projectile
		public override void SetDefaults()
		{
			item.shootSpeed = 9.8f;// speed of the projectile
			item.damage = 7;// damage of the weapon
			item.knockBack = 1.2f;// knockback of the weapon
			item.useStyle = ItemUseStyleID.SwingThrow;// the way the player animates
			item.useAnimation = 30;// the time of the throw animation
			item.useTime = 30;// the time between throws
			item.width = 26;// the size of the hitbox
			item.height = 26;// the size of the hitbox
			item.rare = ItemRarityID.White;// the amount you can stack of the item
			item.maxStack = 1;// the amount you can stack of the item
			item.UseSound = SoundID.Item1;              // the sound that plays when used
			item.value = Item.sellPrice(silver: 5);    // the price of the item
			item.consumable = false;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType(Projectile);
		}

		/* DO NOT MESS WITH STUFF PAST THIS POINT
		UNLESS YOU'R DOIN SOMETHING UNIQUE*/
		public override bool CanUseItem(Player player)
		{
			if (player.HasBuff(mod.BuffType("HiddenTechnique")))
			{
				item.shoot = mod.ProjectileType(MegaProjectile);
				player.AddBuff(BuffType<Buffs.CHiddenTechnique>(), 1);
			}
			else
			{
				item.shoot = mod.ProjectileType(Projectile);
			}
			return base.CanUseItem(player);
		}
	}
}
