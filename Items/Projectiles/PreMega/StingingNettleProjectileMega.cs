using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.GameContent.Achievements;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace NinjaClass.Projectiles.PreMega
{
	// to investigate: Projectile.Damage, (8843)
	internal class StingingNettleProjectileMega : ModProjectile
	{
		public override void SetDefaults() {
			// while the sprite is actually bigger than 15x15, we use 15x15 since it lets the projectile clip into tiles as it bounces. It looks better.
			projectile.width = 20;
			projectile.height = 20;
			projectile.friendly = true;
			projectile.thrown = true;
			projectile.penetrate = 1;

			// 5 second fuse.
			projectile.timeLeft = 60;

			// These 2 help the projectile hitbox be centered on the projectile sprite.

		}


		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			// OnTileCollide can trigger quite quickly, so using soundDelay helps prevent the sound from overlapping too much.


			// This code makes the projectile very bouncy.
			if (projectile.velocity.X != oldVelocity.X && Math.Abs(oldVelocity.X) > 1f)
			{
				projectile.velocity.X = oldVelocity.X * -0.6f;
			}
			if (projectile.velocity.Y != oldVelocity.Y && Math.Abs(oldVelocity.Y) > 1f)
			{
				projectile.velocity.Y = oldVelocity.Y * -0.6f;
			}
			return false;
		}

		public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough)
		{
			width = height = 14;
			fallThrough = false;
			return true;
		}
		int firstframe = 0;
		public override void AI() {

			if (firstframe == 0)
			{
				projectile.velocity *= 0.60f;
				projectile.damage *= 4;
				firstframe = 1;
			}

			projectile.ai[0] += 1f;
			if (projectile.ai[0] > 5f) {
				projectile.ai[0] = 10f;
				// Roll speed dampening.
				if (projectile.velocity.Y == 0f && projectile.velocity.X != 0f) {
					projectile.velocity.X = projectile.velocity.X * 0.96f;
					//if (projectile.type == 29 || projectile.type == 470 || projectile.type == 637)
					{
						projectile.velocity.X = projectile.velocity.X * 0.98f;
					}
					if ((double)projectile.velocity.X > -0.01 && (double)projectile.velocity.X < 0.01) {
						projectile.velocity.X = 0f;
						projectile.netUpdate = true;
					}
				}
				projectile.velocity.Y = projectile.velocity.Y + 0.2f;
			}
			// Rotation increased by velocity.X 
			projectile.rotation += projectile.velocity.X * 0.02f;
			return;
		}
		bool hasSpawned = false;
		public override void Kill(int timeLeft)
		{
			Main.PlaySound(SoundID.Item15, projectile.position);
			// Smoke Dust spawn
			for (int i = 0; i < 50; i++)
			{
				int dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 31, 0f, 0f, 100, default(Color), 2f);
				Main.dust[dustIndex].velocity *= 1.4f;
			}
			Vector2 center;
			float angle;
			Vector2 tar;
			if (hasSpawned == false)
			{
				hasSpawned = true;
				for (int i = 0; i < (Main.rand.Next(4) + 10); i++)
				{
					// Where dagger appears
					angle = Main.rand.Next(360) * 0.0174f;
					//center.X += (float)System.Math.Sin(angle) * 200;
					//center.Y += (float)System.Math.Cos(angle) * 200;

					center.X = projectile.position.X;
					center.Y = projectile.position.Y;

					tar.X = projectile.position.X;
					tar.Y = projectile.position.Y;

					tar.Normalize();
					tar.X += (float)System.Math.Sin(angle) * 200;
					tar.Y += (float)System.Math.Cos(angle) * 200;
					tar.Normalize();
					tar *= 2; // speed
								  //tar.X -= (tar.X / 2) * 2  ;
								  //Projectile.NewProjectile(center.X, center.Y, tar.X, tar.Y, mod.ProjectileType("FrostShankProjectile"), (int)(damage * 0.50f), knockback, projectile.owner, 0f, 0f);
					if (Main.rand.Next(4) == 0)
					{
						Projectile.NewProjectile(center.X, center.Y, tar.X, tar.Y, ProjectileID.GiantBee, (int)(projectile.damage * 0.65f), projectile.knockBack, projectile.owner, 0f, 0f);
					}
					else
					{
						Projectile.NewProjectile(center.X, center.Y, tar.X, tar.Y, ProjectileID.Bee, (int)(projectile.damage * 0.50f), projectile.knockBack, projectile.owner, 0f, 0f);
					}
				}  // last 0f,0f, this is projectile.ai[0] and projectile.ai[1] where you can put timer, angle, or the target.a
			}
			base.Kill(timeLeft);
		}
	}
}
