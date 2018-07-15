using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Test.Data.Models;
using Test.Interface;

namespace Test.UI.Controllers
{
    [Route("api/[controller]/[action]")]
    public class ValueController : Controller
    {
        ISensorDataService _sensorDataService;
        private static string _id = "1";
        private static string _pass = "1";
        private static bool isAuthenticated = false;
        public ValueController(ISensorDataService sensorDataService)
        {
            _sensorDataService = sensorDataService;
        }
        [HttpPost]
        public JsonResult Login(string id , string pass)
        {
            if (id.Equals(_id) && pass.Equals(_pass))
            {
                isAuthenticated = true;
                return new JsonResult("Yetkilendirme Başarılı.");
            }
            else
            {
                return new JsonResult("Yetkilendirme Başarısız.");
            }
        }

        [HttpPost]
        public JsonResult Logout()
        {
            if(isAuthenticated == true)
            {
                isAuthenticated = false;
                return new JsonResult("Başarıyla çıkış yapıldı.");
            }
            else
            {
                return new JsonResult("Yetkisiz Erişim Reddedildi.");
            }
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

        [HttpGet]
        public JsonResult GetRecordsWithDate(string startDate, string endDate)
        {
            DateTime start, end;
            start = Convert.ToDateTime(startDate);
            end = Convert.ToDateTime(endDate);
            return new JsonResult(_sensorDataService.GetByDate(start,end));
        }

    }
}
