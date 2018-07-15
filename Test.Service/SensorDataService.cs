using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using Test.Data.Models;
using Test.Interface;
using Test.Interface.Result;

namespace Test.Service
{
    public class SensorDataService : ISensorDataService
    {
        private SensorDataContext _sensorDataContext;
        private ILogger _logger;
        public SensorDataService(ILogger<SensorDataService> logger)
        {
            _logger = logger;
        }
        public Result<List<Sensordata>> GetAll()
        {
            Result<List<Sensordata>> result;
            using (_sensorDataContext = new SensorDataContext())
            {
                try
                {
                    result = new Result<List<Sensordata>>(_sensorDataContext.Sensordata.ToList());

                }
                catch (Exception ex)
                {
                    result = new Result<List<Sensordata>>(false, $"Service GetAll Method Ex: {ex.ToString()}");
                    _logger.LogError(ex.ToString(), ex);
                    return null;
                }
                return result;
            }
        }
        public Result<Sensordata> Update(Sensordata sensordata)
        {
            Result<Sensordata> result;
            using (_sensorDataContext = new SensorDataContext())
            {
                try
                {
                    sensordata.CreateTime = _sensorDataContext.Sensordata.FirstOrDefault(f => f.Id == sensordata.Id).CreateTime;
                    sensordata.UpdateTime = DateTime.UtcNow;
                    _sensorDataContext.Entry(sensordata).CurrentValues.SetValues(sensordata);
                    _sensorDataContext.SaveChanges();
                    result = new Result<Sensordata>(sensordata);
                }
                catch (Exception ex)
                {
                    result = new Result<Sensordata>(false, $"Service Update Method Ex: {ex.ToString()}");
                    _logger.LogError(ex.ToString(), ex);
                }
                return result;
            }
        }
        public Result<List<Sensordata>> UpdateMany(List<Sensordata> sensorDataList)
        {
            Result<List<Sensordata>> result;
            List<Sensordata> sensorListData = new List<Sensordata>();
            using (_sensorDataContext = new SensorDataContext())
            {
                try
                {
                    sensorDataList.ForEach(f =>
                    {
                        sensorListData.Add(_sensorDataContext.Update(f).Entity);
                    });
                    _sensorDataContext.SaveChanges();
                    result = new Result<List<Sensordata>>(sensorListData);
                }
                catch (Exception ex)
                {
                    result = new Result<List<Sensordata>>(false, $"Service UpdateMany Method Ex: {ex.ToString()}");
                    _logger.LogError(ex.ToString(), ex);
                }
                return result;
            }
        }
        public Result<Sensordata> GetById(int id)
        {
            Result<Sensordata> result;
            using (_sensorDataContext = new SensorDataContext())
            {
                try
                {
                    result = new Result<Sensordata>(_sensorDataContext.Sensordata.Where(w => w.Id == id).FirstOrDefault());
                }
                catch (Exception ex)
                {
                    result = new Result<Sensordata>(false,$"Service GetById Method Ex: {ex.ToString()}");
                    _logger.LogError(ex.ToString(), ex);
                }
                return result;
            }
        }
        public Result<Sensordata> Create(Sensordata sensordata)
        {
            Result<Sensordata> result;
            using (_sensorDataContext = new SensorDataContext())
            {
                try
                {
                    sensordata.CreateTime = DateTime.UtcNow;
                    sensordata.UpdateTime = DateTime.UtcNow;
                    result = new Result<Sensordata>(_sensorDataContext.Sensordata.Add(sensordata).Entity);
                    _sensorDataContext.SaveChanges();
                }
                catch (Exception ex)
                {
                    result = new Result<Sensordata>(false, $"Service Create Method Ex: {ex.ToString()}");
                    _logger.LogError(ex.ToString(), ex);
                }
                return result;
            }
        }
        public Result<Sensordata> Delete(Sensordata sensordata)
        {
            Result<Sensordata> result;
            using (_sensorDataContext = new SensorDataContext())
            {
                try
                {
                    result = new Result<Sensordata>(_sensorDataContext.Sensordata.Remove(sensordata).Entity);
                    _sensorDataContext.SaveChanges();
                }
                catch (Exception ex)
                {
                    result = new Result<Sensordata>(false, $"Service Delete Method Ex: {ex.ToString()}");
                    _logger.LogError(ex.ToString(), ex);
                }
                return result;
            }
        }

        public Result<List<Sensordata>> GetByDate(DateTime startDate, DateTime endDate)
        {
            Result<List<Sensordata>> result;
            using (_sensorDataContext = new SensorDataContext())
            {
                try
                {
                    result = new Result<List<Sensordata>>(_sensorDataContext.Sensordata.Where(s => s.CreateTime >= startDate && s.CreateTime <= endDate).ToList());
                }
                catch (Exception ex)
                {
                    result = new Result<List<Sensordata>>(false, $"Service GetByDate Method Ex: {ex.ToString()}");
                    _logger.LogError(ex.ToString(), ex);
                }
                return result;
            }
        }
    }
}
