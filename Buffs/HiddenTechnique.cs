using NinjaClass.NPCs;
using Terraria;
using Terraria.ModLoader;
using NinjaClass.Items;

namespace NinjaClass.Buffs
{
	public class HiddenTechnique : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Hidden Technique");
			Description.SetDefault("Your next attack will be a Hidden Technique");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = true;
			longerExpertDebuff = false;
		}

		public override void Update(Player player, ref int buffIndex) {
			if (player.HasBuff(mod.BuffType("CHiddenTechnique")))
			{
				player.DelBuff(buffIndex);
				buffIndex--;
			}
		}
	}
}
