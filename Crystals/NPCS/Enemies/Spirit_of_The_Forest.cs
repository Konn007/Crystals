using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;

namespace Crystals.NPCS.Enemies
{
    public class Spirit_of_The_Forest : ModNPC
    {
        public override void SetDefaults()
        {
            NPC.GivenName = "Spirit of the forest";
            NPC.width = 32;
            NPC.height = 32;
            NPC.defense = 2;
            NPC.damage = 17;
            NPC.lifeMax = 30;
            NPC.HitSound = SoundID.NPCHit8;
            NPC.DeathSound = SoundID.NPCDeath2;
            NPC.noGravity = true;
            NPC.aiStyle = 0;
            NPC.noTileCollide = false;
            NPC.knockBackResist = 20.0f;
            Main.npcFrameCount[NPC.type] = 3;
        }

        public override void AI()
        {
            NPC.TargetClosest(true);
            Player player = Main.player[NPC.target];
            Vector2 ToPlayer = NPC.DirectionTo(player.Center) * 4;
            NPC.velocity = ToPlayer + NPC.DirectionFrom(player.Center);
        }

        public override bool PreKill()
        {
            Player player = Main.player[NPC.target];
            player.statLife += 10;
            return true;
        }
    }
}