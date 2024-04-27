using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metodologias_ágeis
{
    internal class Canteiro
    {
        private int id;
        private string localizacao;
        private int jardimId;
        private string composicaoCanteiro;
        private float area;
        private float areaSemeada;
        private Arvore arvore;

        public int Id
        {
            get { return id; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("O ID do canteiro deve ser um número positivo.");

                id = value;
            }
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

        public int JardimId
        {
            get { return jardimId; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("O ID do jardim do canteiro deve ser um número positivo.");

                jardimId = value;
            }
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

        public Arvore Arvore
        {
            get { return arvore; }
            set
            {
                if (value == null)
                    throw new ArgumentException("A árvore do canteiro não pode estar vazia.");

                arvore = value;
            }
        }
    }

}

