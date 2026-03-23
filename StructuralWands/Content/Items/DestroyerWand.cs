using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Generation;
using System.Collections.Generic;

namespace StructuralWands.Content.Items
{
	public class DestroyerWand : ModItem
	{
		int destroyItem = 0;
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
			recipe.AddIngredient(ItemID.SapphireStaff, 1);
            recipe.AddIngredient(ItemID.Bomb, 25);
            recipe.AddIngredient(ItemID.Dynamite, 5);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();

			recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.EmeraldStaff, 1);
            recipe.AddIngredient(ItemID.Bomb, 25);
            recipe.AddIngredient(ItemID.Dynamite, 5);
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
			destroyItem += 1;
			if (destroyItem >= 3) {
				destroyItem = 0;
			}
		}
		
		public override void ModifyTooltips(List<TooltipLine> tooltips) {
			TooltipLine line;
			if (destroyItem == 0) {
				line = new TooltipLine(Mod, "ItemName", "Block Destroyer Wand");
			}
			else if (destroyItem == 1) {
				line = new TooltipLine(Mod, "ItemName", "Wall Destroyer Wand");
			}
			else {
				line = new TooltipLine(Mod, "ItemName", "Block + Wall Destroyer Wand");
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
						if (destroyItem == 2 || destroyItem == 0)
							WorldGen.KillTile(i, j, false, false, false);
						if (destroyItem == 2 || destroyItem == 1)
							WorldGen.KillWall(i, j, false);
					}
				}
				prevMouseX = 0;
				prevMouseY = 0;
			}
		}
	}
}