namespace TheSlum.Items
{
    using System;

    public static class ItemFactory
    {
        public static Item Create(string itemType, string id)
        {
            switch (itemType)
            {
                case "axe":
                    return new Axe(id);
                case "pill":
                    return new Pill(id);
                case "injection":
                    return new Injection(id);
                case "shield":
                    return new Shield(id);

                default:
                    throw new ArgumentException("Invalid item type.");
            }
        }
    }
}
