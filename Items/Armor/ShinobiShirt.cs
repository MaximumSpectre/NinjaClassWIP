using NinjaClass.Items;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace NinjaClass.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class ShinobiShirt : ModItem
	{
		public override void SetStaticDefaults() {
			base.SetStaticDefaults();
			Tooltip.SetDefault("3% increased movement speed" +
				"\n2% increased ninja critical strike chance" +
                "\nsmall increase to ninja knockback");
		}

		public override void SetDefaults() {
			item.width = 18;
			item.height = 18;
			item.value = 10000;
			item.rare = 1;
			item.defense = 6;
		}

		public override void UpdateEquip(Player player) {
			NinjaDamagePlayer.ModPlayer(player).NinjaCrit += 5;
			NinjaDamagePlayer.ModPlayer(player).NinjaKnockback += 3;
			player.moveSpeed += 0.03f;
		}

		public override void DrawHands(ref bool drawHands, ref bool drawArms)
		{
			drawHands = true;  //player make so the player hair does not show when the vanity mask is equipped.  add true if you want to show the player hair.
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Granite, 25);
			recipe.AddIngredient(ItemID.DemoniteBar, 20);
			recipe.AddIngredient(ItemID.ShadowScale, 20);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
			ModRecipe recipe2 = new ModRecipe(mod);
			recipe2.AddIngredient(ItemID.Granite, 25);
			recipe2.AddIngredient(ItemID.CrimtaneBar, 20);
			recipe2.AddIngredient(ItemID.TissueSample, 20);
			recipe2.AddTile(TileID.Anvils);
			recipe2.SetResult(this);
			recipe2.AddRecipe();
		}

	}
}