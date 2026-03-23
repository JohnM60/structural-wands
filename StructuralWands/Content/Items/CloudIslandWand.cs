using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Generation;
using System.Collections.Generic;

namespace StructuralWands.Content.Items
{
	public class CloudIslandWand : ModItem
	{
		int currentIsland = 0;

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
			recipe.AddIngredient(ItemID.AmethystStaff, 1);
            recipe.AddIngredient(ItemID.Cloud, 50);
            recipe.AddIngredient(ItemID.SandBlock, 25);
            recipe.AddIngredient(ItemID.SunplateBlock, 10);
            recipe.AddIngredient(ItemID.SkywareChest, 1);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();

			recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.TopazStaff, 1);
            recipe.AddIngredient(ItemID.Cloud, 50);
            recipe.AddIngredient(ItemID.SandBlock, 25);
            recipe.AddIngredient(ItemID.SunplateBlock, 10);
            recipe.AddIngredient(ItemID.SkywareChest, 1);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}

		public override void ModifyTooltips(List<TooltipLine> tooltips) {
			TooltipLine line;
			if (currentIsland == 0) {
				line = new TooltipLine(Mod, "ItemName", "Cloud Island Wand (Desert Cloud Island)");
			}	
			else if (currentIsland == 1) {
				line = new TooltipLine(Mod, "ItemName", "Cloud Island Wand (Snow Cloud Island)");
			}
			else if (currentIsland == 2) {
				line = new TooltipLine(Mod, "ItemName", "Cloud Island Wand (Barren Island)");
			}
			else {
				line = new TooltipLine(Mod, "ItemName", "Cloud Island Wand (Cloud Island)");
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
			currentIsland += 1;
			if (currentIsland >= 4) {
				currentIsland = 0;
			}
		}

	 	public override void OnConsumeMana(Player player, int mana) {
			if (currentIsland == 0) {
				WorldGen.DesertCloudIsland((int)Main.MouseWorld.X / 16, (int)Main.MouseWorld.Y / 16);
			}
			else if (currentIsland == 1) {
				WorldGen.SnowCloudIsland((int)Main.MouseWorld.X / 16, (int)Main.MouseWorld.Y / 16);
			}
			else if (currentIsland == 2) {
				WorldGen.FloatingIsland((int)Main.MouseWorld.X / 16, (int)Main.MouseWorld.Y / 16);
			}
			else {
				WorldGen.CloudIsland((int)Main.MouseWorld.X / 16, (int)Main.MouseWorld.Y / 16);
			}
			WorldGen.IslandHouse((int)Main.MouseWorld.X / 16, (int)Main.MouseWorld.Y / 16 - 5, 1);
		}
	}
}