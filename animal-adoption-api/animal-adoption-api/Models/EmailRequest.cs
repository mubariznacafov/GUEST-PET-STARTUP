using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace animal.adoption.api.Models
{  
        public class EmailRequest
        {

        [Column("id"), Key]
        public int Id { get; set; }

        [Column("email")]
        public string Email { get; set; }
        }
        

    }

