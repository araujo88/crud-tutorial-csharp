using SimpleCRUDAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace SimpleCRUDAPI.Data
{
    public class ItemRepository
    {
        private readonly List<Item> items = new()
    {
        new Item { Id = 1, Name = "Item 1" },
        new Item { Id = 2, Name = "Item 2" }
    };

        public IEnumerable<Item> GetItems()
        {
            return items;
        }

        public Item GetItem(int id)
        {
            return items.FirstOrDefault(item => item.Id == id);
        }

        public void CreateItem(Item item)
        {
            items.Add(item);
        }

        public void UpdateItem(Item item)
        {
            var index = items.FindIndex(existingItem => existingItem.Id == item.Id);
            items[index] = item;
        }

        public void DeleteItem(int id)
        {
            var item = items.First(existingItem => existingItem.Id == id);
            items.Remove(item);
        }
    }
}