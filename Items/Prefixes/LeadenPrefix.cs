using Terraria;
using Terraria.ModLoader;

namespace NinjaClass.Prefixes
{
    public class LeadenPrefix : ModPrefix
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Leaden");
        }


        public override void Apply(Item item)
        {
            item.damage = (int)(item.damage * 1.20f);
            item.shootSpeed = (item.shootSpeed * 0.8f);
        }
        public override void SetStats(ref float damageMult, ref float knockbackMult, ref float useTimeMult, ref float scaleMult, ref float shootSpeedMult, ref float manaMult, ref int critBonus)
        {
            knockbackMult += 0.15f;
        }
    }
}