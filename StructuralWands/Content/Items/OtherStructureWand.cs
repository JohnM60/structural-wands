using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Generation;
using System.Collections.Generic;

namespace StructuralWands.Content.Items
{
	public class OtherStructureWand : ModItem
	{
		int currentStructure = 0;

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
			recipe.AddIngredient(ItemID.AmberStaff, 1);
			recipe.AddIngredient(ItemID.ObsidianBrick, 25);
            recipe.AddIngredient(ItemID.ObsidianBrickWall, 20);
            recipe.AddIngredient(ItemID.ObsidianPlatform, 20);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}

		public override void ModifyTooltips(List<TooltipLine> tooltips) {
			TooltipLine line;
			if (currentStructure == 0) {
				line = new TooltipLine(Mod, "ItemName", "Structure Wand (Dungeon Tree)");
			}	
			else if (currentStructure == 1) {
				line = new TooltipLine(Mod, "ItemName", "Structure Wand (Small Lake)");
			}
			else if (currentStructure == 2) {
				line = new TooltipLine(Mod, "ItemName", "Structure Wand (Dirt Mound)");
			}
			else if (currentStructure == 3) {
				line = new TooltipLine(Mod, "ItemName", "Structure Wand (Hell Fort, underworld only)");
			}
			else {
				line = new TooltipLine(Mod, "ItemName", "Structure Wand (Mine House)");
			}
			tooltips[0] = line;
		}

		public override bool CanRightClick() {
			return true;
		}

		public override bool ConsumeItem(Player player) {
			return false;
		}

		public override void RightClick(Player player) {
			currentStructure += 1;
			if (currentStructure >= 5) {
				currentStructure = 0;
			}
		}

	 	public override void OnConsumeMana(Player player, int mana) {
			if (currentStructure == 0) {
				WorldGen.GrowDungeonTree((int)Main.MouseWorld.X / 16, (int)Main.MouseWorld.Y / 16, false);
			}
			else if (currentStructure == 1) {
				WorldGen.SonOfLakinater((int)Main.MouseWorld.X / 16, (int)Main.MouseWorld.Y / 16, 1.0);
			}
			else if (currentStructure == 2) {
				WorldGen.Mountinater((int)Main.MouseWorld.X / 16, (int)Main.MouseWorld.Y / 16);
			}
			else if (currentStructure == 3) {
				WorldGen.HellFort((int)Main.MouseWorld.X / 16, (int)Main.MouseWorld.Y / 16, 75, 14);
			}
			else {
				WorldGen.MineHouse((int)Main.MouseWorld.X / 16, (int)Main.MouseWorld.Y / 16);
			}
			
		}
	}
}