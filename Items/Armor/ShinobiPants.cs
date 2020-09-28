using NinjaClass.Items;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace NinjaClass.Items.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	public class ShinobiPants : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("5% increased movement speed" +
				"\n4% increased ninja critical strike chance");

		}

		public override void SetDefaults() {
			item.width = 18;
			item.height = 18;
			item.value = 10000;
			item.rare = 1;
			item.defense = 5;
		}

		public override void UpdateEquip(Player player) {
			player.moveSpeed += 0.05f;
			NinjaDamagePlayer.ModPlayer(player).NinjaCrit += 4;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Granite, 20);
			recipe.AddIngredient(ItemID.DemoniteBar, 15);
			recipe.AddIngredient(ItemID.ShadowScale, 15);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
			ModRecipe recipe2 = new ModRecipe(mod);
			recipe2.AddIngredient(ItemID.Granite, 20);
			recipe2.AddIngredient(ItemID.CrimtaneBar, 15);
			recipe2.AddIngredient(ItemID.TissueSample, 15);
			recipe2.AddTile(TileID.Anvils);
			recipe2.SetResult(this);
			recipe2.AddRecipe();
		}
	}
}