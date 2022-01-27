namespace ElasticExample.BusinessLogic.Responses
{
    public abstract record BaseResponse
    {
        public string Message { get; init; } = string.Empty;
        public bool IsSuccess { get; init; }
    }

    public abstract record BaseResponse<T> : BaseResponse where T : BaseResponse, new()
    {
        public static T SuccessResponse() => new()
        {
            IsSuccess = true,
            Message = "Ok"
        };
    }
}
