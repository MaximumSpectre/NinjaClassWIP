using Terraria;
using Terraria.ModLoader;

namespace NinjaClass.Prefixes
{
    public class WellForgedPrefix : ModPrefix
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Well Forged");
        }


        public override void Apply(Item item)
        {
            item.damage = (int)(item.damage * 1.05f);
            item.useAnimation = (int)(item.useAnimation * 0.95f);
        }
        public override void SetStats(ref float damageMult, ref float knockbackMult, ref float useTimeMult, ref float scaleMult, ref float shootSpeedMult, ref float manaMult, ref int critBonus)
        {
            useTimeMult -= 0.05f;
            knockbackMult += 0.10f;
        }
    }
}