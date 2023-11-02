// using ExampleMod.Dusts;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Capture;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.UI.ModBrowser;
using Terraria.ObjectData;
using ZergEvolution.Tiles.Entities;

namespace ZergEvolution.Invasions {

	public class ZergEventBiome : ModBiome {

		// public override ModSurfaceBackgroundStyle SurfaceBackgroundStyle => ModContent.GetInstance<ZergEventBiomeBackgroundStyle>();
		public override string BestiaryIcon => base.BestiaryIcon;
		public override string BackgroundPath => base.BackgroundPath;
		public override Color? BackgroundColor => base.BackgroundColor;
		public override string MapBackground => BackgroundPath; // Re-uses Bestiary Background for Map Background
		public override bool IsBiomeActive(Player p) {
			foreach(var te in ModTileEntity.ByID.Values) {
				if (!(te is PsiEmitterEntity)) continue;
				if (Vector2.Distance(p.position, te.Position.ToWorldCoordinates()) > 4000) continue;
				var PsiEmitter = (PsiEmitterEntity) te;
				if (!PsiEmitter.areZergInvading) continue;
				return true;		
			}
			return false;
		}

        public override void OnInBiome(Player player) {
			
			// Console.WriteLine("[ZERG]" + player);
            player.AddBuff(BuffID.Battle, 2);
        }

        public override CaptureBiome.TileColorStyle TileColorStyle => CaptureBiome.TileColorStyle.Corrupt;
        public override void SpecialVisuals(Player player, bool isActive)
        {
            base.SpecialVisuals(player, isActive);
        }
		

        public override SceneEffectPriority Priority => SceneEffectPriority.Event;
    }

	public class ZergEventBiomeSpawnEditor : GlobalNPC {

        // public int counter = 0;
        public override void OnKill(NPC npc)
        {
            base.OnKill(npc);
        }

        public override void EditSpawnRate(Player player, ref int spawnRate, ref int maxSpawns) {
			// Console.WriteLine("Spawn change: "+spawnRate+ " "+maxSpawns);
            if (player.InModBiome<ZergEventBiome>()) {
                spawnRate = Math.Max((int)(spawnRate / 5), 10);
                maxSpawns = Math.Max((int)(maxSpawns * 2), 50);
				// 
                // maxSpawns = (int)(maxSpawns*1.3);
				// counter++;
				// if (counter % 600 == 0) Console.WriteLine("Biome spawn change: "+spawnRate+ " "+maxSpawns);
            }
        }
    }

	public class ZergEventBiomeBackgroundStyle : ModSurfaceBackgroundStyle {
		// Use this to keep far Backgrounds like the mountains.
		public override void ModifyFarFades(float[] fades, float transitionSpeed) {
			for (int i = 0; i < fades.Length; i++) {
				if (i == Slot) {
					fades[i] += transitionSpeed;
					if (fades[i] > 1f) {
						fades[i] = 1f;
					}
				}
				else {
					fades[i] -= transitionSpeed;
					if (fades[i] < 0f) {
						fades[i] = 0f;
					}
				}
			}
		}


		private static int SurfaceFrameCounter;
		private static int SurfaceFrame;
		// public override int ChooseMiddleTexture() {
		// 	return BackgroundTextureLoader.GetBackgroundSlot(Mod, "Assets/Textures/Backgrounds/ZergEventBiome_Mid");
		// }

		// public override int ChooseCloseTexture(ref float scale, ref double parallax, ref float a, ref float b) {
		// 	return BackgroundTextureLoader.GetBackgroundSlot(Mod, "Assets/Textures/Backgrounds/ExampleBiomeSurfaceClose");
		// }
	}

}