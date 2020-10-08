using NinjaClass.NPCs;
using Terraria;
using Terraria.ModLoader;
using NinjaClass.Items;

namespace NinjaClass.Buffs
{
	// Ethereal Flames is an example of a buff that causes constant loss of life.
	// See ExamplePlayer.UpdateBadLifeRegen and ExampleGlobalNPC.UpdateLifeRegen for more information.
	public class NinjaExpertise : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Ninja Expertise");
			Description.SetDefault("10% more ninja damage");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = true;
			longerExpertDebuff = false;
		}

		public override void Update(Player player, ref int buffIndex) {
			NinjaDamagePlayer.ModPlayer(player).NinjaDamageMult += 0.1f;
			if (player.HasBuff(mod.BuffType("NinjaMastery")))
			{
				player.DelBuff(buffIndex);
				buffIndex--;
			}
		}
	}
}
