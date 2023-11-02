// using ExampleMod.Dusts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using ZergEvolution.Invasions;

namespace ZergEvolution.Enemies {

	public class Larva : ModNPC {
		public override void SetStaticDefaults() {
			Main.npcFrameCount[Type] = Main.npcFrameCount[NPCID.Worm];

			NPCID.Sets.NPCBestiaryDrawModifiers value = new NPCID.Sets.NPCBestiaryDrawModifiers() { // Influences how the NPC looks in the Bestiary
				Velocity = 1f // Draws the NPC in the bestiary as if its walking +1 tiles in the x direction
			};
			NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, value);
            
	    }
        public override void SetDefaults() {
			NPC.width = 44;
			NPC.height = 19;
			NPC.damage = 10;
			NPC.defense = 0;
			NPC.lifeMax = 100;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath1;
			NPC.value = 0f;
			NPC.knockBackResist = 1f;
			NPC.aiStyle = NPCAIStyleID.CritterWorm;
			AIType = NPCID.Worm;
			AnimationType = NPCID.Worm;
			// Banner = Item.NPCtoBanner(NPCID.Zombie); // Makes this NPC get affected by the normal zombie banner.
			// BannerItem = Item.BannerToItem(Banner); // Makes kills of this NPC go towards dropping the banner it's associated with.
			// SpawnModBiomes = new int[1] { ModContent.GetInstance<ExampleSurfaceBiome>().Type }; // Associates this NPC with the ExampleSurfaceBiome in Bestiary
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo) {
			if (!spawnInfo.Player.InModBiome<ZergEventBiome>()) return 0;
            return 0;
        }

    }

	public class LarvaSpawnEgg : ModItem {
		public override void SetStaticDefaults() {
			Item.ResearchUnlockCount = 100;
		}

		public override void SetDefaults() {
            Item.DefaultToCapturedCritter(ModContent.NPCType<Larva>());
            Item.useTime = 1;
			Item.width = 18;
			Item.height = 18;
		}

	}


}