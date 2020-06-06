using NinjaClass.Items;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace NinjaClass.Items.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	public class DesertPants : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("4% increased movement speed" +
				"\n5% increased ninja damage");

		}

		public override void SetDefaults() {
			item.width = 18;
			item.height = 18;
			item.value = 10000;
			item.rare = 0;
			item.defense = 4;
		}

		public override void UpdateEquip(Player player) {
			player.moveSpeed += 0.04f;
			NinjaDamagePlayer.ModPlayer(player).NinjaDamageAdd += 0.05f;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.SandBlock, 15);
			recipe.AddIngredient(ItemID.AntlionMandible, 2);
			recipe.AddIngredient(ItemID.Silk, 3);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}