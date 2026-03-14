using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Generation;

namespace StructuralWands.Content.Items
{
	public class SlopeWand : ModItem
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
			recipe.AddIngredient(ItemID.SapphireStaff, 1);
			recipe.AddIngredient(ItemID.IronHammer, 1);
			recipe.AddIngredient(ItemID.Amethyst, 1);
			recipe.AddIngredient(ItemID.Topaz, 1);
			recipe.AddIngredient(ItemID.Emerald, 1);
			recipe.AddIngredient(ItemID.Ruby, 1);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}

	 	public override void OnConsumeMana(Player player, int mana) {
			int mouseX = (int) (Main.MouseWorld.X / 16);
			int mouseY = (int) (Main.MouseWorld.Y / 16);
			int slopeValue = 0;
			bool halfBlock = false;

			if (player.inventory[0].type == ModContent.ItemType<SlopeWand>()) {
				halfBlock = true;
			}
			for (int i = 1; i <= 4; i++) {
				if (player.inventory[i].type == ModContent.ItemType<SlopeWand>()) {
					slopeValue = i;
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
						if (halfBlock)
							WorldGen.PoundTile(i, j);
						else
							WorldGen.SlopeTile(i, j, slopeValue, false);
					}
				}
				prevMouseX = 0;
				prevMouseY = 0;
			}
		}
	}
}