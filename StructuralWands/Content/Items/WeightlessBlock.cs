using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace StructuralWands.Content.Items
{
	public class WeightlessBlock : ModItem
	{
		public override void SetDefaults()
		{
			Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.WeightlessBlock>(), 0);
			Item.rare = ItemRarityID.Blue;
		}

		public override void AddRecipes() 
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Feather, 10);
			recipe.AddIngredient(ItemID.Cloud, 20);
			recipe.AddTile(TileID.Anvils);
		}
	}

}