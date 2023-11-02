// using ExampleMod.Dusts;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent.Biomes.Desert;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace ZergEvolution.Tiles.Entities {
	public class ZergHive : ModTile {

        public override void SetStaticDefaults() {
			Main.tileSolid[Type] = false;
			Main.tileFrameImportant[Type] = true;
            Main.tileLavaDeath[Type] = true;
			Main.tileCut[Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
			TileObjectData.addTile(Type);
			AddMapEntry(new Color(0, 230, 0));
			// Set other values here
		}


		public override void AnimateIndividualTile(int type, int i, int j, ref int frameXOffset, ref int frameYOffset) {
			frameYOffset = Main.tileFrame[Type] * AnimationFrameHeight;
		}

		public override void AnimateTile(ref int frame, ref int frameCounter) {
			if (++frameCounter >= 10) {
				frameCounter = 0;
				frame = ++frame % 7;
			}
			// frame = Main.tileFrame[TileID.Larva];
		}

		public override bool CreateDust(int i, int j, ref int type) {
			type = DustID.CorruptGibs;
			return true;
		}

		

				// This method allows you to change the sound a tile makes when hit
		public override bool KillSound(int i, int j, bool fail) {
			// Play the glass shattering sound instead of the normal digging sound if the tile is destroyed on this hit
			if (!fail) {
				SoundEngine.PlaySound(SoundID.NPCDeath1, new Vector2(i, j).ToWorldCoordinates());
				return false;
			}
			return base.KillSound(i, j, fail);
		}

		public override IEnumerable<Item> GetItemDrops(int i, int j) {
			Tile t = Main.tile[i, j];
			int style = t.TileFrameY / 18;
			// It can be useful to share a single tile with multiple styles.
			yield return new Item(Mod.Find<ModItem>("MucusItem").Type);

			// Here is an alternate approach:
			// int dropItem = TileLoader.GetItemDropFromTypeAndStyle(Type, style);
			// yield return new Item(dropItem);
		}


        public new int AnimationFrameHeight = 54;
		
	}



    // public class ZergHiveEntity : ModTileEntity {

		
		
    //     public override bool IsTileValidForEntity(int x, int y) {
    //         return true;
    //     }
    // }

    public class ZergHiveItem : ModItem {
		public override void SetDefaults() {
			Item.CloneDefaults(ItemID.GlassKiln);
			Item.createTile = ModContent.TileType<ZergHive>();
		}
	}

}