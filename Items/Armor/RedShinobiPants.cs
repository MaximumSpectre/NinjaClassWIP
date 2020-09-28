using NinjaClass.Items;
using NinjaClass.Items.Armor;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace NinjaClass.Items.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	public class RedShinobiPants : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("6% increased movement speed" +
				"\n4% increased ninja critical strike chance");

		}

		public override void SetDefaults() {
			item.width = 18;
			item.height = 18;
			item.value = 10000;
			item.rare = 1;
			item.defense = 6;
		}

		public override void UpdateEquip(Player player) {
			player.moveSpeed += 0.06f;
			NinjaDamagePlayer.ModPlayer(player).NinjaCrit += 4;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemType<ShinobiPants>(), 1);
			recipe.AddIngredient(ItemID.Bone, 40);
			recipe.AddIngredient(ItemID.HellstoneBar, 10);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}