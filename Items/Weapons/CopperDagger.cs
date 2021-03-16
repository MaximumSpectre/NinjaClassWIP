using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.Utilities;
using Terraria.ModLoader;
using System;
using static Terraria.ModLoader.ModContent;
using NinjaClass.Projectiles.PreMega;

namespace NinjaClass.Items.Weapons
{
    public class CopperDagger : NinjaItem
    {
        public string Projectile = "CopperDaggerProjectile";           // the main projectile
        public string MegaProjectile = "CopperDaggerProjectileMega";   // the MEGA projectile
        public override void SetDefaults()
        {
            item.shootSpeed = 9.8f;// speed of the projectile
            item.damage = 8;// damage of the weapon
            item.knockBack = 2f;// knockback of the weapon
            item.useStyle = ItemUseStyleID.SwingThrow;// the way the player animates
            item.useAnimation = 28;// the time of the throw animation
            item.useTime = 28;// the time between throws
            item.width = 30;// the size of the hitbox
            item.height = 30;// the size of the hitbox
            item.rare = ItemRarityID.White;// the amount you can stack of the item
            item.maxStack = 1;// the amount you can stack of the item
            item.UseSound = SoundID.Item1;              // the sound that plays when used
            item.value = Item.sellPrice(silver: 2);    // the price of the item
            item.consumable = false;
            item.noUseGraphic = true;
            item.noMelee = true;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType(Projectile);
        }
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Hidden Technique: Throw a glowing dagger that\nhas increased velocity, range and does 8x damage");
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CopperBar, 8);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        public override bool CanUseItem(Player player)
        {
            if (player.HasBuff(mod.BuffType("HiddenTechnique")))
            {
                item.shoot = mod.ProjectileType(MegaProjectile);
                player.AddBuff(BuffType<Buffs.CHiddenTechnique>(), 1);
            }
            else
            {
                item.shoot = mod.ProjectileType(Projectile);
            }
            return base.CanUseItem(player);
        }
    }
}