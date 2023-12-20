using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ListaDePostos.Models
{
    public class PostoDeAbastecimento
    {
        public int Id { get; set; }
        [Required]
        [StringLength(15)]
        public string Cnpj { get; set; }

        [Required]
        [StringLength(80)]
        public string Nome { get; set; }
        [Required]
        [StringLength(80)]
        public string Endereco { get; set; }
        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal PrecoGasolina { get; set; }
        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal PrecoAlcool { get; set; }
        public bool Banheiro { get; set; }
        public bool LavaJato { get; set; }
        public bool Calibrador { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime DataCadastro { get; set; }
    }
}
