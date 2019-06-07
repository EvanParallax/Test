using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Task_web.Models;

namespace Task_web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ITestSet _testModels;

        public TestController(ITestSet testModels)
        {
            _testModels = testModels;
        }

        [HttpPost]
        public IActionResult AddModel(string name)
        {
            _testModels.Add(new TestModel()
            {
                Id = Guid.NewGuid(),
                Name = name
            }
            );
            return Ok();
        }

        [HttpGet]
        public IEnumerable<TestModel> GetModels()
        {
            return _testModels.GetModels();
        }

        //Swagger в коре не заводится, если есть несколько методов с одинаковым глаголом, как резолвить не знаю, в основном раньше фреймворк использовал
        //[HttpGet]
        //public TestModel GetModel(Guid id)
        //{
        //    return _testModels.GetModel(id);
        //}


        [HttpDelete]
        public IActionResult DelelteModel(Guid id)
        {
           var result = _testModels.Remove(id);
            if (result)
                return Ok();
            else
                return NotFound();
        }

        [HttpPut]
        public IActionResult UpdateModel(Guid id, string name)
        {
            var result = _testModels.UpdateModel(new TestModel()
            {
                Id = id,
                Name = name
            });
            if (result)
                return Ok();
            else
                return NotFound();
        }
        /*
         *
         * необходимо релизовать CRUD для testModels
         *
         */
    }
}
