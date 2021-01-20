using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.Utilities;
using Terraria.ModLoader;
using System;
using static Terraria.ModLoader.ModContent;
using NinjaClass.Projectiles.HardMega;

namespace NinjaClass.Items.Weapons.Hardmode.Kunai
{
	public class SpiderKunai : NinjaItem
	{
		public string Projectilee = "SpiderKunaiProjectile";           // the main projectile
		public string MegaProjectile = "SpiderKunaiProjectileMega";   // the MEGA projectile
		public override void SetDefaults()
		{
			item.shootSpeed = 16f;// speed of the projectile
			item.damage = 32;// damage of the weapon
			item.knockBack = 4f;// knockback of the weapon
			item.useStyle = ItemUseStyleID.SwingThrow;// the way the player animates
			item.useAnimation = 24;// the time of the throw animation
			item.useTime = 24;// the time between throws
			item.width = 30;// the size of the hitbox
			item.height = 30;// the size of the hitbox
			item.rare = ItemRarityID.LightRed;
			item.maxStack = 1;// the amount you can stack of the item
			item.UseSound = SoundID.Item1;              // the sound that plays when used
			item.value = Item.sellPrice(gold: 2);    // the price of the item
			item.consumable = false;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.autoReuse = true;
            item.crit = 4;
			item.shoot = mod.ProjectileType(Projectilee);
		}
		public override void AddRecipes()
		{
          	  ModRecipe recipe = new ModRecipe(mod);
         	  recipe.AddIngredient(2607, 12);
          	  recipe.AddTile(TileID.WorkBenches);
          	  recipe.SetResult(this);
          	  recipe.AddRecipe();
       	}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if (player.HasBuff(mod.BuffType("HiddenTechnique")))
			{
            int numberProjectiles = 5 + Main.rand.Next(4); // 3 or 4 shots
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(10)); // 20 degree spread.
                // If you want to randomize the speed to stagger the projectiles
                float scale = 1f - (Main.rand.NextFloat() * .15f); //projectileStagger
                perturbedSpeed = perturbedSpeed * scale;
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage * 2, knockBack, player.whoAmI);
            }
            return false;
            }
            else
            {
            int numberProjectiles = 3 + Main.rand.Next(2); // 3 or 4 shots
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(17)); // 20 degree spread.
                // If you want to randomize the speed to stagger the projectiles
                float scale = 1f - (Main.rand.NextFloat() * .15f); //projectileStagger
                perturbedSpeed = perturbedSpeed * scale;
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
            }
			return false;
            }
		}
		public float charge = 0;
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
				item.shoot = mod.ProjectileType(Projectilee);
			}
			return base.CanUseItem(player);
		}
	}
}
