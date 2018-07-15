using System;
using System.Collections.Generic;
using System.Linq;
using Test.Data.Models;
using Test.Interface;

namespace Test.Service
{
    public class SensorDataService : ISensorDataService
    {
        private SensorDataContext _sensorDataContext;

        public List<Sensordata> GetAll()
        {
            using (_sensorDataContext = new SensorDataContext())
            {
                try
                {
                    return _sensorDataContext.Sensordata.ToList();
                }
                catch (System.Exception ex)
                {
                    return null;
                }
            }
        }
        public Sensordata Update(Sensordata sensordata)
        {
            using (_sensorDataContext = new SensorDataContext())
            {
                try
                {
                    sensordata.UpdateTime = DateTime.UtcNow;
                    var result = _sensorDataContext.Sensordata.Update(sensordata).Entity;
                    _sensorDataContext.SaveChanges();
                    return result;
                }
                catch (System.Exception ex)
                {
                    return null;
                }
            }
        }
        public List<Sensordata> UpdateMany(List<Sensordata> sensorDataList)
        {
            List<Sensordata> sensorListData = new List<Sensordata>();
            using (_sensorDataContext = new SensorDataContext())
            {
                try
                {
                    sensorDataList.ForEach(f=> 
                    {
                        sensorListData.Add(_sensorDataContext.Update(f).Entity);
                    });
                    _sensorDataContext.SaveChanges();
                    return sensorListData;
                }
                catch (System.Exception ex)
                {
                    return null;
                }
            }
        }
        public Sensordata GetById(int id)
        {
            using (_sensorDataContext = new SensorDataContext())
            {
                try
                {
                    return _sensorDataContext.Sensordata.Where(w => w.Id == id).FirstOrDefault();
                }
                catch (System.Exception ex)
                {
                    return null;
                }
            }
        }
        public Sensordata Create(Sensordata sensordata)
        {
            using (_sensorDataContext = new SensorDataContext())
            {
                try
                {
                    sensordata.CreateTime = DateTime.UtcNow;
                    sensordata.UpdateTime = DateTime.UtcNow;
                    var result = _sensorDataContext.Sensordata.Add(sensordata);
                    _sensorDataContext.SaveChanges();
                    return result.Entity;
                }
                catch (System.Exception ex)
                {
                    return null;
                }
            }
        }
        public Sensordata Delete(Sensordata sensordata)
        {
            using (_sensorDataContext = new SensorDataContext())
            {
                try
                {
                    var result = _sensorDataContext.Sensordata.Remove(sensordata).Entity;
                    _sensorDataContext.SaveChanges();
                    return result;
                }
                catch (System.Exception ex)
                {
                    return null;
                }
            }
        }
    }
}
