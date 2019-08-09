using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductApp.Models;


namespace ProductApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        Item[] items = new Item[]
        {
            new Item { Id = 1, Name = "Tomato Soup", ItemOwner = "Tom" },
            new Item { Id = 2, Name = "Yo-yo", ItemOwner = "Jerry" },
            new Item { Id = 3, Name = "Hammer", ItemOwner = "Pink Panther" },
            new Item { Id = 4, Name = "Car", ItemOwner = "Scooby Doo!" },
            new Item { Id = 5, Name = "Nails", ItemOwner = "Joe" },
            new Item { Id = 6, Name = "Rope", ItemOwner = "John" },
            new Item { Id = 7, Name = "Frames", ItemOwner = "Doe" },
            new Item { Id = 8, Name = "Paint", ItemOwner = "Jane" }
        };

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Item>> Get()
        {            
            return items;            
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Item> Get(int id)
        {
            var item = items.FirstOrDefault((p) => p.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);        
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] Item value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Item value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}