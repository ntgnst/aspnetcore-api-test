using System;
using System.Collections.Generic;
using Test.Data.Models;

namespace Test.Interface
{
    public interface ISensorDataService
    {
        List<Sensordata> GetAll();
        Sensordata Update(Sensordata sensordata);
        List<Sensordata> UpdateMany(List<Sensordata> sensorDataList);
        Sensordata GetById(int id);
        Sensordata Create(Sensordata sensordata);
        Sensordata Delete(Sensordata sensordata);
        List<Sensordata> GetByDate(DateTime startDate, DateTime endDate);
    }
}
