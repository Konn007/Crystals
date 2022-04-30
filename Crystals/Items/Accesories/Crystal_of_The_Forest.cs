using Crystals.Projectiles;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Crystals.Items.Accesories
{
    public class Crystal_of_The_Forest : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Crystal of The Forest");
            Tooltip.SetDefault("The Core of the Witch");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 32;
            Item.rare = ItemRarityID.Expert;
            Item.accessory = true;
            Item.shoot = ModContent.ProjectileType<LeafProj>();
        }

        public override void UpdateEquip(Player player)
        {
            player.statLifeMax2 += 50;
            if (player.GetModPlayer<CrystPlayer>().ForestCrystal)
            {
                player.GetModPlayer<CrystPlayer>().ForestCrystal = false; 
            }
            else
            {
                player.GetModPlayer<CrystPlayer>().ForestCrystal = true;
            }
        }

    }
}