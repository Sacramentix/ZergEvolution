using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ZergEvolution.Items.Placeable.Block
{
	public class Mucus : ModItem
	{
		public override void SetStaticDefaults() {
			Item.ResearchUnlockCount = 100;
			// ItemID.Sets.ExtractinatorMode[Item.type] = Item.type;

			// Some please convert this to lang files, I'm too lazy to do it
			// Sorry Itorius, I feel you

			// DisplayName.AddTranslation(GameCulture.German, "Beispielblock");
			// Tooltip.AddTranslation(GameCulture.German, "Dies ist ein modded Block");
			// DisplayName.AddTranslation(GameCulture.Italian, "Blocco di esempio");
			// Tooltip.AddTranslation(GameCulture.Italian, "Questo è un blocco moddato");
			// DisplayName.AddTranslation(GameCulture.French, "Bloc d'exemple");
			// Tooltip.AddTranslation(GameCulture.French, "C'est un bloc modgé");
			// DisplayName.AddTranslation(GameCulture.Spanish, "Bloque de ejemplo");
			// Tooltip.AddTranslation(GameCulture.Spanish, "Este es un bloque modded");
			// DisplayName.AddTranslation(GameCulture.Russian, "Блок примера");
			// Tooltip.AddTranslation(GameCulture.Russian, "Это модифицированный блок");
			// DisplayName.AddTranslation(GameCulture.Chinese, "例子块");
			// Tooltip.AddTranslation(GameCulture.Chinese, "这是一个修改块");
			// DisplayName.AddTranslation(GameCulture.Portuguese, "Bloco de exemplo");
			// Tooltip.AddTranslation(GameCulture.Portuguese, "Este é um bloco modded");
			// DisplayName.AddTranslation(GameCulture.Polish, "Przykładowy blok");
			// Tooltip.AddTranslation(GameCulture.Polish, "Jest to modded blok");
		}

		public override void SetDefaults() {
			Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.Blocks.Mucus>());
			Item.width = 12;
			Item.height = 12;
		}

		// Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
		public override void AddRecipes() {
			// CreateRecipe(10)
			// 	.AddIngredient<ExampleItem>()
			// 	.AddTile<Tiles.Furniture.ExampleWorkbench>()
			// 	.Register();

			// CreateRecipe() // Add multiple recipes set to one Item.
			// 	.AddIngredient<ExampleWall>(4)
			// 	.AddTile<Tiles.Furniture.ExampleWorkbench>()
			// 	.Register();

			// CreateRecipe()
			// 	.AddIngredient<ExamplePlatform>(2)
			// 	.AddTile<Tiles.Furniture.ExampleWorkbench>()
			// 	.Register();
		}
	}
}