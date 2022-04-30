using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace Crystals.Buffs.Debuffs
{
    public class Decay : ModBuff
    {
        public override void Update(Player player, ref int buffIndex)
        {
            if (player.statLife <= 0)
            {
                player.KillMe(PlayerDeathReason.LegacyEmpty(), 10000 , 1);
            }
            else
            {
                player.statLife -= 1;
                if (player.statManaMax != player.statMana)
                {
                    player.statMana += 10;  
                }
            }
        }

    }
}