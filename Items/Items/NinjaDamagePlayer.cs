using Terraria;
using Terraria.ModLoader;

namespace NinjaClass.Items
{
	// This class stores necessary player info for our custom damage class, such as damage multipliers and additions to knockback and crit.
	public class NinjaDamagePlayer : ModPlayer
	{
		public static NinjaDamagePlayer ModPlayer(Player player) {
			return player.GetModPlayer<NinjaDamagePlayer>();
		}

		// Vanilla only really has damage multipliers in code
		// And crit and knockback is usually just added to
		// As a modder, you could make separate variables for multipliers and simple addition bonuses
		public float NinjaDamageAdd;
		public float NinjaDamageMult = 1f;
		public float NinjaKnockback;
		public int NinjaCrit;

		public override void ResetEffects() {
			ResetVariables();
		}

		public override void UpdateDead() {
			ResetVariables();
		}

		private void ResetVariables() {
			NinjaDamageAdd = 0f;
			NinjaDamageMult = 1f;
			NinjaKnockback = 0f;
			NinjaCrit = 0;
		}
	}
}
