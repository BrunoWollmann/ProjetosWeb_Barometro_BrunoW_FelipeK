namespace Barrometro.Web.Models
{
    public class Temperaturas
    {
        public int IdTemperatura { get; set; }
        public string Cidade { get; set; }
        public DateTime Data_dado { get; set; }
        public Double Temp_atual { get; set; }
        public Double Temp_max { get; set; }
        public Double Temp_min { get; set; }


        public static List<Temperaturas> ListaTemp()
        {

            List<Temperaturas> lst = new List<Temperaturas>();

            lst.Add(new Temperaturas { IdTemperatura = 0, Cidade = "Caxias do Sul", Data_dado = DateTime.Parse("2023-05-08"), Temp_atual = 18.5, Temp_max = 25, Temp_min = 15 });

            return lst;
        }
    }
}
