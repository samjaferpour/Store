namespace StoreBE.Dtos
{
    public class ApiResult
    {
        public bool IsSuccess { get; set; }
        public int RsCode { get; set; }
        public string Message { get; set; }
        public object? ResultData { get; set; }
    }
}
