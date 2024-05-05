namespace rm_api
{
    public class Error
    {
        int Code { get; set; }
        public string Component { get; set; }
        public string Details { get; set; }
        public string Message { get; set; }
    }
}
