using animal.adoption.api.DTO.HelperModels;

namespace animal.adoption.api.DTO.ResponseModels.Main
{
    public class ResponseListTotal<T>
    {
        public StatusModel Status { get; set; }
        public ResponseTotal<T> Response { get; set; }
        public string TraceID { get; set; }
    }
}
