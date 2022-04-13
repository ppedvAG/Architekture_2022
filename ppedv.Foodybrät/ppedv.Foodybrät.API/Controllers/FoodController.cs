using Microsoft.AspNetCore.Mvc;
using ppedv.Foodybrät.API.Model;
using ppedv.Foodybrät.Contracts;
using ppedv.Foodybrät.Logic;
using ppedv.Foodybrät.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ppedv.Foodybrät.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        Core core;
        public FoodController(IUnitOfWork unitOfWork)
        {
            core = new Core(unitOfWork);
        }

        // GET: api/<FoodController>
        [HttpGet]
        public IEnumerable<FoodApiModel> Get()
        {
            foreach (var item in core.UnitOfWork.FoodRepository.Query().ToList())
            {
                yield return new FoodApiModel()
                {
                    Id = item.Id,
                    Description = item.Description,
                    Price = item.Price,
                    Kcal = item.Kcal,
                    Vegan = item.Vegan,
                    Vegetarian = item.Vegetarian
                };
            }
        }

        // GET api/<FoodController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<FoodController>
        [HttpPost]
        public void Post([FromBody] FoodApiModel newFood)
        {
            var f = new Food()
            {
                Description = newFood.Description,
                Price = newFood.Price,
                Kcal = newFood.Kcal,
                Vegetarian = newFood.Vegetarian,
                Vegan = newFood.Vegan
            };

            core.UnitOfWork.FoodRepository.Add(f);
            core.UnitOfWork.SaveAll();
        }

        // PUT api/<FoodController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<FoodController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
