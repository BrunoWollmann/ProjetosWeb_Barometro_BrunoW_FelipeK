using Barometro.Web.Models;

namespace Barometro.Web.Factory
{
    public class BarometroFactory
    {
        public static List<BarometroModel> GeradorMoqBarometros( int numeroObjetos)
        {
            List<BarometroModel> Barometros= new List<BarometroModel>();
            for (int i= 0; i < numeroObjetos; i++)
            {
                Barometros.Add(new BarometroModel()
                {
                    PRESSURE = string.Format("PRESSURE {0}",(i+1)),
                    Id = Guid.NewGuid(),
                    HUMIDITY = 10,
                    ALTITUDE= 10,
                    DATE = "UN",
                    TEMPId = Guid.NewGuid()
                });
            }
            return Barometros;
        }
    }
}
