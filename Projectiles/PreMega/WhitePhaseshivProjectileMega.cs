using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace NinjaClass.Projectiles.PreMega
{
	public class WhitePhaseshivProjectileMega : ModProjectile
	{
		public int duration = 50;                // the time the projectile stays in the air
		public int penetration = -1;             // how many eneemies the projectile penetrate
		public const float drag = 0.98f;            // the drag of the projectile
		public const float gravity = 0.17f;      // the gravity of the projectile
		public int gravityStrength = 3;         // the strength of of the gravity added per frame, 1 for default
		public int killDust = 88;                   // which dust used when it dies
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Shiv");
		}
		public override void SetDefaults()
		{
			projectile.width = 50;
			projectile.height = 50;
			projectile.friendly = true;
			projectile.thrown = true;
			projectile.penetrate = penetration;
			projectile.tileCollide = false;
			projectile.usesLocalNPCImmunity = true;
			projectile.localNPCHitCooldown = 20;
			
			//projectile.hide = true;
		}
		public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
		{
			if (target.type >= NPCID.EaterofWorldsHead && target.type <= NPCID.EaterofWorldsTail)
			{
				if (Main.expertMode)
				{
					damage /= 2;
				}
				else
				{
					damage = Convert.ToInt32(damage / 1.2f);
				}
					
			}
		}

		int firstframe = 0;
		bool noAI = true;
		public override void AI()
		{
			Lighting.AddLight(projectile.Center, 0.25f, 0.41f, 0.96f);
			if (firstframe == 0)
            {
				projectile.velocity *= 2.4f;
				projectile.damage *= 4;
				firstframe = 1;
			}
			if (projectile.velocity.Y < 5 && projectile.velocity.Y > -5 && projectile.velocity.X < 5 && projectile.velocity.X > -5)
			{
				projectile.aiStyle = 3;
				noAI = false;
			}
			projectile.velocity *= 0.955f;
			if (noAI)
			{
				projectile.rotation += 0.4f * (float)projectile.direction;
			}
		}
		public override void PostDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			Texture2D texture = mod.GetTexture("Projectiles/PreMega/WhitePhaseshivProjectileMega_Glow");
			spriteBatch.Draw
			(
				texture,
				projectile.position,
				new Rectangle(0, 0, texture.Width, texture.Height),
				Color.White,
				projectile.rotation,
				texture.Size() * 0.5f,
				projectile.scale,
				SpriteEffects.None,
				0f
			);
		}
	}
}
