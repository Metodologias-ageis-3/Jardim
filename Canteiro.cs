using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin_Jardim
{
    public class Canteiro
    {
        private string id;
        private string localizacao;
        private Jardim jardim;
        private string composicaoCanteiro;
        private float area;
        private float areaSemeada;

        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Localizacao
        {
            get { return localizacao; }
            set
            {
                // Aqui você pode implementar a validação para verificar se o valor é uma coordenada válida
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("A localização do canteiro não pode estar vazia.");

                localizacao = value;
            }
        }

        public Jardim Jardim
        {
            get { return jardim; }
            set { jardim = value; }
        }

        public string ComposicaoCanteiro
        {
            get { return composicaoCanteiro; }
            set { composicaoCanteiro = value; }
        }

        public float Area
        {
            get { return area; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("A área do canteiro deve ser um número positivo.");

                area = value;
            }
        }

        public float AreaSemeada
        {
            get { return areaSemeada; }
            set { areaSemeada = value; }
        }

        
    }

}

