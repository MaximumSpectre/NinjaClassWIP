using Terraria;
using Terraria.ModLoader;

namespace NinjaClass.Prefixes
{
    public class SharpPrefix : ModPrefix
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Sharp");
        }


        public override void Apply(Item item)
        {
            item.damage = (int)(item.damage * 1.1f);
        }
    }
}