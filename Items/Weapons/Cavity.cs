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
	public class Cavity : NinjaItem
	{
		// Custom items should override this to set their defaults
		public virtual void SafeSetDefaults()
		{
			item.shootSpeed = 12.8f;
			item.damage = 17;
			item.knockBack = 1.2f;
			item.useStyle = 1;
			item.useAnimation = 20;
			item.useTime = 20;
			item.width = 30;
			item.height = 30;
			item.maxStack = 1;
			item.rare = 1;

			item.consumable = false;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.autoReuse = true;
			item.thrown = true;

			item.UseSound = SoundID.Item1;
			item.value = Item.sellPrice(silver: 5);
			// Look at the javelin projectile for a lot of custom code
			// If you are in an editor like Visual Studio, you can hold CTRL and Click ExampleJavelinProjectile
			item.shoot = ProjectileType<CavityProjectile>();
		}

		// By making the override sealed, we prevent derived classes from further overriding the method and enforcing the use of SafeSetDefaults()
		// We do this to ensure that the vanilla damage types are always set to false, which makes the custom damage type work
		public sealed override void SetDefaults()
		{
			SafeSetDefaults();
			// all vanilla damage types must be false for custom damage types to work

		}

		// As a modder, you could also opt to make these overrides also sealed. Up to the modder






		// Because we want the damage tooltip to show our custom damage, we need to modify it

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.DemoniteBar, 4);
			recipe.AddIngredient(ItemID.RottenChunk, 8);
			recipe.AddIngredient(ItemID.ShadowScale, 6);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
