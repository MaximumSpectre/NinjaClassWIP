using NinjaClass.NPCs;
using Terraria;
using Terraria.ModLoader;

namespace NinjaClass.Buffs
{
	// Ethereal Flames is an example of a buff that causes constant loss of life.
	// See ExamplePlayer.UpdateBadLifeRegen and ExampleGlobalNPC.UpdateLifeRegen for more information.
	public class NinjaExhausted : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Exhausted");
			Description.SetDefault("You are too exhausted to evade");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = true;
			longerExpertDebuff = false;
		}

		public override void Update(Player player, ref int buffIndex) {
			
		}
	}
}
