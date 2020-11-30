using NinjaClass.Items.Accessories;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace NinjaClass.Items
{
    public class AssassinGlobalItem : GlobalItem
    {
        public override void OpenVanillaBag(string context, Player player, int arg)
        {
            if (context == "bossBag") 
            {
                if (arg == ItemID.WallOfFleshBossBag && Main.rand.NextBool(6))
                {
                player.QuickSpawnItem(ItemType<ShinobiEmblem>());
                }

            }
        }
    }
}