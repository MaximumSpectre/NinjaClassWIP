using Terraria;
using Terraria.ModLoader;

namespace NinjaClass.Prefixes
{
    public class RustyPrefix : ModPrefix
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Rusty");
        }


        public override void Apply(Item item)
        {
            item.damage = (int)(item.damage * 0.9f);
        }
    }
}