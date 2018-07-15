using System;
using System.Collections.Generic;

namespace Test.Data.Models
{
    public partial class Sensordata
    {
        public int Id { get; set; }
        public int Value1 { get; set; }
        public string Value2 { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
    }
}
