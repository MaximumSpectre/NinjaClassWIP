using Terraria.ModLoader;

namespace NinjaClass
{
	public class NinjaClass : Mod
	{
		public static NinjaClass instance;

        public NinjaClass()
        {
            Properties = new ModProperties()
            {
                Autoload = true
            };
        }
        public override void Load()
        {
            instance = this;
        }
        public override void Unload()
        {
            instance = null;
        }
	}
}