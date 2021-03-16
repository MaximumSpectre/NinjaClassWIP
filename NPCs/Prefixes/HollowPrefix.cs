using Terraria;
using Terraria.ModLoader;

namespace NinjaClass.Prefixes
{
    public class HollowPrefix : ModPrefix
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Hollow");
        }


        public override void Apply(Item item)
        {
            item.damage = (int)(item.damage * 0.90f);
            item.shootSpeed = (item.shootSpeed * 1.2f);
            item.useAnimation = (int)(item.useAnimation * 0.95f);
        }
        public override void SetStats(ref float damageMult, ref float knockbackMult, ref float useTimeMult, ref float scaleMult, ref float shootSpeedMult, ref float manaMult, ref int critBonus)
        {
            useTimeMult -= 0.05f;
            knockbackMult -= 0.20f;
        }
    }
}