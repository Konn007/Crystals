using Terraria.ID;
using Terraria.ModLoader;

namespace Crystals.Items
{
    public class Leaf : ModItem
    {
        
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Essence of The Forest");
            Tooltip.SetDefault("Its kinda alive but not");
        }
        
        public override void SetDefaults()
        {
            Item.maxStack = 99;
            Item.width = 24;
            Item.height = 30;
            Item.rare = ItemRarityID.Green;
            Item.material = true;
        }
        
    }
}