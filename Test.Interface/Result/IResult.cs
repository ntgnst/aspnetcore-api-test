﻿namespace Test.Interface.Result
{
    public interface IResult<T> : IResult
    {
        T Data { get; set; }
    }

    public interface IResult
    {
        bool IsSuccess { get; set; }
        string Message { get; set; }
        ResultTypeEnum ResultType { get; set; }
    }
}
