using animal.adoption.api.DTO.HelperModels;
using animal.adoption.api.Models;

namespace animal.adoption.api.DTO.ResponseModels.Main
{
    public class ResponseSimple
    {
        public StatusModel Status { get; set; }
        public string TraceID { get; set; }
        public IEnumerable<PET> Data { get; internal set; }
    }
}
