using Terraria;
using Terraria.ModLoader;

namespace NinjaClass.Prefixes
{
    public class ChippedPrefix : ModPrefix
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Chipped");
        }


        public override void Apply(Item item)
        {
            item.damage = (int)(item.damage * 0.95f);

            item.crit -= 5;
        }
        public override void SetStats(ref float damageMult, ref float knockbackMult, ref float useTimeMult, ref float scaleMult, ref float shootSpeedMult, ref float manaMult, ref int critBonus)
        {
            knockbackMult -= 0.05f;
        }
    }
}