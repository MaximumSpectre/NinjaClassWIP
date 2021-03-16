using NinjaClass.NPCs;
using Terraria;
using Terraria.ModLoader;
using NinjaClass.Items;

namespace NinjaClass.Buffs
{
	// This is what removes the buff afer the player attacks
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
