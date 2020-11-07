using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace NinjaClass.Projectiles.Katana
{
	public class LivingWoodKatanaProjectile2 : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			Main.projFrames[projectile.type] = 6;
		}
		public override void SetDefaults()
		{
			projectile.width = 60;
			projectile.height = 60;
			projectile.friendly = true;
			projectile.penetrate = -1;
			projectile.tileCollide = false;
			//projectile.hide = true;
			projectile.ownerHitCheck = true; //so you can't hit enemies through walls
		}

		public override void AI()
		{
			OrbitAI();
			if (++projectile.frameCounter >= 5)
			{
				projectile.frameCounter = 0;
				if (++projectile.frame >= 6)
				{
					projectile.frame = 0;
				}
			}
			//projectile.direction = (projectile.spriteDirection = ((projectile.velocity.X > 0f) ? 1 : -1));
			//projectile.rotation = projectile.velocity.ToRotation();
			/*if (projectile.spriteDirection == -1)
			{
				projectile.rotation += MathHelper.Pi;
			}*/

		}
		private void OrbitAI()
		{
			double deg = .01 * (double)projectile.ai[1]; //The degrees, you can multiply projectile.ai[1] to make it orbit faster, may be choppy depending on the value
			double rad = deg * (Math.PI / 180); //Convert degrees to radians
			rad = projectile.velocity.ToRotation();
			double dist = 50; //Distance away from the player
			//Making player variable "p" set as the projectile's owner
			Player p = Main.player[projectile.owner];
			projectile.ai[1] += 1f;
			/*Position the player based on where the player is, the Sin/Cos of the angle times the /
			/distance for the desired distance away from the player minus the projectile's width   /
			/and height divided by two so the center of the projectile is at the right place.     */
			projectile.position.X = p.Center.X - (int)(Math.Cos(rad) * dist) - projectile.width / 2;
			projectile.position.Y = p.Center.Y - (int)(Math.Sin(rad) * dist) - projectile.height / 2;
			projectile.localAI[0] = 1f;
		}
	}
}