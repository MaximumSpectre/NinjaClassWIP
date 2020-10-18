using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;


namespace NinjaClass.Projectiles.PreMega
{
	public class GingivitisProjectileMega2 : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Enemy");
		}

		public override void SetDefaults()
		{
			projectile.width = 36;
			projectile.height = 67;
			projectile.friendly = true;
			projectile.thrown = true;
			projectile.penetrate = -1;
			//projectile.hide = true;
			projectile.timeLeft = 300;
			projectile.usesLocalNPCImmunity = true;
			projectile.localNPCHitCooldown = -1;
			projectile.tileCollide = false;
		}
		int firstframe = 0;
		public override void AI()
		{
			if (firstframe == 0)
			{
				projectile.damage *= 10;
				
				firstframe = 1;
			}
			projectile.direction = projectile.spriteDirection = projectile.velocity.X > 0f ? 1 : -1;
			projectile.rotation = projectile.velocity.ToRotation() + MathHelper.ToRadians(270f);
			// Since our sprite has an orientation, we need to adjust rotation to compensate for the draw flipping.
		}
	}
}