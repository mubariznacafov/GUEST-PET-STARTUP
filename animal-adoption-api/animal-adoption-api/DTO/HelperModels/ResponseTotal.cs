namespace animal.adoption.api.DTO.HelperModels
{
    public class ResponseTotal<T>
    {
        public List<T> Data { get; set; }
        public decimal Total { get; set; }
    }
}
