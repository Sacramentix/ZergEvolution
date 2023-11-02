using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Input;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Generation;
using Terraria.WorldBuilding;
using System;
using Terraria.IO;
using System.Collections.Generic;

namespace ZergEvolution.WorldGeneration {
	public class ZergWorldGen : ModSystem {

		public override void ModifyWorldGenTasks(List<GenPass> tasks, ref double totalWeight) {
			// 5. We use FindIndex to locate the index of the vanilla world generation task called "Shinies". This ensures our code runs at the correct step.
			int gemCavesIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Gem Caves"));
			if (gemCavesIndex != -1) {
				// 6. We register our world generation pass by passing in an instance of our custom GenPass class below. The GenPass class will execute our world generation code.
				tasks.Insert(gemCavesIndex + 1, new ZergEggCaveGenPass("Zerg egg cave", 100f));
			}
		}

		// public static bool JustPressed(Keys key) {
		// 	return Main.keyState.IsKeyDown(key) && !Main.oldKeyState.IsKeyDown(key);
		// }

		// public override void PostUpdateWorld() {
		// 	// if (JustPressed(Keys.D1))
		// 	// 	TestMethod((int)Main.MouseWorld.X / 16, (int)Main.MouseWorld.Y / 16);
		// }

		// private void TestMethod() {
		// 	// Dust.QuickBox(new Vector2(x, y) * 16, new Vector2(x + 1, y + 1) * 16, 2, Color.YellowGreen, null);

		// 	// Code to test placed here:
		// 	// var ny = y+3;
		// 	// var p = new Point(x,y);
		// 	// WorldUtils.Gen(p, new Shapes.Circle(6), new Actions.SetTile((ushort)ModContent.TileType<Tiles.Blocks.Mucus>()));
		// 	// WorldUtils.Gen(p, new Shapes.Circle(3), new Actions.ClearTile());
		// 	// WorldUtils.Gen(p, new Shapes.Circle(6), new Actions.Custom((dx,dy,args)=>{WorldUtils.TileFrame(dx,dy);return true;}));
		// 	// WorldGen.PlaceObject(x, ny, (ushort)ModContent.TileType<Tiles.Entities.ZergHive>());
		// 	// WorldUtils.TileFrame();

		// 	// WorldGen.TileRunner(x - 1, y, WorldGen.genRand.Next(3, 8), WorldGen.genRand.Next(2, 8), TileID.CobaltBrick);
		// }
	}

	public class ZergEggCaveGenPass : GenPass {

		public ZergEggCaveGenPass(string name, float loadWeight) : base(name, loadWeight) {
		}

		// 8. The ApplyPass method is where the actual world generation code is placed.
		protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration) {
			// 9. Setting a progress message is always a good idea. This is the message the user sees during world generation and can be useful to help users and modders identify passes that are stuck.      
			// progress.Message = WorldGenTutorialSystem.WorldGenTutorialOresPassMessage.Value;

			var caveCount = Math.Ceiling((double)Main.maxTilesX / 1500)+1;

			for (int i = 0; i < caveCount; i++) {
				bool success = false;
				int attempts = 0;
				var x = 0;
				var y = 0;
				while (!success) {
					attempts++;
					if (attempts >= 5000) {
						break;
					}
					var side = WorldGen.genRand.Next(0,2);
					x = side == 0 ? 
						WorldGen.genRand.Next(0, Main.maxTilesX / 3) : 
						WorldGen.genRand.Next(Main.maxTilesX / 3 * 2, Main.maxTilesX);
					y = WorldGen.genRand.Next(Main.maxTilesY / 2, Main.maxTilesY-400);
					if(!GenVars.structures.CanPlace(new Rectangle(x-7,y-7,14,14))) continue;
					generateZergEggCave(x,y);
					success = true;
				}
				if(success)
					Main.NewText($"Zerg cave generated at {x}, {y} after {attempts} attempts.");
				else
					Main.NewText($"Failed to generate zerg cave after {attempts} attempts.");
			}
		}

		private void generateZergEggCave(int x, int y) {
			var p = new Point(x,y);
			WorldUtils.Gen(p, new Shapes.Circle(6), new Actions.SetTile((ushort)ModContent.TileType<Tiles.Blocks.Mucus>()));
			WorldUtils.Gen(p, new Shapes.Circle(3), new Actions.ClearTile());
			WorldUtils.Gen(p, new Shapes.Circle(6), new Actions.Custom((dx,dy,args)=>{WorldUtils.TileFrame(dx,dy);return true;}));
			WorldGen.PlaceObject(x, y+3, (ushort)ModContent.TileType<Tiles.Entities.ZergHive>());
		}
	}

}