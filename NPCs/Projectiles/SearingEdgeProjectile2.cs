using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace NinjaClass.Projectiles
{
	public class SearingEdgeProjectile2 : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Explosion");
		}

		public override void SetDefaults()
		{
			projectile.width = 100;
			projectile.height = 100;
			projectile.friendly = true;
			projectile.thrown = true;
			projectile.penetrate = -1;
			projectile.hide = true;
			projectile.alpha = 0;
			projectile.tileCollide = false;
			//projectile.usesLocalNPCImmunity = true;
			//projectile.localNPCHitCooldown = 30;
		}
		public override void Kill(int timeLeft)
		{
			Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y); // Play a death sound

			// Declaring a constant in-line is fine as it will be optimized by the compiler
			// It is however recommended to define it outside method scope if used elswhere as well
			// They are useful to make numbers that don't change more descriptive

			// Spawn some dusts upon javelin death
			// Fire Dust spawn
			for (int i = 0; i < 15; i++)
			{
				int dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 6, 0f, 0f, 100, default(Color), 3f);
				Main.dust[dustIndex].noGravity = true;
				Main.dust[dustIndex].velocity *= 1.2f;
				dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 6, 0f, 0f, 100, default(Color), 2f);
				Main.dust[dustIndex].velocity *= 1.4f;
				Main.dust[dustIndex].noGravity = true;
			}
		}

		public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
		{
		}


		// Added these 2 constant to showcase how you could make AI code cleaner by doing this
		// Change this number if you want to alter how long the javelin can travel at a constant speed

		// Change this number if you want to alter how the alpha changes
		int deathCount = 0;
		public override void AI()
		{
			projectile.damage = Convert.ToInt32(projectile.damage * 0.5f);

			// Run either the Sticky AI or Normal AI
			// Separating into different methods helps keeps your AI clean
			NormalAI();
		}

		private void NormalAI()
		{
			deathCount++;
			if (deathCount >= 3)
			{
				projectile.Kill();
			}
		}
	}
}