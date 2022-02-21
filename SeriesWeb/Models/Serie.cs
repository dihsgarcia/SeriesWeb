using SeriesWeb.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SeriesWeb.Models
{
    public class Serie : EntidadeBase
    {
        [EnumDataType(typeof(Genero))]
        [DisplayName("Gênero")]
        [Required]
        public Genero Genero { get; set; }

        [Required]
        public string Titulo { get; set; }

        [DisplayName("Descrição")]
        [Required]
        public string Descricao { get; set; }

        [Required]
        [Range(1990, 2030, ErrorMessage = "Range de ano de 1900 a 2030")]
        public int Ano { get; set; }

        [Required]
        public bool Excluido { get; set; }

      
    public string retornaTitulo()
        {
            return this.Titulo;
        }

        public int retornaId()
        {
            return this.Id;
        }
        public bool retornaExcluido()
        {
            return this.Excluido;
        }
        public void Excluir()
        {
            this.Excluido = true;
        }

    }  
    
}
