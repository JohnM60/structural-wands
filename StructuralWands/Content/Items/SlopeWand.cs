using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Generation;
using System.Collections.Generic;

namespace StructuralWands.Content.Items
{
	public class SlopeWand : ModItem
	{
		int prevMouseX = 0;
		int prevMouseY = 0;
		int slopeValue = 0;
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
			recipe.AddIngredient(ItemID.IronHammer, 1);
			recipe.AddIngredient(ItemID.Amethyst, 1);
			recipe.AddIngredient(ItemID.Topaz, 1);
			recipe.AddIngredient(ItemID.Emerald, 1);
			recipe.AddIngredient(ItemID.Sapphire, 1);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();

			recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.ThunderStaff, 1);
			recipe.AddIngredient(ItemID.LeadHammer, 1);
			recipe.AddIngredient(ItemID.Amethyst, 1);
			recipe.AddIngredient(ItemID.Topaz, 1);
			recipe.AddIngredient(ItemID.Emerald, 1);
			recipe.AddIngredient(ItemID.Sapphire, 1);
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
			slopeValue += 1;
			if (slopeValue >= 6) {
				slopeValue = 0;
			}
		}

		public override void ModifyTooltips(List<TooltipLine> tooltips) {
			TooltipLine line;
			if (slopeValue == 0) {
				line = new TooltipLine(Mod, "ItemName", "Slope Wand (Half Block)");
			}
			else if (slopeValue == 1) {
				line = new TooltipLine(Mod, "ItemName", "Slope Wand (Bottom Left)");
			}
			else if (slopeValue == 2) {
				line = new TooltipLine(Mod, "ItemName", "Slope Wand (Bottom Right)");
			}
			else if (slopeValue == 3) {
				line = new TooltipLine(Mod, "ItemName", "Slope Wand (Top Left)");
			}
			else if (slopeValue == 4) {
				line = new TooltipLine(Mod, "ItemName", "Slope Wand (Top Right)");
			}
			else {
				line = new TooltipLine(Mod, "ItemName", "Slope Wand (Full Block)");
			}
			tooltips[0] = line;
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
						if (slopeValue == 0)
							WorldGen.PoundTile(i, j);
						else if (slopeValue > 0 && slopeValue < 5)
							WorldGen.SlopeTile(i, j, slopeValue, false);
						else
							WorldGen.SlopeTile(i, j, 0, false);
					}
				}
				prevMouseX = 0;
				prevMouseY = 0;
			}
		}
	}
}