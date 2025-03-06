

namespace DungeonExplorer
{
    public class Item
    {
        public string itemName;
        public string damageType; // Either damaging or healing
        public int itemDamage;

        public Item(string itemName, string damageType, int itemDamage) // Defines the items variables
        {
            this.itemName = itemName;
            this.damageType = damageType;
            this.itemDamage = itemDamage;
        }


        public override string ToString() // Overrides default string so the item can be printed in the inventory
        {
            return ($"{this.itemName}, Type: {this.damageType}  Ammount: {this.itemDamage}");
        }
    }
}
