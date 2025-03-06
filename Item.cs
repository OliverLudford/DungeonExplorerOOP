

namespace DungeonExplorer
{
    public class Item
    {
        public string itemName;
        public int damageType; // 1 is damaging, 2 is healing.
        public int itemDamage;

        public Item(string itemName, int damageType, int itemDamage)
        {
            this.itemName = itemName;
            this.damageType = damageType;
            this.itemDamage = itemDamage;
        }
    }
}
