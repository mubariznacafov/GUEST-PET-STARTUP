using animal.adoption.api.DTO.HelperModels;
using animal.adoption.api.DTO.ResponseModels.Inner;

namespace animal.adoption.api.DTO.ResponseModels.Main
{
    public class ResponseList<T>
    {
        public StatusModel Status { get; set; }
        public List<T> Data { get; set; }
        public string TraceID { get; set; }
        public StaticVM Response { get; internal set; }
    }
}
