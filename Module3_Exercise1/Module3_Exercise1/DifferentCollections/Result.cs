using System;

namespace Module3_Exercise1.DifferentCollections;

public class Result<T> where T : class // constraint
{
    public T Data { get; set; }

    public int Status { get; set; }

    public T GetResult()
    {
        return Data;
    }

    public void SetResult(T value)
    {
        Data = value;
    }
}

