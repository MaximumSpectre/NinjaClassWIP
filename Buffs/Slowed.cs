using NinjaClass.NPCs;
using Terraria;
using Terraria.ModLoader;

namespace NinjaClass.Buffs
{
	// Ethereal Flames is an example of a buff that causes constant loss of life.
	// See ExamplePlayer.UpdateBadLifeRegen and ExampleGlobalNPC.UpdateLifeRegen for more information.
	public class Slowed : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Slowed");
			Description.SetDefault("Slowed");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = true;
			longerExpertDebuff = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			player.GetModPlayer<NinjaPlayer>().Slowed = true;
		}

		public override void Update(NPC npc, ref int buffIndex) {
			npc.GetGlobalNPC<NinjaGlobalNPC>().Slowed = true;
		}
	}
}
