using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace StructuralWands.Content.Items
{
	public class GravityBlock : ModItem
	{
		public override void SetDefaults()
		{
			Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.GravityBlock>(), 0);
			Item.rare = ItemRarityID.Blue;
		}

		public override void AddRecipes() 
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.AsphaltBlock, 10);
			recipe.AddIngredient(ItemID.ShadowPaint, 10);
			recipe.AddTile(TileID.Anvils);
		}
	}

}