using Crystals.Buffs.Debuffs;
using Crystals.Projectiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace Crystals
{
    public class CrystPlayer : ModPlayer
    {
        public bool ForestCrystal = false;

        public bool FoliumSet = false;

        public override bool PreKill(double damage, int hitDirection, bool pvp, ref bool playSound, ref bool genGore,
            ref PlayerDeathReason damageSource)
        {
            if (ForestCrystal)
            {
                if (!Player.HasBuff(ModContent.BuffType<Decay>()))
                {
                    Player.AddBuff(ModContent.BuffType<Decay>(), 20 * 10000);
                    Player.statLife += (int) damage;
                    return false;
                }
                else return true;
            }
            else return true;

        }


        public override void SaveData(TagCompound tag)
        {
            tag.Set(Player.name , ForestCrystal);
        }

        public override void LoadData(TagCompound tag)
        {
            ForestCrystal = tag.GetBool(Player.name);
        }

        public override void PlayerConnect(Player player)
        {
            
        }
        
    }
}