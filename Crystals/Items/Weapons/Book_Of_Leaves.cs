
using Crystals.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Crystals.Items.Weapons
{
    public class Book_of_Leaves : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Photosynthesia");
            Tooltip.SetDefault("An Ancient book from The Witch");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 28;
            Item.height = 30;
            Item.noMelee = true;
            Item.crit = 13;
            Item.DamageType = DamageClass.Magic;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.damage = 17;
            Item.useTime = 5;
            Item.useAnimation = 11;
            Item.knockBack = 0.0f;
            Item.mana = 14;
            Item.rare = ItemRarityID.Green;
            Item.UseSound = SoundID.DD2_BookStaffCast;
            Item.autoReuse = true;

            Item.shoot = ModContent.ProjectileType<LeavesProjectile>();
            Item.shootSpeed = 14.0f;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type,
            int damage, float knockback)
        {
            if (player.manaSick)
            {
                if (!player.manaRegenBuff)
                {
                    player.AddBuff(BuffID.ManaRegeneration , 5*20 , true);
                }
                source.Item.mana = 0;
                return false;
            }else
            {
                player.manaRegenBuff = false;
                source.Item.mana = 18;
            }
            return  true;
        }
        
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback) {
            velocity = velocity.RotatedByRandom(MathHelper.ToRadians(10));
        }

    }
    
    
}