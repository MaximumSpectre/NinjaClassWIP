using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace NinjaClass.Projectiles.PreMega
{
	public class FleshChewerProjectileMega2 : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Blood");
		}

		public override void SetDefaults()
		{
			projectile.width = 10;
			projectile.height = 14;
			projectile.friendly = true;
			projectile.thrown = true;
			projectile.penetrate = 1;
			projectile.aiStyle = 1;
			projectile.usesLocalNPCImmunity = true;
			projectile.localNPCHitCooldown = 10;
		}
        public override void AI()
        {
        Dust dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 5);
        }
        public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
		{
            Main.player[projectile.owner].HealEffect(1);
            Main.player[projectile.owner].statLife += 1;
		}
	}
}