using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Crystals.Projectiles
{
    public class NutProj : ModProjectile
    {
        
        public override void SetDefaults()
        {
            Projectile.width = 16;
            Projectile.height = 16;
            Projectile.Size = new Vector2(3);
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.timeLeft = 1200;
            Projectile.ignoreWater = false;
            Projectile.tileCollide = true;
            Projectile.hostile = true;
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            for (int i = 0; i < 360; i += 12)
            {
                //loop till i = 360, for one full rotation. You can change the interval of rotation by changing the 12 ;//get the closest player
                Vector2 ToPlayer = Projectile.DirectionTo(new Vector2(0 , -100)).RotatedBy(MathHelper.ToRadians(i));//By default, rotation uses radians.  I prefer to use degrees, and therefore I convert the radians. 
                if (Main.netMode != NetmodeID.MultiplayerClient)
                    Projectile.NewProjectile(Projectile.GetNoneSource() , Projectile.Center.X, Projectile.Center.Y, ToPlayer.X * 15, ToPlayer.Y * 15, ModContent.ProjectileType<MagicPoisonProj>(), 25, 0f);//fire the projectile
            }

            return true;
        }
    }
}