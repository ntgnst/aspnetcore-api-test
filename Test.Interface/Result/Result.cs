using System.Collections.Generic;
using Test.Data.Models;

namespace Test.Interface.Result
{
    public class Result<T> : IResult<T>
    {
        private bool v;
        private ResultTypeEnum success;
        private List<Sensordata> list;

        public bool IsSuccess { get; set; }
        public ResultTypeEnum ResultType { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }

        public Result()
        {
            Data = default(T);
        }

        public Result(T Data)
            : this(true, ResultTypeEnum.Success, Data, "Successful")
        {
        }

        public Result(string Message)
           : this(true, ResultTypeEnum.Success, default(T), Message)
        {
        }

        public Result(bool IsSuccess, string Message)
           : this(false, ResultTypeEnum.Error, default(T), Message)
        {
        }

        public Result(bool IsSuccess, ResultTypeEnum ResultType, T Data, string Message)
        {
            this.IsSuccess = IsSuccess;
            this.ResultType = ResultType;
            this.Data = Data;
            this.Message = Message;
        }

        public Result(bool v, ResultTypeEnum success, T data)
        {
            this.v = v;
            this.success = success;
            this.Data = data;
        }
    }
}
