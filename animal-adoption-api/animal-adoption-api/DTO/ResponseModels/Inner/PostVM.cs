namespace animal.adoption.api.DTO.ResponseModels.Inner
{
    public class PostVM
    {
        public int Id { get; set; }
        public string? Author { get; set; }
        public string? Content { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
