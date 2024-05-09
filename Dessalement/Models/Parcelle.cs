using System.ComponentModel.DataAnnotations;

namespace Dessalement.Models
{
    public class Parcelle
    {
        [Key]
        public string codeparcelle { get; set; }
        public string commune { get; set; }
        public float superficiebrute { get; set; }
        public float superficienette { get; set; }
        public int allocation { get; set; }
        public Usager? usager { get; set; }
        
    }
}

