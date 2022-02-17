namespace MarsRovers.Dtos
{
    public class ResponseDto
    {
        public object Data { get; set; }
        public string Error { get; set; }
        public int StatusCode { get; set; }
        public bool IsSuccess { get; set; }

        public static ResponseDto Success(int statusCode, object Data)
        {
            return new ResponseDto { Data = Data, StatusCode = statusCode, IsSuccess = true };
        }

        public static ResponseDto Fail(int statusCode, string error)
        {
            return new ResponseDto { StatusCode = statusCode, Error = error, IsSuccess = false };
        }
    }
}
