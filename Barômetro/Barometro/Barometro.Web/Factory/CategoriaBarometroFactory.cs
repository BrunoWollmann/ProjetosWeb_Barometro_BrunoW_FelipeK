using Barometro.Web.Models;

namespace Barometro.Web.Factory
{
    public class TEMPBarometroFactory
    {
        public static List<TEMPBarometroModel> GeradorMoqTEMPBarometros(int numeroObjetos)
        {
            List<TEMPBarometroModel> TEMPs = new List<TEMPBarometroModel>();
            for (int i = 0; i < numeroObjetos; i++)
            {
                TEMPs.Add(new TEMPBarometroModel()
                {
                    PRESSURE = string.Format("TEMP {0}", (i + 1)),
                    Id = Guid.NewGuid(),
                });
            }
            return TEMPs;
        }
    }
}
