using NinjaClass.Items;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace NinjaClass.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class DesertMask : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("2% increased movement speed" +
				"\n3% increased ninja damage");
			
		}

		public override void SetDefaults() {
			item.width = 18;
			item.height = 18;
			item.value = 10000;
			item.rare = 0;
			item.defense = 3;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ItemType<DesertShirt>() && legs.type == ItemType<DesertPants>();
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "desert double jump";
			player.doubleJumpSandstorm = true;
			player.GetModPlayer<NinjaPlayer>().NinjaItemWorn = true;
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
			NinjaDamagePlayer.ModPlayer(player).NinjaDamageAdd += 0.03f;
			player.moveSpeed += 0.02f;

		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.SandBlock, 15);
			recipe.AddIngredient(ItemID.AntlionMandible, 1);
			recipe.AddIngredient(ItemID.Silk, 5);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}