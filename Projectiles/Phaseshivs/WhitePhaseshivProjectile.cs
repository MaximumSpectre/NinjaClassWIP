﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace NinjaClass.Projectiles.Phaseshivs
{
	public class WhitePhaseshivProjectile : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Shiv");
		}

		public override void SetDefaults()
		{
			projectile.width = 16;
			projectile.height = 16;
			projectile.friendly = true;
			projectile.thrown = true;
			projectile.penetrate = 3;
			projectile.hide = true;
		}

		// See ExampleBehindTilesProjectile. 
		public override void DrawBehind(int index, List<int> drawCacheProjsBehindNPCsAndTiles, List<int> drawCacheProjsBehindNPCs, List<int> drawCacheProjsBehindProjectiles, List<int> drawCacheProjsOverWiresUI)
		{
			// If attached to an NPC, draw behind tiles (and the npc) if that NPC is behind tiles, otherwise just behind the NPC.
			if (projectile.ai[0] == 1f) // or if(isStickingToTarget) since we made that helper method.
			{
				int npcIndex = (int)projectile.ai[1];
				if (npcIndex >= 0 && npcIndex < 200 && Main.npc[npcIndex].active)
				{
					if (Main.npc[npcIndex].behindTiles)
					{
						drawCacheProjsBehindNPCsAndTiles.Add(index);
					}
					else
					{
						drawCacheProjsBehindNPCs.Add(index);
					}

					return;
				}
			}
			// Since we aren't attached, add to this list
			drawCacheProjsBehindProjectiles.Add(index);
		}

		public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough)
		{
			// For going through platforms and such, javelins use a tad smaller size
			width = height = 10; // notice we set the width to the height, the height to 10. so both are 10
			return true;
		}

		public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
		{
			// Inflate some target hitboxes if they are beyond 8,8 size
			if (targetHitbox.Width > 8 && targetHitbox.Height > 8)
			{
				targetHitbox.Inflate(-targetHitbox.Width / 8, -targetHitbox.Height / 8);
			}
			// Return if the hitboxes intersects, which means the javelin collides or not
			return projHitbox.Intersects(targetHitbox);
		}

		public override void Kill(int timeLeft)
		{
			Main.PlaySound(0, (int)projectile.position.X, (int)projectile.position.Y); // Play a death sound
			Vector2 usePos = projectile.position; // Position to use for dusts

			// Please note the usage of MathHelper, please use this!
			// We subtract 90 degrees as radians to the rotation vector to offset the sprite as its default rotation in the sprite isn't aligned properly.
			Vector2 rotVector = (projectile.rotation - MathHelper.ToRadians(90f)).ToRotationVector2(); // rotation vector to use for dust velocity
			usePos += rotVector * 16f;

			// Declaring a constant in-line is fine as it will be optimized by the compiler
			// It is however recommended to define it outside method scope if used elswhere as well
			// They are useful to make numbers that don't change more descriptive
			const int NUM_DUSTS = 5;

			// Spawn some dusts upon javelin death
			for (int i = 0; i < NUM_DUSTS; i++)
			{
				// Create a new dust
				Dust dust = Dust.NewDustDirect(usePos, projectile.width, projectile.height, 81);
				dust.position = (dust.position + projectile.Center) / 2f;
				dust.velocity += rotVector * 2f;
				dust.velocity *= 0.5f;
				dust.noGravity = true;
				usePos -= rotVector * 8f;
			}
		}
		public int TargetWhoAmI
		{
			get => (int)projectile.ai[1];
			set => projectile.ai[1] = value;
		}

		public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
		{
			TargetWhoAmI = target.whoAmI; // Set the target whoAmI
			projectile.netUpdate = true; // netUpdate this javelin
		}

		private const int MAX_TICKS = 4;

		// Change this number if you want to alter how the alpha changes
		private const int ALPHA_REDUCTION = 25;
		int deathCount = 0;
		public override void AI()
		{
			UpdateAlpha();
			// Run either the Sticky AI or Normal AI
			// Separating into different methods helps keeps your AI clean
			NormalAI();
			Lighting.AddLight(projectile.Center, 0.95f, 0.95f, 0.95f); // R G B values from 0 to 1f. This is the red from the Crimson Heart pet

		}

		private void UpdateAlpha()
		{
			// Slowly remove alpha as it is present
			if (projectile.alpha > 0)
			{
				projectile.alpha -= ALPHA_REDUCTION;
			}

			// If alpha gets lower than 0, set it to 0
			if (projectile.alpha < 0)
			{
				projectile.alpha = 0;
			}
		}

		private void NormalAI()
		{
			TargetWhoAmI++;
			deathCount++;
			if (deathCount >= 28)
			{
				projectile.Kill();
			}
			// For a little while, the javelin will travel with the same speed, but after this, the javelin drops velocity very quickly.
			if (TargetWhoAmI >= MAX_TICKS)
			{
				// Change these multiplication factors to alter the javelin's movement change after reaching maxTicks
				const float velXmult = 0.99f; // x velocity factor, every AI update the x velocity will be 98% of the original speed
				const float velYmult = 0.04f; // y velocity factor, every AI update the y velocity will be be 0.35f bigger of the original speed, causing the javelin to drop to the ground
				TargetWhoAmI = MAX_TICKS; // set ai1 to maxTicks continuously
				projectile.velocity.X *= velXmult;
				projectile.velocity.Y += velYmult;
			}

			// Make sure to set the rotation accordingly to the velocity, and add some to work around the sprite's rotation
			// Please notice the MathHelper usage, offset the rotation by 90 degrees (to radians because rotation uses radians) because the sprite's rotation is not aligned!

			//projectile.rotation =
			//	projectile.velocity.ToRotation() +
			//	MathHelper.ToRadians(45f);
			projectile.direction = projectile.spriteDirection = projectile.velocity.X > 0f ? 1 : -1;
			projectile.rotation = projectile.velocity.ToRotation() + MathHelper.ToRadians(45f);
			if (projectile.velocity.Y > 16f)
			{
				projectile.velocity.Y = 16f;
			}
			// Since our sprite has an orientation, we need to adjust rotation to compensate for the draw flipping.
			if (projectile.spriteDirection == -1)
			{
				projectile.rotation += (MathHelper.Pi + MathHelper.ToRadians(-90f));
			}

		}
		public override void PostDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			Texture2D texture = mod.GetTexture("Projectiles/Phaseshivs/WhitePhaseshivProjectile_Glow");
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