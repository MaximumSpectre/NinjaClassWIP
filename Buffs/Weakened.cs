using NinjaClass.NPCs;
using Terraria;
using Terraria.ModLoader;

namespace NinjaClass.Buffs
{
	// Ethereal Flames is an example of a buff that causes constant loss of life.
	// See ExamplePlayer.UpdateBadLifeRegen and ExampleGlobalNPC.UpdateLifeRegen for more information.
	public class Weakened : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Weakened");
			Description.SetDefault("You are weaker and have 20% less armor");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = true;
			longerExpertDebuff = false;
		}

		public override void Update(Player player, ref int buffIndex) {
			player.GetModPlayer<NinjaPlayer>().NinjaWeakened = true;

		}
	}
}
