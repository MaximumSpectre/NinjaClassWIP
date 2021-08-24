using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using NinjaClass.Buffs;

namespace NinjaClass.Items
{
	public class InstantTechnique : ModItem
	{
        public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Instant Hidden Technique"); 
			Tooltip.SetDefault("Gives you the Hidden Technique buff instantly without having to dodge");
            //it should be noted that the image for this item is a screenshot of a 4chan post edited to have hifumi yamada from danganronpa in place of a royal anthropomorphic ant, which the original poster has chosen for...child-making, i guess. 
		}
		public override void SetDefaults() {
            item.width = 32;
			item.height = 32;
			item.useTime = 30;
			item.useAnimation = 30;
			item.useStyle = 2;
            item.maxStack = 30;
            item.consumable = true;
			item.value = Item.buyPrice(0, 0, 20, 0);
			item.rare = 1;
			item.UseSound = SoundID.Item3;
			item.buffType = ModContent.BuffType<HiddenTechnique>();
			item.buffTime = 1200;
            return;
		}
	}
}