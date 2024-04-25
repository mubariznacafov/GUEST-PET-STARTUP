using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace animal.adoption.api.Models
{
    public class POST
    {
     [Column("id"), Key]
     public int Id { get; set; }

     [Column("author")]
     public string? Author { get; set; }

     [Column("content")]
     public string? Content { get; set; }

     [Column("created_at")]
     public DateTime? CreatedAt { get; set; }

     [Column("created_by")]
     public string? CreatedBy { get; set; }

     [Column("updated_at")]
     public DateTime? UpdatedAt { get; set; }

     [Column("updated_by")]
     public string? UpdatedBy { get; set; }
    }
}
