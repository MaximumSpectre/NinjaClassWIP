using Terraria;
using Terraria.ModLoader;

namespace NinjaClass.Prefixes
{
    public class HonedPrefix : ModPrefix
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Honed");
        }


        public override void Apply(Item item)
        {
            item.damage = (int)(item.damage * 1.05f);
            item.shootSpeed = (item.shootSpeed * 1.1f);
        }

    }
}