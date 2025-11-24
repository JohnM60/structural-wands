using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Input;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Generation;

namespace StructuralWands.Content.Items
{
	public class ChestWand : ModItem
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
			recipe.AddIngredient(ItemID.TopazStaff, 1);
            recipe.AddIngredient(ItemID.Chest, 1);
            recipe.AddIngredient(ItemID.GoldChest, 1);
            recipe.AddIngredient(ItemID.IceChest, 1);
            recipe.AddIngredient(ItemID.DesertChest, 1);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}

	 	public override void OnConsumeMana(Player player, int mana) {
			WorldGen.AddBuriedChest((int)Main.MouseWorld.X / 16, (int)Main.MouseWorld.Y / 16, 0, false, -1, false, 0);
		}
	}
}