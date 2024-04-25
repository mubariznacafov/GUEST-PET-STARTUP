using animal.adoption.api.Enums;

namespace animal.adoption.api.DTO.ResponseModels.Inner
{
    public class PetVM
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Color { get; set; }
        public PetType? PetType {  get; set; }
        public int? Age { get; set; }
        public string? Shelter { get; set; }
        public int? Size { get; set; }
        public string? HairLength { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

    }
}
