
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Crystals.Projectiles
{
    public class LeavesProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 20;
            Projectile.height = 20;
            Projectile.friendly = true;
           Projectile.DamageType = DamageClass.Magic;
           Projectile.timeLeft = 400;
           Projectile.ignoreWater = true;
           Projectile.tileCollide = true;
           Projectile.penetrate = 3;
        }

        public override void AI()
        {


            Projectile.ai[0]++;
            if (Projectile.ai[0] >= 30)
            {
                Projectile.velocity.X *= 0.99f;
                if (Projectile.velocity.Y < 0)
                {
                    Projectile.velocity.Y *= 0.95f;
                    if (Math.Abs(Projectile.velocity.Y) < 0.2f)
                    {
                        Projectile.velocity.Y = -Projectile.velocity.Y;
                    }
                }
                else
                {
                    Projectile.velocity.Y *= 1.05f;
                }
            }
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            Player player = Main.player[Projectile.owner];
            player.statMana =+ damage/2 + player.statMana;
            player.ManaEffect(damage/2);
        }


    }
}