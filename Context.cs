using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin_Jardim
{
    internal class Context
    {
        public List<Jardim> jardins;
        public List<Canteiro> canteiros;
        public List<Arvore> arvores;

        public Context(bool populate = false)
        {
            if (populate)
            {
                Populate();
                return;
            }

            jardins = new List<Jardim>();
            canteiros = new List<Canteiro>();
            arvores = new List<Arvore>();
        }

        private void Populate()
        {
            jardins = new List<Jardim>
            {
                new Jardim {
                    Id = Guid.NewGuid().ToString(),
                    Nome = "Jardim da cordoaria",
                    Localizacao = "Porto",
                },
                new Jardim {
                    Id = Guid.NewGuid().ToString(),
                    Nome = "Jardins do palácio de cristal",
                    Localizacao = "Porto",
                },
                new Jardim {
                    Id = Guid.NewGuid().ToString(),
                    Nome = "Jardins de Majorelle",
                    Localizacao = "Marrakesh",
                },
            };
        }
    }
}
