using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Input;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Generation;
using System;

namespace StructuralWands.Content.Items
{
	public class DestroyerWand : ModItem
	{
		Random random = new Random();
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
			recipe.AddIngredient(ItemID.RubyStaff, 1);
            recipe.AddIngredient(ItemID.Bomb, 25);
            recipe.AddIngredient(ItemID.Dynamite, 5);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}

	 	public override void OnConsumeMana(Player player, int mana) {
			int size = random.Next(10);
			WorldGen.digTunnel((int)Main.MouseWorld.X / 16, (int)Main.MouseWorld.Y / 16, 0, 0, size, 2, false);
		}
	}
}