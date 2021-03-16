using Terraria;
using Terraria.ModLoader;

namespace NinjaClass.Prefixes
{
    public class BentPrefix : ModPrefix
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Bent");
        }


        public override void Apply(Item item)
        {
            item.damage = (int)(item.damage * 0.95f);
            item.shootSpeed = (item.shootSpeed * 0.85f);
        }
    }
}