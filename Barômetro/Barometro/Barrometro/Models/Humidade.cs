namespace Barrometro.Web.Models
{
    public class Humidade
    {
        public int IdHumidade { get; set; }
        public string Cidade { get; set; }
        public DateTime Data_dado { get; set; }
        public Double Hum_atual { get; set; }
        public Double Hum_max { get; set; }
        public Double Hum_min { get; set; }


        public static List<Humidade> ListaTemp()
        {

            List<Humidade> lst = new List<Humidade>();

            lst.Add(new Humidade { IdHumidade = 12, Cidade = "Garibaldi", Data_dado = DateTime.Parse("2023-05-09"), Hum_atual = 68 , Hum_max = 75, Hum_min = 50});

            return lst;
        }
    }
}
