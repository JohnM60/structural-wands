using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace StructuralWands.Content.Buffs 
{
    public class ZeroGravityDebuff : ModBuff
    {
        public override void SetStaticDefaults() {
            Main.pvpBuff[Type] = false;
        }   
        
        public override void Update(Player player, ref int buffIndex) {
            player.velocity += new Vector2(0.0f, -0.4f);
        }  
    }
}