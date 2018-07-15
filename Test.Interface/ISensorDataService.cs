using System;
using System.Collections.Generic;
using Test.Data.Models;
using Test.Interface.Result;

namespace Test.Interface
{
    public interface ISensorDataService
    {
        Result<List<Sensordata>> GetAll();
        Result<Sensordata> Update(Sensordata sensordata);
        Result<List<Sensordata>> UpdateMany(List<Sensordata> sensorDataList);
        Result<Sensordata> GetById(int id);
        Result<Sensordata> Create(Sensordata sensordata);
        Result<Sensordata> Delete(Sensordata sensordata);
        Result<List<Sensordata>> GetByDate(DateTime startDate, DateTime endDate);
    }
}
