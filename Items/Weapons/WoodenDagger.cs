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
	public class WoodenDagger : NinjaItem
	{
		// Custom items should override this to set their defaults
		public virtual void SafeSetDefaults()
		{
			item.shootSpeed = 9f;
			item.damage = 7;
			item.knockBack = 1.2f;
			item.useStyle = 1;
			item.useAnimation = 30;
			item.useTime = 30;
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
			item.shoot = ProjectileType<WoodenDaggerProjectile>();
		}

		// By making the override sealed, we prevent derived classes from further overriding the method and enforcing the use of SafeSetDefaults()
		// We do this to ensure that the vanilla damage types are always set to false, which makes the custom damage type work
		public sealed override void SetDefaults()
		{
			SafeSetDefaults();
			// all vanilla damage types must be false for custom damage types to work
		}

		// As a modder, you could also opt to make these overrides also sealed. Up to the modder
	}
}
