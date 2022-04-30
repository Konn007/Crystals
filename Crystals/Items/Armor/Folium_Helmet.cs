using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Crystals.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class Folium_Helmet : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Folium Helmet");
            Tooltip.SetDefault("Increases dealt Magic damage by 7% \nIncreased maximum mana by 45 \n");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 3;
        }

        public override void SetDefaults()
        {
            Item.width = 26;
            Item.height = 20;
            Item.defense = 5;
            Item.rare = ItemRarityID.Green;
        }

        public override void UpdateEquip(Player player)
        {
            player.statManaMax2 += 45;
            player.GetDamage(DamageClass.Magic) += 0.07f;
        }
        
        public override void UpdateArmorSet(Player player)
        {
            float percent = 0.05f;
            float calc = player.statLifeMax2 * percent;
            player.statManaMax2 += (int)calc;
            player.statLifeMax2 += 15;
            player.setBonus = "5% of your max health(" + calc  + ")is added to your max mana";
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {

            return body.type == ModContent.ItemType<Folium_Breastplate>() && legs.type == ModContent.ItemType<Folium_Boots>();
        }

        public override void AddRecipes()
        {
            Recipe mod = CreateRecipe(1);
            mod.AddIngredient<Leaf>(15);
            mod.AddIngredient(ItemID.JungleHat, 1);
            mod.AddIngredient(ItemID.Wood, 20);
            mod.AddTile(TileID.LivingLoom);
            mod.Register();
        }
    }
}