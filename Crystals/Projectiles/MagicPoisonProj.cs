using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Crystals.Projectiles
{
    public class MagicPoisonProj : ModProjectile
    {

        public override void SetDefaults()
        {
            Projectile.DamageType = DamageClass.Generic;
            Projectile.timeLeft = 400;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = true;
            Projectile.hostile = true;
        }

        public override void AI()
        {
            int dust = Dust.NewDust(Projectile.Center, 16, 16, 61);
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

        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            target.AddBuff(BuffID.Poisoned , 5*20);
        }
        
    }
}