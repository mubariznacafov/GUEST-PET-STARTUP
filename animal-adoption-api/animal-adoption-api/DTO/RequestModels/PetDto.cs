namespace animal.adoption.api.DTO.RequestModels
{
    public class PetDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Color { get; set; }
        public int? Age { get; set; }
        public string? Shelter { get; set; }
        public int? Size { get; set; }
        public string? HairLength { get; set; }
    }
}
