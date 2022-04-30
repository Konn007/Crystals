using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Crystals.Projectiles
{
    public class LitnumProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.YoyosLifeTimeMultiplier[Projectile.type] = 8.0f;
            ProjectileID.Sets.YoyosMaximumRange[Projectile.type] = 250f;
            ProjectileID.Sets.YoyosTopSpeed[Projectile.type] = 13f;
        }

        public override void SetDefaults()
        {
            Projectile.extraUpdates = 0; 
            Projectile.width = 30;
            Projectile.height = 26;
            Projectile.aiStyle = 99;
            Projectile.friendly = true;
            Projectile.penetrate = -1; 
            Projectile.DamageType = DamageClass.Melee;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.Confused , 30*5);
            Projectile.NewProjectile(Projectile.GetNoneSource() , Projectile.position , Vector2.One , ModContent.ProjectileType<LitnumMirror>(), Projectile.damage ,Projectile.knockBack , Projectile.owner , Projectile.ai[0]);
        }
    }
}