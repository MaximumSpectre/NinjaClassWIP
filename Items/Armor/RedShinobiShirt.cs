using NinjaClass.Items;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace NinjaClass.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class RedShinobiShirt : ModItem
	{
		public override void SetStaticDefaults() {
			base.SetStaticDefaults();
			Tooltip.SetDefault("3% increased movement speed" +
				"\n5% increased ninja critical strike chance" +
                "\nsmall increase to ninja knockback");
		}

		public override void SetDefaults() {
			item.width = 18;
			item.height = 18;
			item.value = 10000;
			item.rare = 1;
			item.defense = 7;
		}

		public override void UpdateEquip(Player player) {
			NinjaDamagePlayer.ModPlayer(player).NinjaCrit += 5;
			NinjaDamagePlayer.ModPlayer(player).NinjaKnockback *= 1.15f;
			player.moveSpeed += 0.03f;
		}
		public override void DrawHands(ref bool drawHands, ref bool drawArms)
		{
			drawHands = true;  //player make so the player hair does not show when the vanity mask is equipped.  add true if you want to show the player hair.
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemType<ShinobiShirt>(), 1);
			recipe.AddIngredient(ItemID.Bone, 50);
			recipe.AddIngredient(ItemID.HellstoneBar, 15);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}