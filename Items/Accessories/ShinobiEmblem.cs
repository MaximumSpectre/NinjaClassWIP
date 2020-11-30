using NinjaClass.Items;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace NinjaClass.Items.Accessories
{
	public class ShinobiEmblem : ModItem
	{
		public override void SetStaticDefaults() {
			base.SetStaticDefaults();
			DisplayName.SetDefault("Shinobi Emblem");
			Tooltip.SetDefault("15% increased ninja damage");
		}

		public override void SetDefaults() {
			item.width = 18;
			item.height = 18;
			item.value = 100000;
			item.rare = 4;
			item.accessory = true;
		}

		public override void UpdateEquip(Player player) {
			NinjaDamagePlayer.ModPlayer(player).NinjaDamageAdd += 0.15f;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(this);
			recipe.AddIngredient(547, 5);
			recipe.AddIngredient(548, 5);
            recipe.AddIngredient(549, 5);
			recipe.AddTile(114);
			recipe.SetResult(935);
			recipe.AddRecipe();
		}
	}
}