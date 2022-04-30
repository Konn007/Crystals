using Crystals.Projectiles;
using Terraria.ID;
using Terraria.ModLoader;

namespace Crystals.Items.Weapons
{
    public class Litnum : ModItem
    {
        public override void SetStaticDefaults()
        {
            ItemID.Sets.Yoyo[Item.type] = true;
            ItemID.Sets.GamepadExtraRange[Item.type] = 16;
            ItemID.Sets.GamepadSmartQuickReach[Item.type] = true;
        }

        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 26;

            Item.DamageType = DamageClass.Melee;
            Item.noMelee = true;
            Item.damage = 14;
            Item.knockBack = 3.5f;
            Item.crit = 10;
            Item.channel = true;

            Item.noUseGraphic = true;
            Item.useTime = 24;
            Item.useAnimation = 24;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.rare = ItemRarityID.Green;
            Item.shoot = ModContent.ProjectileType<LitnumProjectile>();
        }
    }
}