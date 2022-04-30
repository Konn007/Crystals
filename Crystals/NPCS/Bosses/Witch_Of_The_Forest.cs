using System;
using System.Collections.Generic;
using Crystals.Items;
using Crystals.Items.Accesories;
using Crystals.Items.Weapons;
using Crystals.NPCS.Enemies;
using Crystals.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace Crystals.NPCS.Bosses
{
    public class Witch_Of_The_Forest : ModNPC
    {
        private int waitfr = 0;

        private bool attacking = false;

        private int startFrame;
        private int finalFrame;
        private int frameSpeed;
        
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Witch of the Forest");
        }

        public override void SetDefaults()
        {
            
            NPC.boss = true;
            if (!Main.expertMode || !Main.masterMode)
            {
                NPC.lifeMax = 5000;
            }
            else
            {
                NPC.lifeMax = 3000;   
            }

            NPC.buffImmune[BuffID.Confused] = true;
            NPC.damage = 20;
            NPC.width = 100;
            NPC.height = 144;
            NPC.defense = 9;
            NPC.HitSound = SoundID.NPCHit8;
            NPC.DeathSound = SoundID.NPCDeath2;
            NPC.noTileCollide = true;
            NPC.noGravity = true;
            NPC.knockBackResist = 0.0f;
            Main.npcFrameCount[NPC.type] = 14;
            NPC.npcSlots = 10f;
            NPC.aiStyle = 0;
            if (!Main.dedServ) {
                Music = MusicLoader.GetMusicSlot(Mod, "Sounds/Music/Teaser.wav");
            }
            
        }
        
        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry) {
            // Sets the description of this NPC that is listed in the bestiary
            bestiaryEntry.Info.AddRange(new List<IBestiaryInfoElement> {
                new MoonLordPortraitBackgroundProviderBestiaryInfoElement(), // Plain black background
                new FlavorTextBestiaryInfoElement("The Ancient Witch that everyone fears her, no one returned after seeing her.")
            });
        }
        
        

        public override void FindFrame(int frameSize)
        {
            var npc = NPC;
            NPC.frameCounter += 0.5f; 
            if (NPC.frameCounter > frameSpeed) {
                NPC.frameCounter = 0;
                NPC.frame.Y += frameSize;

                if (NPC.frame.Y > finalFrame * frameSize) {
                    NPC.frame.Y = startFrame * frameSize;
                }
            }
        }
        
        
        
        const int ProjectileState = 0;
        const int ChaseState = 1;
        const int CircleProjectileState = 2;
        const int DefensiveState = 3;
        float State
    {
        get => NPC.ai[0];
        set => NPC.ai[0] = value;
    }
        float Timer
    {
        get => NPC.ai[1];
        set => NPC.ai[1] = value;
    }
    
    public override void AI()
    {
        Timer++;
        NPC.TargetClosest();
        switch (State)
        {
            case ProjectileState:
                ProjectileAttack();
                if (Timer == 30)
                {    
                    Timer = 0;
                    State = Main.rand.Next(0,4); 
                }
                break;
            case ChaseState:
                Chase(); 
                if (Timer == 60)
                {
                    Timer = 0;
                    NPC.velocity = Vector2.Zero;
                    State = ProjectileState;
                }
                break;
            case CircleProjectileState:
                CircleProjectile();
                if (Timer == 180)
                {
                    Timer = 0;
                    State = ChaseState;
                }
                break;
            case DefensiveState:
            {
                    defense();
                    if (Timer == 260)
                    {
                        Timer = 0;
                        NPC.defense = 9;
                        NPC.velocity = Vector2.Zero;
                        State = ChaseState; 
                    } 
                }
                
                break;
        }
        
        Player player = Main.player[NPC.target];
        if (player.dead) {
            NPC.velocity.Y += 0.04f;
            NPC.EncourageDespawn(10);
        } 
    }
    
    
    
    private void ProjectileAttack() 
    {
        if (Timer % 20 == 0 && Main.netMode != NetmodeID.MultiplayerClient)
        {
            startFrame = 7;
            finalFrame = 13;
            frameSpeed = 3;
            Player target = Main.player[NPC.target];
            Vector2 ToPlayer = NPC.DirectionTo(target.Center) * 20;
            Projectile.NewProjectile(Projectile.GetNoneSource() , NPC.Center.X, NPC.Center.Y, ToPlayer.X, ToPlayer.Y, ModContent.ProjectileType<NutProj>(), 40, 0f);
                                                                                                                              
        }
    }
    private void Chase()
    {
        Player target = Main.player[NPC.target];
        startFrame = 0;
        finalFrame = 6;
        frameSpeed = 3;
        //get the closest player. 
        Vector2 ToPlayer = NPC.DirectionTo(target.Center) * 7;
        NPC.velocity = ToPlayer;
    }
    private void CircleProjectile()
    {
        if (Timer % 60 == 0 && Main.netMode != NetmodeID.MultiplayerClient)
        {
            
            if (Main.expertMode || Main.masterMode)
            {
                for (int i = 0; i < 360; i += 10)
                {
                   
                    Player target = Main.player[NPC.target];
                    Vector2 ToPlayer = NPC.DirectionTo(target.Center).RotatedBy(MathHelper.ToRadians(i));
                    if (Main.netMode != NetmodeID.MultiplayerClient)
                        Projectile.NewProjectile(Projectile.GetNoneSource() , NPC.Center.X, NPC.Center.Y, ToPlayer.X * 7, ToPlayer.Y * 7, ModContent.ProjectileType<LeafProj>() , 32, 0f);
                }
            }
            else
            {
                for (int i = 0; i < 360; i += 20)
                {
                    Player target = Main.player[NPC.target];
                    Vector2 ToPlayer = NPC.DirectionTo(target.Center).RotatedBy(MathHelper.ToRadians(i));
                    if (Main.netMode != NetmodeID.MultiplayerClient)
                        Projectile.NewProjectile(Projectile.GetNoneSource() , NPC.Center.X, NPC.Center.Y, ToPlayer.X * 5, ToPlayer.Y * 5, ModContent.ProjectileType<LeafProj>() , 32, 0f);
                }
            }
        }
    }

    private void defense()
    {
        if (Timer % 60 == 0 && Main.netMode != NetmodeID.MultiplayerClient)
        {
            if (Main.expertMode || Main.masterMode)
            {
                NPC.life = NPC.life + 60;
                NPC.defense *= 3;
                NPC.NewNPC(NPC.GetSpawnSourceForNPCFromNPCAI(), (int)NPC.position.X, (int)NPC.position.Y,
                    ModContent.NPCType<Spirit_of_The_Forest>());

                for (int i = 0; i < 360; i += 12)
                {
                    Player target = Main.player[NPC.target];
                    Vector2 ToPlayer = NPC.DirectionTo(target.Center).RotatedBy(MathHelper.ToRadians(i));
                    if (Main.netMode != NetmodeID.MultiplayerClient)
                    {
                        int dust = Dust.NewDust(NPC.Center, 16, 16, 61 , ToPlayer.X * 5, ToPlayer.Y * 5);
                        Projectile.NewProjectile(Projectile.GetNoneSource() , NPC.Center.X, NPC.Center.Y, ToPlayer.X * 5, ToPlayer.Y * 5, ModContent.ProjectileType<MagicPoisonProj>() , 20, 0f);
                    }
                }
            }
            else
            {
                NPC.life = NPC.life + 50;
                NPC.defense *= 2;

                for (int i = 0; i < 360; i += 12)
                {
                    Player target = Main.player[NPC.target];
                    Vector2 ToPlayer = NPC.DirectionTo(target.Center).RotatedBy(MathHelper.ToRadians(i));
                    if (Main.netMode != NetmodeID.MultiplayerClient)
                    {
                        int dust = Dust.NewDust(NPC.Center, 16, 16, 61 , ToPlayer.X * 5, ToPlayer.Y * 5);
                        Projectile.NewProjectile(Projectile.GetNoneSource() , NPC.Center.X, NPC.Center.Y, ToPlayer.X * 5, ToPlayer.Y * 5, ModContent.ProjectileType<MagicPoisonProj>() , 20, 0f);
                    }
                }
            }
            
        }
    }

    public override void ModifyNPCLoot(NPCLoot npcLoot)
    {
        CommonDrop[] drops = new[]
        {
            new CommonDrop(ModContent.ItemType<Book_of_Leaves>(), 8),
            new CommonDrop(ModContent.ItemType<Litnum>(), 8),
            new CommonDrop(ModContent.ItemType<Staff_of_Trees>(), 8)
        };
            
        npcLoot.Add(new OneFromRulesRule((int) 1.3,drops));
        npcLoot.Add(new CommonDrop(ModContent.ItemType<Leaf>(), 1 , 14 , 30));
        npcLoot.Add(new CommonDrop(ModContent.ItemType<Crystal_of_The_Forest>(), 18));
    }
    }
}    