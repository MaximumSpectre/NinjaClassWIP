using NinjaClass.Items;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace NinjaClass.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class RedShinobiMask : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("3% increased movement speed" +
				"\n8% increased ninja damage");
			
		}

		public override void SetDefaults() {
			item.width = 18;
			item.height = 18;
			item.value = 10000;
			item.rare = 1;
			item.defense = 6;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ItemType<RedShinobiShirt>() && legs.type == ItemType<RedShinobiPants>();
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "7% increased ninja damage" +
                "\nshinobi dash" +
                "\nno fall damage";
			player.dash = 2;
			player.eocDash = 100;
			player.noFallDmg = true;
			player.maxRunSpeed += 1.2f;
			NinjaDamagePlayer.ModPlayer(player).NinjaDamageAdd += 0.07f;
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
			NinjaDamagePlayer.ModPlayer(player).NinjaDamageAdd += 0.08f;
			player.moveSpeed += 0.03f;

		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemType<ShinobiMask>(), 1);
			recipe.AddIngredient(ItemID.Bone, 30);
			recipe.AddIngredient(ItemID.HellstoneBar, 5);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}