using NinjaClass.Items;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace NinjaClass.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class ShinobiMask : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("5% increased movement speed" +
				"\n6% increased ninja damage");
			
		}

		public override void SetDefaults() {
			item.width = 18;
			item.height = 18;
			item.value = 10000;
			item.rare = 1;
			item.defense = 4;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ItemType<ShinobiShirt>() && legs.type == ItemType<ShinobiPants>();
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "5% increased ninja critical strike chance" +
                "\nShinobi Dash";
			player.dash = 2;
			player.eocDash = 100;
			NinjaDamagePlayer.ModPlayer(player).NinjaCrit += 6;
			/* Here are the individual weapon class bonuses.
			player.meleeDamage -= 0.2f;
			player.thrownDamage -= 0.2f;
			player.rangedDamage -= 0.2f;
			player.magicDamage -= 0.2f;
			player.minionDamage -= 0.2f;
			*/
		}

		public override void DrawHair(ref bool drawHair, ref bool drawAltHair)
		{
			drawHair = true;  //player make so the player hair does not show when the vanity mask is equipped.  add true if you want to show the player hair.
		}

		public override void UpdateEquip(Player player)
		{
			NinjaDamagePlayer.ModPlayer(player).NinjaDamageAdd += 0.06f;
			player.moveSpeed += 0.05f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Granite, 20);
			recipe.AddIngredient(ItemID.DemoniteBar, 10);
			recipe.AddIngredient(ItemID.ShadowScale, 10);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
			ModRecipe recipe2 = new ModRecipe(mod);
			recipe2.AddIngredient(ItemID.Granite, 20);
			recipe2.AddIngredient(ItemID.CrimtaneBar, 10);
			recipe2.AddIngredient(ItemID.TissueSample, 10);
			recipe2.AddTile(TileID.Anvils);
			recipe2.SetResult(this);
			recipe2.AddRecipe();
		}
	}
}