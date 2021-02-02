using System;
using SQLite;

namespace Mine.Models
{
    /*
     * Items for the Characters and Monsters to use. 
     */
    public class ItemModel
    {
        // The id for the Item
        [PrimaryKey]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        // The Display Text for the Item
        public string Text { get; set; }

        // The Description for the Item
        public string Description { get; set; }

        // The value of an Item +9 damage
        public int Value { get; set; } = 0;
    }
}