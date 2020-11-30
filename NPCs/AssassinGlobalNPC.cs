using Microsoft.Xna.Framework;
using NinjaClass.Buffs;
using NinjaClass.Items.Accessories;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace NinjaClass.NPCs
{
	public class NinjaGlobalNPC : GlobalNPC
	{
		public override bool InstancePerEntity => true;

		public bool Wound;
		public bool Rot;
		public bool Slowed;

		public override void ResetEffects(NPC npc)
		{
			Wound = false;
			Rot = false;
			Slowed = false;
		}

		public override void NPCLoot(NPC npc)
		{
			Mod calamityMod = ModLoader.GetMod("CalamityMod");
			
			if (calamityMod != null)
			{
				if (npc.type == calamityMod.NPCType("CrabulonIdle"))
				{
					if (Main.rand.Next(3) == 0)
						Item.NewItem(npc.getRect(), ModContent.ItemType<Items.Weapons.WoodenDagger>());
				}
			}
            if (npc.type == NPCID.WallofFlesh && Main.rand.NextBool(7) && !Main.expertMode)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemType<ShinobiEmblem>(), 1);
			}

			// Addtional if statements here if you would like to add drops to other vanilla npc.
		}


		public override void UpdateLifeRegen(NPC npc, ref int damage)
		{
			if (Wound)
			{
				if (npc.lifeRegen > 0)
				{
					npc.lifeRegen = 0;
				}
				npc.lifeRegen -= 8;
				//if (damage < 2)
				//{
				//	damage = 2;
				//}
			}
			if (Rot)
			{
				if (npc.lifeRegen > 0)
				{
					npc.lifeRegen = 0;
				}
				npc.lifeRegen -= 18;
				//if (damage < 2)
				//{
				//	damage = 2;
				//}
			}
			if (Slowed)
			{
				if (npc.lifeRegen > 0)
				{
					npc.lifeRegen = 0;
				}
				npc.lifeRegen -= 32;
			}
		}
		public override void PostAI(NPC npc)
		{
			if (Slowed)
			{
				if (npc.boss == false)
				{
					npc.velocity.X = npc.velocity.X * 0.80f;
					npc.velocity.Y = npc.velocity.Y * 0.92f;
				}
			}
		}
	}
}
