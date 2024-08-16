using ContentNegotiation.Models.Items;
using ContentNegotiation.Services.Items;
using Microsoft.AspNetCore.Mvc;

namespace ContentNegotiation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemsController : ControllerBase
    {
        private readonly IItemServices _item;




        public ItemsController(IItemServices item)
        {
            _item = item;
        }

        [HttpGet("GetAll")]
        [Produces("text/html")]
        public IActionResult GetProducts()
        {
            // The HtmlOutputFormatter will automatically format the response as text/html
            return Ok();
        }

        [HttpGet("Display")]
        public IEnumerable<Item> Display()
        {
            var item = _item.GetItems();

            return item;
        }
        [HttpGet("Index")]
        public string Index()
        {
            return "asadasd";
        }

        [HttpPost("Create")]
        public IActionResult Create(Item obj)
        {
            if (ModelState.IsValid)
            {
                _item.AddItem(obj);
            }
            return Ok(obj);
        }
        [HttpPost("Update")]
        public IActionResult Update(int id, Item obj)
        {
            var asd = _item.UpdateItem(id, obj);
            return Ok(obj);
        }

        [HttpPost("Delete")]
        public IActionResult Delete(int Id)
        {
            var asd = _item.DeleteItem(Id);
            return Ok(Id);
        }
    }
}
