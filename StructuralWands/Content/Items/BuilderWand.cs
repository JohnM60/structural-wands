using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

using Terraria.GameContent.Generation;

namespace StructuralWands.Content.Items
{
	public class BuilderWand : ModItem
	{
		int prevMouseX = 0;
		int prevMouseY = 0;
		public override void SetStaticDefaults() {
			Item.staff[Type] = true;
		}

		public override void SetDefaults() {
			Item.DefaultToStaff(0, 16, 25, 1);
			Item.UseSound = SoundID.Item20;
			Item.SetWeaponValues(20, 5);
			Item.useTime = 1;
			Item.rare = ItemRarityID.Blue;
		}
		
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.AmberStaff, 1);
            recipe.AddIngredient(ItemID.BuilderPotion, 2);
            recipe.AddIngredient(ItemID.Toolbox, 1);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}

	 	public override void OnConsumeMana(Player player, int mana) {
			int mouseX = (int) (Main.MouseWorld.X / 16);
			int mouseY = (int) (Main.MouseWorld.Y / 16);
			int selectedTile = 0;
			int tileStyle = 0;
			for (int i = 0; i < 59; i++) {
				if (player.inventory[i].createTile != -1) {
					selectedTile = player.inventory[i].createTile;
					tileStyle = player.inventory[i].placeStyle;
					break;
				}
			}
			
			if (prevMouseX == 0) {
				prevMouseX = mouseX;
				prevMouseY = mouseY;
			}
			else {
				if (prevMouseX > mouseX) {
					int temp = prevMouseX;
					prevMouseX = mouseX;
					mouseX = temp;
				}
				if (prevMouseY > mouseY) {
					int temp = prevMouseY;
					prevMouseY = mouseY;
					mouseY = temp;
				}
				for (int i = prevMouseX; i <= mouseX; i++) {
					for (int j = prevMouseY; j <= mouseY; j++) {
						WorldGen.PlaceTile(i, j, selectedTile, false, true, -1, tileStyle);
					}
				}
				prevMouseX = 0;
				prevMouseY = 0;
			}
		}
	}
}