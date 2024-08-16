using ContentNegotiation.Models.Items;
using ContentNegotiation.Data;

namespace ContentNegotiation.Services.Items;

public class ItemServices : IItemServices
{
    private readonly ApplicationDbContext _db;
    public ItemServices (ApplicationDbContext db)
    {
        _db = db;
    }
   
    public Item AddItem(Item item)
    {
        _db.Items.Add(item);
        _db.SaveChanges();
        return item;
    }

    public string DeleteItem(int id)
    {
        try
        {       
            var item = _db.Items.SingleOrDefault(x => x.Id == id);
            _db.Items.Remove(item!);
            _db.SaveChanges ();
            return "Done";
        }
        catch (Exception ex)
        {
            throw new  Exception(ex.Message);
        }     
    }
    public IEnumerable<Item> GetItems()
    {
        return _db.Items.ToList();
    }

    public  Item UpdateItem(int id ,Item item)
    {
        try
        { 
            _db.Items.Update(item);
            _db.SaveChanges();
            return item;
        }
        catch (Exception ex)
        {
            return new Item { Message = ex.Message};
        }
    }
}
