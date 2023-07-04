using Barometro.Dominio.Entidades;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barometro.Persistencia.Persistencia
{
    public class BarometroPersistencia
    {
        public BarometroPersistencia() { }

        public Guid Alterar(Barometro Barometro)
        {
            using (var con = new Npgsql.NpgsqlConnection("Server = localhost; Port = 5432; Database = teste_ftec; User Id = postgres; Password = 217799;"))
            {
                con.Open();
                using (var comando = new NpgsqlCommand())
                {
                    comando.Connection = con;
                    comando.CommandText = "UPDATE public.Barometro SET TEMPid=@TEMPid, PRESSURE=@PRESSURE, ALTITUDE=@ALTITUDE, HUMIDITY=@HUMIDITY, DATE=@DATE WHERE id=@id";
                    comando.Parameters.AddWithValue("id", Barometro.Id);
                    comando.Parameters.AddWithValue("TEMPid", Barometro.TEMPId);
                    comando.Parameters.AddWithValue("PRESSURE", Barometro.PRESSURE);
                    comando.Parameters.AddWithValue("ALTITUDE", Barometro.ALTITUDE);
                    comando.Parameters.AddWithValue("HUMIDITY", Barometro.HUMIDITY);
                    comando.Parameters.AddWithValue("DATE", Barometro.DATE);

                    comando.ExecuteNonQuery();

                }
            }
            return Barometro.Id;
        }

        public void Excluir(Guid id)
        {
            using (var con = new Npgsql.NpgsqlConnection("Server = localhost; Port = 5432; Database = proj_Ftec; User Id = postgres; Password = 517797;"))
            {
                con.Open();
                using (var comando = new NpgsqlCommand())
                {
                    comando.Connection = con;
                    comando.CommandText = "DELETE FROM public.Barometro WHERE id=@id";
                    comando.Parameters.AddWithValue("id", id);

                    comando.ExecuteNonQuery();

                }
            }
        }

        public Guid Inserir(Barometro Barometro)
        {
            
            using (var con = new Npgsql.NpgsqlConnection("Server = localhost; Port = 5432; Database = proj_Ftec; User Id = postgres; Password = 517797;"))
            {
                con.Open();
                using (var comando = new NpgsqlCommand())
                {
                    comando.Connection = con;
                    comando.CommandText = "INSERT INTO public.Barometro (id, TEMPid, PRESSURE, ALTITUDE, HUMIDITY, DATE) VALUES(@id, @TEMPid, @PRESSURE, @ALTITUDE, @HUMIDITY, @DATE);";
                    comando.Parameters.AddWithValue("id",Barometro.Id);
                    comando.Parameters.AddWithValue("TEMPid", Barometro.TEMPId);
                    comando.Parameters.AddWithValue("PRESSURE", Barometro.PRESSURE);
                    comando.Parameters.AddWithValue("ALTITUDE", Barometro.ALTITUDE);
                    comando.Parameters.AddWithValue("HUMIDITY", Barometro.HUMIDITY);
                    comando.Parameters.AddWithValue("DATE", Barometro.DATE);

                    comando.ExecuteNonQuery();

                }
            }
            return Barometro.Id;
        }

        public List<Barometro> SelecionarTodos()
        {
            List<Barometro> Barometros = new List<Barometro>();

            using (var con = new Npgsql.NpgsqlConnection("Server = localhost; Port = 5432; Database = teste_ftec; User Id = postgres; Password = 217799;"))
            {
                con.Open();
                using (var comando = new NpgsqlCommand())
                {
                    comando.Connection = con;
                    comando.CommandText = "SELECT id, TEMPid, PRESSURE, ALTITUDE, HUMIDITY, DATE FROM public.Barometro";
                    
                    var leitor = comando.ExecuteReader();
                    while (leitor.Read())
                    {
                        Barometros.Add(new Barometro
                        {
                            Id = Guid.Parse(leitor["id"].ToString()),
                            TEMPId = Guid.Parse(leitor["TEMPid"].ToString()),
                            PRESSURE = leitor["PRESSURE"].ToString(),
                            HUMIDITY = Convert.ToDecimal( leitor["HUMIDITY"]),
                            ALTITUDE = Convert.ToDecimal(leitor["ALTITUDE"]),
                            DATE = leitor["DATE"].ToString()
                        });
                    }
                }
            }

            return Barometros;
        }
    }
}
