using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Barometro.Web.Models
{
    public class BarometroModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage ="O campo Pressão deve ser informado")]
        [StringLength(40,ErrorMessage ="A Pressão não pode ter mais do que 40 caracteres")]
        public string PRESSURE { get; set; }
        public decimal ALTITUDE { get; set; }
        public decimal HUMIDITY { get; set; }
        public string DATE { get; set; }
        public Guid TEMPId { get; set; }

        //private string PRESSURE;

        public string PRESSURE
        {
            get
            {
                return PRESSURE;
            }
            set
            {
                PRESSURE = value;
            }
        }

        public string getPRESSURE()
        {
            return PRESSURE;
        }

        public void setPRESSURE(string PRESSURE)
        {
            this.PRESSURE = PRESSURE;
        }

    }
}
