using NinjaClass.NPCs;
using Terraria;
using Terraria.ModLoader;
using NinjaClass.Items;

namespace NinjaClass.Buffs
{
	// Ethereal Flames is an example of a buff that causes constant loss of life.
	// See ExamplePlayer.UpdateBadLifeRegen and ExampleGlobalNPC.UpdateLifeRegen for more information.
	public class DesertWinds : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Desert Winds");
			Description.SetDefault("The desert winds assist your movement");
			Main.debuff[Type] = false;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = true;
			longerExpertDebuff = false;
		}

		public override void Update(Player player, ref int buffIndex) {
			player.moveSpeed *= 1.2f;
			player.maxRunSpeed += 0.6f;
			Player.jumpHeight += 6;
			Player.jumpSpeed *= 1.12f;
		}
	}
}
