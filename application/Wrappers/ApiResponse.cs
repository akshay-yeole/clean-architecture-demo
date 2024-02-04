namespace application.Wrappers
{
    public class ApiResponse<T>
    {
        public ApiResponse()
        {
            
        }

        //Success
        public ApiResponse(T data, string message = null)
        {
            Suceeded = true;
            Message = message;
            Data = data;
        }

        //Failure
        public ApiResponse(string message)
        {
            Suceeded = false;
            Message = message;
        }
        public string Message { get; set; }
        public bool Suceeded { get; set; }
        public List<String> Errors { get; set; }
        public T Data { get; set; }
    }
}
