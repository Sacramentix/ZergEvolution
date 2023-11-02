// using ExampleMod.Dusts;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.UI;
using Terraria.ObjectData;
using Terraria.UI;

namespace ZergEvolution.Tiles.Entities {

    public class PsiEmitterEntity : ModTileEntity {

		// zerg invasion is occurring where the progress is above 0
		public int zergInvasionProgress = -1;
		public int zergProgressStart = 250;

		public bool areZergInvading => zergInvasionProgress > 0;

		public void OnClick() {
			if (areZergInvading) {
				SoundEngine.PlaySound(SoundID.Mech, Position.ToVector2());
				return;
			}
			zergInvasionProgress = zergProgressStart;

		} 

        public override bool IsTileValidForEntity(int x, int y) {
			// this.
            return true;
        }
    }

	public class PsiEmitterUI: UIElement {
        public override void Draw(SpriteBatch spriteBatch) {
            base.Draw(spriteBatch);
        }
		// public 
		// public override  {
        //     base.Draw(spriteBatch);
        // }
    }

    public class PsiEmitter : ModTile {

        public override void SetStaticDefaults() {
			Main.tileSolid[Type] = false;
			Main.tileFrameImportant[Type] = true;
			// Main.tileLighted
			TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
			TileObjectData.addTile(Type);

			// TileObjectData.newTile.HookCheckIfCanPlace = new PlacementHook(psiEmitterEntity.pl, 1, 0, true);

			// TileID.Sets.InteractibleByNPCs[Type] = true;
			TileID.Sets.PreventsSandfall[Type] = true;

			// AddToArray(ref TileID.Sets.);

			AddMapEntry(new Color(25, 25, 25));
			// Set other values here
		}

        public override void PlaceInWorld(int i, int j, Item item) {
			ModContent.GetInstance<PsiEmitterEntity>().Place(i,j);
			Console.WriteLine("[ZERG] tile entity place");
            base.PlaceInWorld(i, j, item);
        }

        public override bool RightClick(int i, int j) {
			var tile = Main.tile[i, j];
			// We get the computed tileEntity position	ooo
			// It should be at bottom middle			ooo
			// As the sprite is 3x3						oxo
			var x = i - ( tile.TileFrameX / 18 ) + 1;
			var y = j - ( tile.TileFrameY / 18 ) + 2;
			
			var id = ModContent.GetInstance<PsiEmitterEntity>().Find(x, y);
			Console.WriteLine(id);
			if (id == -1) {
				Console.WriteLine("notfound");
				return false;
			}
			var entity = (PsiEmitterEntity)ModTileEntity.ByID[id];
			entity.OnClick();
			// ModContent.GetInstance<PsiEmitterEntity>().Find(i,j);
			// ModTileEntity.manager.GetTileEntity
            return true;
        }


        // public override void AnimateIndividualTile(int type, int i, int j, ref int frameXOffset, ref int frameYOffset) {
        // 	frameYOffset = Main.tileFrame[Type] * AnimationFrameHeight;
        // }

        // public override void AnimateTile(ref int frame, ref int frameCounter) {
        // 	if (++frameCounter >= 10) {
        // 		frameCounter = 0;
        // 		frame = ++frame % 7;
        // 	}
        // 	// frame = Main.tileFrame[TileID.Larva];
        // }

        public override bool CreateDust(int i, int j, ref int type) {
			// type = DustID.CorruptGibs;
			return true;
		}

		public override void KillMultiTile(int i, int j, int frameX, int frameY) {
			// We need to clean up after ourselves, since this is still a "unique" tile, separate from Vanilla Pylons, so we must kill the TileEntity.
			ModContent.GetInstance<PsiEmitterEntity>().Kill(i, j);
		}

		// This method allows you to change the sound a tile makes when hit
		public override bool KillSound(int i, int j, bool fail) {
			// Play the glass shattering sound instead of the normal digging sound if the tile is destroyed on this hit
			if (!fail) {
				SoundEngine.PlaySound(SoundID.Dig, new Vector2(i, j).ToWorldCoordinates());
				return false;
			}
			return base.KillSound(i, j, fail);
		}

		public override IEnumerable<Item> GetItemDrops(int i, int j) {
			Tile t = Main.tile[i, j];
			int style = t.TileFrameY / 18;
			// It can be useful to share a single tile with multiple styles.
			yield return new Item(ModContent.ItemType<PsiEmitterItem>());

			// Here is an alternate approach:
			// int dropItem = TileLoader.GetItemDropFromTypeAndStyle(Type, style);
			// yield return new Item(dropItem);
		}

		
	}



    // public class ZergHiveEntity : ModTileEntity {

		
		
    //     public override bool IsTileValidForEntity(int x, int y) {
    //         return true;
    //     }
    // }

    public class PsiEmitterItem : ModItem {
		public override void SetDefaults() {
			Item.CloneDefaults(ItemID.GlassKiln);
			Item.createTile = ModContent.TileType<PsiEmitter>();
		}
	}

}