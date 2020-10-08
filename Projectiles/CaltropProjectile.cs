using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.GameContent.Achievements;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace NinjaClass.Projectiles
{
	// to investigate: Projectile.Damage, (8843)
	internal class CaltropProjectile : ModProjectile
	{
		public override void SetDefaults() {
			// while the sprite is actually bigger than 15x15, we use 15x15 since it lets the projectile clip into tiles as it bounces. It looks better.
			projectile.width = 14;
			projectile.height = 14;
			projectile.friendly = true;
			projectile.thrown = true;
			projectile.penetrate = 3;

			// 5 second fuse.
			projectile.timeLeft = 1500;

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

		public override void AI() {

			projectile.ai[0] += 1f;
			if (projectile.ai[0] > 5f) {
				projectile.ai[0] = 10f;
				// Roll speed dampening.
				if (projectile.velocity.Y == 0f && projectile.velocity.X != 0f) {
					projectile.velocity.X = projectile.velocity.X * 0.96f;
					//if (projectile.type == 29 || projectile.type == 470 || projectile.type == 637)
					{
						projectile.velocity.X = projectile.velocity.X * 0.99f;
					}
					if ((double)projectile.velocity.X > -0.01 && (double)projectile.velocity.X < 0.01) {
						projectile.velocity.X = 0f;
						projectile.netUpdate = true;
					}
				}
				projectile.velocity.Y = projectile.velocity.Y + 0.2f;
			}
			// Rotation increased by velocity.X 
			projectile.rotation += projectile.velocity.X * 0.1f;
			return;
		}

		public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
		{
			target.AddBuff(BuffType<Buffs.Wound>(), 60);
		}


	}
}
