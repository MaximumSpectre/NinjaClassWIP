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
	public class WoodenDagger : NinjaItem
	{
		public float shootingSpeed = 9f;
		public int damage = 7;
		public float knockBack = 1.2f;
		public int useStyle = 1;
		public int useAnimation = 30;
		public int useTime = 30;
		public int width = 30;
		public int height = 30;
		public int maxStack = 1;
		public int rare = 0;

		// Custom items should override this to set their defaults
		public virtual void SafeSetDefaults()
		{
			item.shootSpeed = shootingSpeed;
			item.damage = damage;
			item.knockBack = knockBack;
			item.useStyle = useStyle;
			item.useAnimation = useAnimation;
			item.useTime = useTime;
			item.width = width;
			item.height = height;
			item.rare = rare;

			item.maxStack = 1;
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
				if (player.HasBuff(mod.BuffType("NinjaExausted"))) {

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

			} else if (player.HasBuff(mod.BuffType("MegaAttack")))
			{
				item.shootSpeed = shootingSpeed;
				item.shootSpeed = item.shootSpeed * 1.2f;
				item.knockBack = knockBack;
				item.knockBack = item.knockBack * 2;
				item.shoot = ProjectileType<WoodenDaggerProjectileMega>();
				player.AddBuff(BuffType<Buffs.CMegaAttack>(), 1);
			}
            else
            {
				item.shootSpeed = shootingSpeed;
				item.knockBack = knockBack;
				item.shoot = ProjectileType<WoodenDaggerProjectile>();
			}
			return base.CanUseItem(player);
		}

		public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
		{
			if (player.altFunctionUse == 2) { }
		}
		// As a modder, you could also opt to make these overrides also sealed. Up to the modder
	}
}
