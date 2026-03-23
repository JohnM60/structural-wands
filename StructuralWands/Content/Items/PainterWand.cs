using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Generation;
using System.Collections.Generic;

namespace StructuralWands.Content.Items
{
	public class PainterWand : ModItem
	{
		Item currentPaint;
		int paintItem = 0;
		int prevMouseX = 0;
		int prevMouseY = 0;
		
		public override void SetStaticDefaults() {
			Item.staff[Type] = true;
		}

		public override void SetDefaults() {
			Item.DefaultToStaff(0, 16, 25, 10);
			Item.UseSound = SoundID.Item20;
			Item.SetWeaponValues(20, 5);
			Item.rare = ItemRarityID.Blue;
		}
		
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.ThunderStaff, 1);
			recipe.AddIngredient(ItemID.Paintbrush, 1);
			recipe.AddIngredient(ItemID.RedPaint, 25);
			recipe.AddIngredient(ItemID.GreenPaint, 25);
			recipe.AddIngredient(ItemID.BluePaint, 25);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();

			recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.ThunderStaff, 1);
			recipe.AddIngredient(ItemID.Paintbrush, 1);
			recipe.AddIngredient(ItemID.RedPaint, 25);
			recipe.AddIngredient(ItemID.GreenPaint, 25);
			recipe.AddIngredient(ItemID.BluePaint, 25);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}

		public override bool CanRightClick() {
			return true;
		}

		public override bool ConsumeItem(Player player) {
			return false;
		}

		public override void RightClick(Player player) {
			paintItem += 1;
			if (paintItem >= 4) {
				paintItem = 0;
			}
		}
		public override void ModifyTooltips(List<TooltipLine> tooltips) {
			TooltipLine line;
			if (currentPaint == null) {
				line = new TooltipLine(Mod, "ItemName", "Painter Wand (No Selection)");
			}
			else if (paintItem == 0) {
				line = new TooltipLine(Mod, "ItemName", "Painter Wand (Remove Paint)");
			}
			else if (paintItem == 1) {
				line = new TooltipLine(Mod, "ItemName", "Block Painter Wand (" + currentPaint.AffixName() + ")");
			}
			else if (paintItem == 2) {
				line = new TooltipLine(Mod, "ItemName", "Wall Painter Wand (" + currentPaint.AffixName() + ")");
			}
			else {
				line = new TooltipLine(Mod, "ItemName", "Block + Wall Painter Wand (" + currentPaint.AffixName() + ")");
			}
			tooltips[0] = line;
		}

		public override void UpdateInventory(Player player) {
			for (int i = 0; i <= 50; i++) {
				if (player.inventory[i].paint > 0 || player.inventory[i].paintCoating > 0) {
					currentPaint = player.inventory[i];
					break;
				}
			}
		}

	 	public override void OnConsumeMana(Player player, int mana) {
			int mouseX = (int) (Main.MouseWorld.X / 16);
			int mouseY = (int) (Main.MouseWorld.Y / 16);
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
						if (paintItem == 0) {
							WorldGen.paintCoatTile(i, j, 0, false);
							WorldGen.paintTile(i, j, 0, false);
							WorldGen.paintCoatWall(i, j, 0, false);
							WorldGen.paintWall(i, j, 0, false);
						}
						if (paintItem == 3 || paintItem == 1) {
							if (currentPaint.paintCoating > 0)
								WorldGen.paintCoatTile(i, j, currentPaint.paintCoating, false);
							else if (currentPaint.paint > 0)
								WorldGen.paintTile(i, j, currentPaint.paint, false);
						}
						if (paintItem == 3 || paintItem == 2) {
							if (currentPaint.paintCoating > 0)
								WorldGen.paintCoatWall(i, j, currentPaint.paintCoating, false);
							else if (currentPaint.paint > 0)
								WorldGen.paintWall(i, j, currentPaint.paint, false);
						}
					}
				}
				prevMouseX = 0;
				prevMouseY = 0;
			}
			
		}
	}
}