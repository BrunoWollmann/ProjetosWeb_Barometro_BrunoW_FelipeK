using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Barometro.API.Models
{
    public class BarometroModel
    {
        public Guid Id { get; set; }

        public string Descricao { get; set; }
        public decimal QuantidadeEstoque { get; set; }
        public decimal Preco { get; set; }
        public string UnidadeMedida { get; set; }
        public Guid CategoriaId { get; set; }


    }
}
