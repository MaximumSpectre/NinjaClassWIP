using NinjaClass.NPCs;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NinjaClass.Buffs
{
	// Ethereal Flames is an example of a buff that causes constant loss of life.
	// See ExamplePlayer.UpdateBadLifeRegen and ExampleGlobalNPC.UpdateLifeRegen for more information.
	public class NinjaEvaded : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Evaded");
			Description.SetDefault("Sucessfuly Dodged Attack");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = true;
			longerExpertDebuff = false;
		}

		public override void Update(Player player, ref int buffIndex) {
			player.GetModPlayer<NinjaPlayer>().NinjaEvaded = true;
			player.buffImmune[BuffID.OgreSpit] = true;
			player.buffImmune[BuffID.WitheredWeapon] = true;
			player.buffImmune[BuffID.WitheredArmor] = true;
			player.buffImmune[BuffID.Obstructed] = true;
			player.buffImmune[BuffID.ShadowFlame] = true;
			player.buffImmune[BuffID.Webbed] = true;
			player.buffImmune[BuffID.Rabies] = true;
			player.buffImmune[BuffID.Electrified] = true;
			player.buffImmune[BuffID.Blackout] = true;
			player.buffImmune[BuffID.Venom] = true;
			player.buffImmune[BuffID.Ichor] = true;
			player.buffImmune[BuffID.Frozen] = true;
			player.buffImmune[BuffID.Chilled] = true;
			player.buffImmune[BuffID.Frostburn] = true;
			player.buffImmune[BuffID.CursedInferno] = true;
			player.buffImmune[BuffID.BrokenArmor] = true;
			player.buffImmune[BuffID.Silenced] = true;
			player.buffImmune[BuffID.Weak] = true;
			player.buffImmune[BuffID.Slow] = true;
			player.buffImmune[BuffID.Confused] = true;
			player.buffImmune[BuffID.Bleeding] = true;
			player.buffImmune[BuffID.Cursed] = true;
			player.buffImmune[BuffID.Darkness] = true;
			player.buffImmune[BuffID.Poisoned] = true;
			player.buffImmune[BuffID.OnFire] = true;
		}
	}
}
