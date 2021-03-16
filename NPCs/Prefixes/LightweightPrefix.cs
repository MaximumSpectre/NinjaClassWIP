using Terraria;
using Terraria.ModLoader;

namespace NinjaClass.Prefixes
{
    public class LightweightPrefix : ModPrefix
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Lightweight");
        }


        public override void Apply(Item item)
        {
            item.damage = (int)(item.damage * 0.90f);
            item.shootSpeed = (item.shootSpeed * 1.1f);
        }
    }
}