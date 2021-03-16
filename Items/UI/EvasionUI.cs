using Terraria.GameContent.UI.Elements;
using Terraria.UI;
using Microsoft.Xna.Framework;
using Terraria;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ModLoader;

namespace NinjaClass.UI
{
    internal class EvasionUI : UIState
    {
        public static bool visible;
        public UIImage panel;
        public float oldScale;
        public Texture2D textureEvade= ModContent.GetTexture("NinjaClass/UI/EvasionUI");
        public override void OnInitialize()
        {
            // if you set this to true, it will show up in game
            visible = false;
            panel = new UIImage(textureEvade); //initialize the panel
            // ignore these extra 0s
            panel.Left.Set(Main.screenWidth/2 - 20, 0); //this makes the distance between the left of the screen and the left of the panel 500 pixels (somewhere by the middle)
            panel.Top.Set(Main.screenHeight / 2 + 30, 0); //this is the distance between the top of the screen and the top of the panel
            panel.Width.Set(40, 0);
            panel.Height.Set(30, 0);
            
            Append(panel); //appends the panel to the UIState
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (oldScale != Main.inventoryScale)
            {
                oldScale = Main.inventoryScale;
                Recalculate();
            }
        }
    }
}