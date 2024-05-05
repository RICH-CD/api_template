namespace rm_api
{
    public class Response
    {
        public object Data { get; set; }

        public bool Success { get; set; }

        public string Message { get; set; }

        public string[] Error { get; set; }

        public int Code { get; set; }
    }
}