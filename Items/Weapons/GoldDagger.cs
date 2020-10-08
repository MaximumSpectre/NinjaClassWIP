<<<<<<< HEAD
using NinjaClass.Projectiles;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using NinjaClass.Projectiles.PreMega;

namespace NinjaClass.Items.Weapons
{
	// This class handles everything for our custom damage class
	// Any class that we wish to be using our custom damage class will derive from this class, instead of ModItem
	public class GoldDagger : NinjaItem
	{
		// Custom items should override this to set their defaults
		public virtual void SafeSetDefaults()
		{
			item.shootSpeed = 10.5f;
			item.damage = 16;
			item.knockBack = 3.2f;
			item.useStyle = 1;
			item.useAnimation = 25;
			item.useTime = 25;
			item.width = 30;
			item.height = 30;
			item.maxStack = 1;
			item.rare = 0;

			item.consumable = false;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.autoReuse = true;
			item.thrown = true;

			item.UseSound = SoundID.Item1;
			item.value = Item.sellPrice(silver: 5);
			// Look at the javelin projectile for a lot of custom code
			// If you are in an editor like Visual Studio, you can hold CTRL and Click ExampleJavelinProjectile
			item.shoot = ProjectileType<GoldDaggerProjectile>();
		}

		public sealed override void SetDefaults()
		{
			SafeSetDefaults();
			// all vanilla damage types must be false for custom damage types to work

		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.GoldBar, 8);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		public override bool AltFunctionUse(Player player)
		{
			if (player.HasBuff(mod.BuffType("NinjaExausted")))
			{
				return false;
			}
			else
			{
				return true;
			}
		}

		public override bool CanUseItem(Player player)
		{
			if (player.altFunctionUse == 2)
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
						//dust.noGravity = true;
					}
				}
				item.shoot = ProjectileID.None;


			}
			else if (player.HasBuff(mod.BuffType("MegaAttack")))
			{
				item.shootSpeed = 10.5f;
				item.shootSpeed = item.shootSpeed * 1.2f;
				item.knockBack = 3.2f;
				item.knockBack = item.knockBack * 2;
				item.shoot = ProjectileType<GoldDaggerProjectileMega>();
				player.AddBuff(BuffType<Buffs.CMegaAttack>(), 1);
			}
			else
			{
				item.shootSpeed = 10.5f;
				item.knockBack = 3.2f;
				item.shoot = ProjectileType<GoldDaggerProjectile>();
			}
			return base.CanUseItem(player);
		}

		public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
		{
			if (player.altFunctionUse == 2) { }
		}
	}
}
=======
using NinjaClass.Projectiles;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace NinjaClass.Items.Weapons
{
	// This class handles everything for our custom damage class
	// Any class that we wish to be using our custom damage class will derive from this class, instead of ModItem
	public class GoldDagger : NinjaItem
	{
		// Custom items should override this to set their defaults
		public virtual void SafeSetDefaults()
		{
			item.shootSpeed = 10.5f;
			item.damage = 16;
			item.knockBack = 3.2f;
			item.useStyle = 1;
			item.useAnimation = 25;
			item.useTime = 25;
			item.width = 30;
			item.height = 30;
			item.maxStack = 1;
			item.rare = 0;

			item.consumable = false;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.autoReuse = true;
			item.thrown = true;

			item.UseSound = SoundID.Item1;
			item.value = Item.sellPrice(silver: 5);
			// Look at the javelin projectile for a lot of custom code
			// If you are in an editor like Visual Studio, you can hold CTRL and Click ExampleJavelinProjectile
			item.shoot = ProjectileType<GoldDaggerProjectile>();
		}

		public sealed override void SetDefaults()
		{
			SafeSetDefaults();
			// all vanilla damage types must be false for custom damage types to work

		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.GoldBar, 8);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
>>>>>>> 2e4c00c0055e316f7cfaaca6aa2fe5ef117570c9
