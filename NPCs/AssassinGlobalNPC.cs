
using Microsoft.Xna.Framework;
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

		public override void ResetEffects(NPC npc)
		{
			Wound = false;
			Rot = false;
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
		}
	}
}
