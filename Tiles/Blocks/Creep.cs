// using ExampleMod.Dusts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace ZergEvolution.Tiles.Blocks {
	public class Creep : ModTile {
		public override void SetStaticDefaults()
		{
			Main.tileSolid[Type] = true;
			Main.tileMergeDirt[Type] = true;
			Main.tileBlockLight[Type] = true;
			AddMapEntry(new Color(84, 7, 84));
			// Set other values here
		}
	}

	public class MucusItem : ModItem {
		public override void SetStaticDefaults() {
			Item.ResearchUnlockCount = 100;
		}

		public override void SetDefaults() {
			Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.Blocks.Creep>());
			Item.width = 12;
			Item.height = 12;
		}

	}

}