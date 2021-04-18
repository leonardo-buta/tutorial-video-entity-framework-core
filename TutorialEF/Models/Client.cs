using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorialEF.Models
{
    [Table("Clients")]
    public class Client
    {
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(255)")]
        public string Name { get; set; }

        [Column(TypeName = "VARCHAR(255)")]
        public string Email { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }

        [Column("IsActive")]
        public bool Active { get; set; }
    }
}
