using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace NinjaClass.Projectiles.PreMega
{
	public class CaltropProjectileMega2 : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Spike");
		}

		public override void SetDefaults()
		{
			projectile.width = 6;
			projectile.height = 10;
			projectile.friendly = true;
			projectile.thrown = true;
			projectile.penetrate = 1;
			projectile.aiStyle = 1;
			projectile.usesLocalNPCImmunity = true;
			projectile.localNPCHitCooldown = 8;
		}
	}
}