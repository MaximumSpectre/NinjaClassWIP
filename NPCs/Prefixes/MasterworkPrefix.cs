using Terraria;
using Terraria.ModLoader;

namespace NinjaClass.Prefixes
{
    public class MasterworkPrefix : ModPrefix
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Masterwork");
        }


        public override void Apply(Item item)
        {
            item.damage = (int)(item.damage * 1.15f);
            item.shootSpeed = (item.shootSpeed * 1.1f);
            item.useAnimation = (int)(item.useAnimation * 0.95f);
            item.crit += 5;
        }
        public override void SetStats(ref float damageMult, ref float knockbackMult, ref float useTimeMult, ref float scaleMult, ref float shootSpeedMult, ref float manaMult, ref int critBonus)
        {
            useTimeMult -= 0.05f;
            knockbackMult += 0.15f;
        }
    }
}