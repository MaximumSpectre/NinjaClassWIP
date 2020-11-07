using NinjaClass.NPCs;
using Terraria;
using Terraria.ModLoader;
using NinjaClass.Items;

namespace NinjaClass.Buffs
{
	// Ethereal Flames is an example of a buff that causes constant loss of life.
	// See ExamplePlayer.UpdateBadLifeRegen and ExampleGlobalNPC.UpdateLifeRegen for more information.
	public class CHiddenTechnique : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("You shouldnt be seing this");
			Description.SetDefault("hello world");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = true;
			longerExpertDebuff = false;
		}

		public override void Update(Player player, ref int buffIndex) {
			player.DelBuff(buffIndex);
			buffIndex--;
		}
	}
}
