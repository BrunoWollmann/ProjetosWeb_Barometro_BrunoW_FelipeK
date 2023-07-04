using Barometro.Dominio.Entidades;
using Barometro.Persistencia.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barometro.Aplicacao.Aplicacao
{
    public class BarometroAplicacao
    {
        private BarometroPersistencia BarometroPersistencia;
        public BarometroAplicacao() {
            BarometroPersistencia = new BarometroPersistencia();
        }

        public Guid Alterar(Barometro Barometro)
        {
            //Executa a validacao das regras de negocio
            if (string.IsNullOrEmpty(Barometro.PRESSURE))
            {
                throw new ApplicationException("erro ao alterar prod");
            }

            return BarometroPersistencia.Alterar(Barometro);
        }

        public Barometro DiminuirValores(Guid id)
        {
            var Barometro = this.SelecionarPorId(id);
            Barometro.ALTITUDE--;
            this.Alterar(Barometro);
            return Barometro;
        }

        public void Excluir(Guid id)
        {
            BarometroPersistencia.Excluir(id);
        }

        public Guid Inserir(Barometro Barometro)
        {
            Barometro.Id= Guid.NewGuid();
            //Executa a validacao das regras de negocio
            if (string.IsNullOrEmpty(Barometro.PRESSURE))
            {
                throw new ApplicationException("Erro ao inserir informação, tente novamente");
            }

            return BarometroPersistencia.Inserir(Barometro);
        }

        public Barometro SelecionarPorId(Guid id)
        {
            var Barometros = BarometroPersistencia.SelecionarTodos();
            var Barometro = Barometros.Where(p => p.Id == id).FirstOrDefault<Barometro>();

            return Barometro;
        }

        public List<Barometro> SelecionarTodos()
        {
            return BarometroPersistencia.SelecionarTodos();
        }
    }
}
