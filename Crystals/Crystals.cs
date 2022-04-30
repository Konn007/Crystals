using Microsoft.Xna.Framework.Graphics;
using Terraria.ModLoader;

namespace Crystals
{
	public class Crystals : Mod
	{
		public override void Load()
		{
			MusicLoader.AddMusic(this, "Sounds/Music/Teaser");
		}
	}
}