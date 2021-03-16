using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.Utilities;
using Terraria.ModLoader;
using System;
using static Terraria.ModLoader.ModContent;
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

namespace NinjaClass.Items.Weapons.Phaseshivs
{
	public class YellowPhaseshiv : NinjaItem
	{
		public string Projectile = "YellowPhaseshivProjectile";           // the main projectile
		public string MegaProjectile = "YellowPhaseshivProjectileMega";   // the MEGA projectile
																		// this is where you add the recipie of the item


		public override void SetDefaults()
		{
			item.shootSpeed = 13.5f;// speed of the projectile
			item.damage = 18;// damage of the weapon
			item.knockBack = 1.2f;// knockback of the weapon
			item.useStyle = 1;// the way the player animates
			item.useAnimation = 26;// the time of the throw animation
			item.useTime = 26;// the time between throws
			item.width = 30;// the size of the hitbox
			item.height = 30;// the size of the hitbox
			item.rare = 1;// the amount you can stack of the item
			item.maxStack = 1;// the amount you can stack of the item
			item.UseSound = SoundID.Item1;              // the sound that plays when used
			item.value = Item.sellPrice(silver: 46);    // the price of the item
			item.consumable = false;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType(Projectile);
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.MeteoriteBar, 10);
			recipe.AddIngredient(ItemID.Topaz, 5);
			recipe.AddIngredient(ItemID.FallenStar, 5);
			recipe.AddTile(TileID.Anvils); // the station needed to craft
			recipe.SetResult(this);
			recipe.AddRecipe();
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