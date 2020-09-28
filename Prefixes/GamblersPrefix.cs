using Terraria;
using Terraria.ModLoader;

namespace NinjaClass.Prefixes
{
    public class GamblersPrefix : ModPrefix
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Gambler's");
        }


        public override void Apply(Item item)
        {
            item.crit += 15;
        }
    }
}