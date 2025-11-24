using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Input;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Generation;
using System;

namespace StructuralWands.Content.Items
{
	public class PlanetWand : ModItem
	{
		Random random = new Random();
		//A list of random blocks to place
		private int[] blocks = [111, 268, 262, 677, 682, 680, 678, 686, 679, 681, 496, 688, 540, 
				57, 635, 198, 562, 515, 194, 321, 513, 249, 188, 346, 211, 40, 189, 107, 272, 7,
				47, 315, 398, 400, 203, 478, 204, 230, 22, 140, 670, 404, 147, 25, 152, 157, 541, 
				265, 200, 407, 54, 8, 45, 507, 368, 38, 164, 402, 397, 252, 76, 161, 206, 6, 119, 
				689, 473, 474, 191, 409, 367, 59, 190, 108, 56, 222, 221, 322, 118, 159, 117, 44, 
				169, 177, 666, 254, 516, 160, 196, 39, 641, 266, 396, 208, 667, 9, 193, 0, 1, 48];

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
            recipe.AddIngredient(ItemID.DirtBlock, 50);
            recipe.AddIngredient(ItemID.SandBlock, 50);
            recipe.AddIngredient(ItemID.MudBlock, 50);
            recipe.AddIngredient(ItemID.SnowBlock, 50);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}

	 	public override void OnConsumeMana(Player player, int mana) {
			int block = random.Next(99);
			int size = random.Next(10, 20);
			//place the blocks for the planet
			for (int x = 0; x < size; x++) {
				for (int y = 0; y < size; y++) {
					if (x * x + y * y < size * size) {
						WorldGen.PlaceTile((int)Main.MouseWorld.X / 16 - x, 
							(int)Main.MouseWorld.Y / 16 - y, blocks[block], true, true, -1, 0);
						WorldGen.PlaceTile((int)Main.MouseWorld.X / 16 + x, 
							(int)Main.MouseWorld.Y / 16 + y, blocks[block], true, true, -1, 0);
						WorldGen.PlaceTile((int)Main.MouseWorld.X / 16 - x, 
							(int)Main.MouseWorld.Y / 16 + y, blocks[block], true, true, -1, 0);
						WorldGen.PlaceTile((int)Main.MouseWorld.X / 16 + x, 
							(int)Main.MouseWorld.Y / 16 - y, blocks[block], true, true, -1, 0);
					}
				}
			}
		}
	}
}