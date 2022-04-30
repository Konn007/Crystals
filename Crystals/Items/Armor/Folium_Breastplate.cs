using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Crystals.Items.Armor
{
    [AutoloadEquip(EquipType.Body)]
    public class Folium_Breastplate : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Folium Breastplate");
            Tooltip.SetDefault("Increases dealt Magic damage by 8% \nIncreased maximum mana by 25");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 3;
        }

        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 20;
            Item.defense = 7;
            Item.rare = ItemRarityID.Green;
        }

        public override void UpdateEquip(Player player)
        {
            player.statManaMax2 += 25;
            player.GetDamage(DamageClass.Magic) += 0.08f;
        }

        public override void UpdateArmorSet(Player player)
        {
            player.statLifeMax2 += 15;
        }
        
        

        public override void AddRecipes()
        {
            Recipe mod = CreateRecipe(1);
            mod.AddIngredient<Leaf>(25);
            mod.AddIngredient(ItemID.JungleShirt, 1);
            mod.AddIngredient(ItemID.Wood, 40);
            mod.AddTile(TileID.LivingLoom);
            mod.Register();
        }
    }
}