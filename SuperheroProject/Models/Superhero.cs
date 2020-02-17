using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SuperheroProject.Models
{
    public class Superhero
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string AlterEgo { get; set; }
        [Required]
        public string PrimaryAbility { get; set; }
        public string SecondaryAbility { get; set; }
        [Required]
        public string CatchPhrase { get; set; }
    }
}
