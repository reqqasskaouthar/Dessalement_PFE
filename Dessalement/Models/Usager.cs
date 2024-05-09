using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Dessalement.Models
{
    public class Usager
    {
        [Required]
        public string typeusage { get; set; }
        [Required]
        public string codeusage { get; set; }
        public string? nom { get; set; }
        public string? prenom { get; set; }
        [Required]
        public string cin { get; set; }
        public string? nationalite { get; set; }
        public DateTime? datenaissance { get;set; }
        public string? lieunaissance { get; set; }
        public string? adresse { get; set; }
        public string? fixe { get; set; }
        public string? portable { get; set; }
        public string? email { get; set; }
        [Required]
        public string propriétaire { get; set; }
        [Required]
        public float superficiesouscrite { get; set; }

    }
}
