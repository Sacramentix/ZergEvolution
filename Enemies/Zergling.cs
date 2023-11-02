// using ExampleMod.Dusts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.Utilities;
using ZergEvolution.Invasions;

namespace ZergEvolution.Enemies {
	public class Zergling : ModNPC {
		public override void SetStaticDefaults() {
			Main.npcFrameCount[Type] = Main.npcFrameCount[NPCID.LarvaeAntlion];

			NPCID.Sets.NPCBestiaryDrawModifiers value = new NPCID.Sets.NPCBestiaryDrawModifiers() { // Influences how the NPC looks in the Bestiary
				Velocity = 1f // Draws the NPC in the bestiary as if its walking +1 tiles in the x direction
			};
			NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, value);
            
	    }
        public override void SetDefaults() {
			NPC.width = 34;
			NPC.height = 23;
			NPC.damage = 30;
			NPC.defense = 3;
			NPC.lifeMax = 150;
			NPC.HitSound = SoundID.NPCHit31;
			NPC.DeathSound = SoundID.NPCDeath34;
			NPC.value = 0f;
			NPC.knockBackResist = 1f;
            var r = Main.rand.Next(1,4);
			NPC.aiStyle =   r == 1 ? NPCAIStyleID.Fighter :
                            r == 2 ? NPCAIStyleID.Unicorn : 
                            NPCAIStyleID.Snowman;
			AIType = NPCID.LarvaeAntlion;
			AnimationType = NPCID.LarvaeAntlion; 
			// Banner = Item.NPCtoBanner(NPCID.Zombie); // Makes this NPC get affected by the normal zombie banner.
			// BannerItem = Item.BannerToItem(Banner); // Makes kills of this NPC go towards dropping the banner it's associated with.
			// SpawnModBiomes = new int[1] { ModContent.GetInstance<ExampleSurfaceBiome>().Type }; // Associates this NPC with the ExampleSurfaceBiome in Bestiary
		}

        public override float SpawnChance(NPCSpawnInfo spawnInfo) {
			if (!spawnInfo.Player.InModBiome<ZergEventBiome>()) return 0;
            return 1000;
        }

        public override void OnKill()
        {
            // base.OnKill();
        }

        // public override void OnSpawn(IEntitySource source) {
        //     if (Main.rand.NextFloat() < 0.3) 
        // }

    }

	public class ZerglingSpawnEgg : ModItem {
		public override void SetStaticDefaults() {
			Item.ResearchUnlockCount = 100;
		}

		public override void SetDefaults() {
            Item.DefaultToCapturedCritter(ModContent.NPCType<Zergling>());
            Item.useTime = 1;
			Item.width = 18;
			Item.height = 18;
		}

	}


}