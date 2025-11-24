using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace StructuralWands.Content.Items
{
	public class ForceFieldBlock : ModItem
	{
		public override void SetDefaults()
		{
			Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.ForceFieldBlock>(), 0);
			Item.rare = ItemRarityID.Blue;
		}

		public override void AddRecipes() 
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.EchoBlock, 10);
			recipe.AddIngredient(ItemID.EchoCoating, 10);
			recipe.AddTile(TileID.Anvils);
		}
	}

}