using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.ObjectData;
using Microsoft.Xna.Framework;
using StructuralWands.Content.Buffs;

namespace StructuralWands.Content.Tiles
{
	public class ForceFieldBlockEntity : ModTileEntity
	{
		public override void Update() {
			foreach (var player in Main.ActivePlayers) {
				float distToBlock = player.Distance(new Vector2(this.Position.X * 16, this.Position.Y * 16));
				if (player.Distance(new Vector2(this.Position.X * 16, this.Position.Y * 16)) < 1000) {
					//allow zero gravity by adding a debuff
					player.AddBuff(ModContent.BuffType<ZeroGravityDebuff>(), 1);
					//then move the player away from the block at a rate of 1.0 blocks/tick
					player.velocity += new Vector2(1.0f * ((player.position.X - this.Position.X * 16) / distToBlock), 
							1.0f * ((player.position.Y - this.Position.Y * 16) / distToBlock));
				};
			}
		}

		public override bool IsTileValidForEntity(int x, int y) {
			Tile tile = Main.tile[x, y];
			return tile.HasTile && tile.TileType == ModContent.TileType<ForceFieldBlock>();
		}
	}

	public class ForceFieldBlock : ModTile
	{
		public override void SetStaticDefaults()
		{
			Main.tileFrameImportant[Type] = true;

			TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
			TileObjectData.newTile.StyleHorizontal = true;
			TileObjectData.newTile.HookPostPlaceMyPlayer = ModContent.GetInstance<ForceFieldBlockEntity>().Generic_HookPostPlaceMyPlayer;
			TileObjectData.newTile.UsesCustomCanPlace = true;
			TileObjectData.addTile(Type);
			
			AddMapEntry(new Color(200, 200, 200), CreateMapEntryName(), MapHoverText);
		}

		public override void KillTile(int i, int j, ref bool fail, ref bool effectOnly, ref bool noItem) {
			ModContent.GetInstance<ForceFieldBlockEntity>().Kill(i, j);
		}

		public static string MapHoverText(string name, int i, int j) {
			return "Force Field Block";
		}
	}

}