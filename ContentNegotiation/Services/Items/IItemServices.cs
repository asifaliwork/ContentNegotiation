﻿using ContentNegotiation.Models.Items;
namespace ContentNegotiation.Services.Items;

public interface IItemServices
{
    public IEnumerable<Item> GetItems();
    public Item AddItem(Item item);
    public Item UpdateItem(int id , Item item);
    public  string DeleteItem(int id);

}
