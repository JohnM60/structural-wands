using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Generation;

namespace StructuralWands.Content.Items
{
	public class PainterWand : ModItem
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
			Item.rare = ItemRarityID.Blue;
		}
		
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.DiamondStaff, 1);
			recipe.AddIngredient(ItemID.Paintbrush, 1);
			recipe.AddIngredient(ItemID.RedPaint, 25);
			recipe.AddIngredient(ItemID.GreenPaint, 25);
			recipe.AddIngredient(ItemID.BluePaint, 25);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}

	 	public override void OnConsumeMana(Player player, int mana) {
			int mouseX = (int) (Main.MouseWorld.X / 16);
			int mouseY = (int) (Main.MouseWorld.Y / 16);
			byte selectedPaint = 0;
			byte selectedPaintCoating = 0;
			bool removePaint = false;

			for (int i = 0; i < 59; i++) {
				if (player.inventory[i].type == ItemID.PaintScraper) {
					removePaint = true;
				}
				if (player.inventory[i].paint > 0) {
					selectedPaint = player.inventory[i].paint;
					break;
				}
				if (player.inventory[i].paintCoating > 0) {
					selectedPaintCoating = player.inventory[i].paintCoating;
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
						if (removePaint) {
							WorldGen.paintCoatTile(i, j, 0, false);
							WorldGen.paintTile(i, j, 0, false);
						}
						else if (selectedPaintCoating > 0) {
							WorldGen.paintCoatTile(i, j, selectedPaintCoating, false);
						}
						else {
							WorldGen.paintTile(i, j, selectedPaint, false);
						}
					}
				}
				prevMouseX = 0;
				prevMouseY = 0;
			}
			
		}
	}
}