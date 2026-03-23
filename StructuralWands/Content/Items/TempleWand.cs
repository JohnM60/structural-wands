using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Generation;

namespace StructuralWands.Content.Items
{
	public class TempleWand : ModItem
	{
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
			recipe.AddIngredient(ItemID.RubyStaff, 1);
			recipe.AddIngredient(ItemID.BrownPaint, 50);
			recipe.AddIngredient(ItemID.GrayBrick, 50);
			recipe.AddIngredient(ItemID.Spike, 10);
			recipe.AddIngredient(ItemID.DartTrap, 2);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();

			recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.DiamondStaff, 1);
			recipe.AddIngredient(ItemID.BrownPaint, 50);
			recipe.AddIngredient(ItemID.GrayBrick, 50);
			recipe.AddIngredient(ItemID.Spike, 10);
			recipe.AddIngredient(ItemID.DartTrap, 2);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}

	 	public override void OnConsumeMana(Player player, int mana) {
			WorldGen.makeTemple((int)Main.MouseWorld.X / 16, (int)Main.MouseWorld.Y / 16);
		}
	}
}