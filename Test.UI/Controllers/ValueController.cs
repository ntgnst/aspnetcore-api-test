using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Test.Data.Models;
using Test.Interface;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Test.UI.Controllers
{
    [Route("api/[controller]/[action]")]
    public class ValueController : Controller
    {
        ISensorDataService _sensorDataService;
        public ValueController(ISensorDataService sensorDataService)
        {
            _sensorDataService = sensorDataService;
        }

        [HttpGet]
        public JsonResult GetList()
        {
            return new JsonResult(_sensorDataService.GetAll());
        }

        [HttpGet]
        public JsonResult GetById(int id)
        {
            return new JsonResult(_sensorDataService.GetById(id));
        }

        [HttpPost]
        public JsonResult UpdateRecords([FromBody]List<Sensordata> sensorDataList)
        {
            return new JsonResult(_sensorDataService.UpdateMany(sensorDataList));
        }

        [HttpPost]
        public JsonResult UpdateRecord([FromBody]Sensordata sensordata)
        {
            return new JsonResult(_sensorDataService.Update(sensordata));
        }

        [HttpPost]
        public JsonResult AddRecord([FromBody]Sensordata sensordata)
        {
            return new JsonResult(_sensorDataService.Create(sensordata));
        }

        [HttpPost]
        public JsonResult DeleteRecord([FromBody]Sensordata sensordata)
        {
            return new JsonResult(_sensorDataService.Delete(sensordata));
        }

    }
}
