namespace TrimlightData;

public class Response
{
    public ResultCode Code { get; set; }
    public string Desc { get; set; }
}
public class Response<T> : Response
{
    public T? Payload { get; set; }
}

public class PagedResponse<T> : Response
{
    public DataPage<T>? Payload { get; set; }
}

public class DataPage<T>
{
    public int Total { get; set; }
    public int Page { get; set; }
    public T? Data { get; set; }
}

public enum ResultCode
{
    Success = 0,
    Error = 10001,
    WrongPassword = 10002
}

