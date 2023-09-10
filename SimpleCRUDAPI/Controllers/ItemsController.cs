using Microsoft.AspNetCore.Mvc;
using SimpleCRUDAPI.Data;
using SimpleCRUDAPI.Models;
using System.Collections.Generic;

[ApiController]
[Route("api/v1/[controller]")]
public class ItemsController : ControllerBase
{
    private readonly ItemRepository itemRepository;

    public ItemsController()
    {
        itemRepository = new ItemRepository();
    }

    [HttpGet]
    public IEnumerable<Item> GetItems()
    {
        return itemRepository.GetItems();
    }

    [HttpGet("{id}")]
    public Item GetItem(int id)
    {
        return itemRepository.GetItem(id);
    }

    [HttpPost]
    public void CreateItem(Item item)
    {
        itemRepository.CreateItem(item);
    }

    [HttpPut]
    public void UpdateItem(Item item)
    {
        itemRepository.UpdateItem(item);
    }

    [HttpDelete("{id}")]
    public void DeleteItem(int id)
    {
        itemRepository.DeleteItem(id);
    }
}
