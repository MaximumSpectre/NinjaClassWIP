using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ModLoader;
using Terraria.Utilities;
using Microsoft.Xna.Framework;
using System;
using static Terraria.ModLoader.ModContent;
using NinjaClass.Items.Weapons.Phaseshivs;
using Mono.Collections.Generic;

namespace NinjaClass.Items
{
    public abstract class NinjaItem : ModItem
    {
        internal Player player;

        public override void SetDefaults()
        {
            item.melee = false;
            item.ranged = false;
            item.magic = false;
            item.thrown = false;
            item.summon = false;
            
        }
        public override int ChoosePrefix(Terraria.Utilities.UnifiedRandom rand)
        {

            var prefixChooser = new WeightedRandom<int>();

            prefixChooser.Add(mod.PrefixType("RustyPrefix"), 2);
            prefixChooser.Add(mod.PrefixType("ChippedPrefix"), 3);
            prefixChooser.Add(mod.PrefixType("LeadenPrefix"), 2);
            prefixChooser.Add(mod.PrefixType("HonedPrefix"), 2);
            prefixChooser.Add(mod.PrefixType("GamblersPrefix"), 2);
            prefixChooser.Add(mod.PrefixType("LightweightPrefix"), 3);
            prefixChooser.Add(mod.PrefixType("WellForgedPrefix"), 2);
            prefixChooser.Add(mod.PrefixType("MasterworkPrefix"), 1);
            prefixChooser.Add(mod.PrefixType("HollowPrefix"), 1);
            prefixChooser.Add(mod.PrefixType("BentPrefix"), 1);
            if (item.damage > 10)
            {
                prefixChooser.Add(mod.PrefixType("SharpPrefix"), 3); // 3 times as likely
            }
            int choice = prefixChooser;
            if ((item.damage > 0) && item.maxStack == 1)
            {
                return choice;
            }
            return -1;
        }

        public override bool ReforgePrice(ref int reforgePrice, ref bool canApplyDiscount)
        {
            return true;
        }

        public override void GetWeaponKnockback(Player player, ref float knockback)
        {
            // Adds knockback bonuses
            knockback += NinjaDamagePlayer.ModPlayer(player).NinjaKnockback;
        }

        public override void ModifyWeaponDamage(Player player, ref float add, ref float mult, ref float flat)
        {
            add += NinjaDamagePlayer.ModPlayer(player).NinjaDamageAdd;
            mult *= NinjaDamagePlayer.ModPlayer(player).NinjaDamageMult;
        }

        public override void GetWeaponCrit(Player player, ref int crit)
        {
            crit = crit + NinjaDamagePlayer.ModPlayer(player).NinjaCrit;
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            // Get the vanilla damage tooltip
            TooltipLine tt = tooltips.FirstOrDefault(x => x.Name == "Damage" && x.mod == "Terraria");
            if (tt != null)
            {
                // We want to grab the last word of the tooltip, which is the translated word for 'damage' (depending on what language the player is using)
                // So we split the string by whitespace, and grab the last word from the returned arrays to get the damage word, and the first to get the damage shown in the tooltip
                string[] splitText = tt.text.Split(' ');
                string damageValue = splitText.First();
                string damageWord = splitText.Last();
                // Change the tooltip text
                tt.text = damageValue + " ninja " + damageWord;
            }
            TooltipLine line = new TooltipLine(mod, "NinjaGear", "-Ninja Class-");
            line.overrideColor = new Color(120, 0, Math.Min(Math.Min(Main.DiscoR + Main.DiscoG, Main.DiscoB + Main.DiscoG), Main.DiscoB + Main.DiscoR)-30);
            //Math.Min(Math.Max((Main.DiscoB + Main.DiscoR + Main.DiscoG)/3, mini), maxi)
            tooltips.Insert(1, line);
        }
    }
}