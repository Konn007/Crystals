using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Crystals.Items.Armor
{
    [AutoloadEquip(EquipType.Legs)]
    public class Folium_Boots : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Folium Boots");
            Tooltip.SetDefault("Increases dealt Magic damage by 5% \nIncreased maximum mana by 25");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 3;
        }

        public override void SetDefaults()
        {
            Item.width = 22;
            Item.height = 18;
            Item.defense = 6;
            Item.rare = ItemRarityID.Green;
        }
        
        public override void UpdateArmorSet(Player player)
        {
            player.statLifeMax2 += 15;
        }
        
        public override void UpdateEquip(Player player)
        {
            player.statManaMax2 += 25;
            player.GetDamage(DamageClass.Magic) += 0.05f;
        }

        public override void AddRecipes()
        {
            Recipe mod = CreateRecipe(1);
            mod.AddIngredient<Leaf>(20);
            mod.AddIngredient(ItemID.JunglePants, 1);
            mod.AddIngredient(ItemID.Wood, 30);
            mod.AddTile(TileID.LivingLoom);
            mod.Register();
        }
    }
}