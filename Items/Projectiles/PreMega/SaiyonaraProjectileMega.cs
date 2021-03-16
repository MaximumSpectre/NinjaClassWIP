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
	internal class SaiyonaraProjectileMega : ModProjectile
	{
		public override void SetDefaults() {
			// while the sprite is actually bigger than 15x15, we use 15x15 since it lets the projectile clip into tiles as it bounces. It looks better.
			projectile.width = 28;
			projectile.height = 28;
			projectile.friendly = true;
			projectile.thrown = true;
			projectile.penetrate = 8;
			projectile.usesLocalNPCImmunity = true;
			projectile.localNPCHitCooldown = 20;
			// 5 second fuse.
			projectile.timeLeft = 400;

			// These 2 help the projectile hitbox be centered on the projectile sprite.

		}
		int bounces;

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			// OnTileCollide can trigger quite quickly, so using soundDelay helps prevent the sound from overlapping too much.
			bounces++;

			// This code makes the projectile very bouncy.
			if (projectile.velocity.X != oldVelocity.X && Math.Abs(oldVelocity.X) > 1f)
			{
				projectile.velocity.X = oldVelocity.X * -0.98f;
			}
			if (projectile.velocity.Y != oldVelocity.Y && Math.Abs(oldVelocity.Y) > 1f)
			{
				projectile.velocity.Y = oldVelocity.Y * -0.98f;
			}
			Vector2 center;
			float angle;
			Vector2 tar;
			for (int i = 0; i < 3; i++)
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
				tar *= 8; // speed
						  //tar.X -= (tar.X / 2) * 2  ;
						  //Projectile.NewProjectile(center.X, center.Y, tar.X, tar.Y, mod.ProjectileType("FrostShankProjectile"), (int)(damage * 0.50f), knockback, projectile.owner, 0f, 0f);
				if (projectile.owner == Main.myPlayer)
				{
					Projectile.NewProjectile(center.X, center.Y, tar.X, tar.Y, mod.ProjectileType("SaiyonaraProjectile2"), (int)(rawDamage * 0.20f), projectile.knockBack, projectile.owner, 0f, 0f);
				}
			}
			return false;
		}

		public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough)
		{
			width = height = 14;
			fallThrough = false;
			return true;
		}
		int timer;
		int firstframe;
		int rawDamage;
		public override void AI() {
			if (firstframe == 0)
			{
				
				firstframe = 1;
				projectile.damage *= 5;
				rawDamage = projectile.damage;
				projectile.velocity *= 0.5f;
			}
			Vector2 usePos = projectile.position; // Position to use for dusts
			Vector2 rotVector = (projectile.rotation - MathHelper.ToRadians(90f)).ToRotationVector2(); // rotation vector to use for dust velocity
			usePos += rotVector * 16f;
			for (int i = 0; i < 3; i++)
			{
				// Create a new dust
				Dust dust = Dust.NewDustDirect(usePos, projectile.width, projectile.height, 29);
				dust.position = (dust.position + projectile.Center) / 2f;
				dust.velocity += rotVector * 2f;
				dust.velocity *= 0.8f;
				dust.noGravity = true;
				usePos -= rotVector * 8f;
			}
			timer++;
			if (bounces >= 6)
			{
				projectile.Kill();
			}
			if (timer > 60)
			{
				Vector2 center;
				float angle;
				Vector2 tar;
				timer = 0;
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
				tar *= 8; // speed
						  //tar.X -= (tar.X / 2) * 2  ;
						  //Projectile.NewProjectile(center.X, center.Y, tar.X, tar.Y, mod.ProjectileType("FrostShankProjectile"), (int)(damage * 0.50f), knockback, projectile.owner, 0f, 0f);
				if (projectile.owner == Main.myPlayer)
				{
					Projectile.NewProjectile(center.X, center.Y, tar.X, tar.Y, 27, (int)(rawDamage * 0.33f), projectile.knockBack, projectile.owner, 0f, 0f);
				}
			}
			projectile.ai[0] += 1f;
			if (projectile.ai[0] > 5f)
			{
				projectile.ai[0] = 10f;
				// Roll speed dampening.
				if (projectile.velocity.Y == 0f && projectile.velocity.X != 0f)
				{
					projectile.velocity.X = projectile.velocity.X * 0.96f;
					//if (projectile.type == 29 || projectile.type == 470 || projectile.type == 637)
					{
						projectile.velocity.X = projectile.velocity.X * 0.99f;
					}
					if ((double)projectile.velocity.X > -0.01 && (double)projectile.velocity.X < 0.01)
					{
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

		public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
		{
		}


	}
}
