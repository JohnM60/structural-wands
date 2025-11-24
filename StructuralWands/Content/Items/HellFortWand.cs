using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Input;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Generation;

namespace StructuralWands.Content.Items
{
	public class HellFortWand : ModItem
	{
		public override void SetStaticDefaults() {
			Item.staff[Type] = true;
		}

		public override void SetDefaults() {
			Item.DefaultToStaff(0, 16, 25, 1);
			Item.UseSound = SoundID.Item20;
			Item.SetWeaponValues(20, 5);
			Item.rare = ItemRarityID.Blue;
		}
		
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.AmethystStaff, 1);
			recipe.AddIngredient(ItemID.ObsidianBrick, 25);
            recipe.AddIngredient(ItemID.ObsidianBrickWall, 20);
            recipe.AddIngredient(ItemID.ObsidianPlatform, 20);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}

	 	public override void OnConsumeMana(Player player, int mana) {
			WorldGen.HellFort((int)Main.MouseWorld.X / 16, (int)Main.MouseWorld.Y / 16, 75, 14);
		}
	}
}