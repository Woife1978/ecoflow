namespace EcoflowShared.http.response
{
    public class EcoflowApiResponse<T>
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
        public string EagleEyeTraceId { get; set; }
        public string Tid { get; set; }
    }
}