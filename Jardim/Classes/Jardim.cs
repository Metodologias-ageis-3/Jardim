using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin_Jardim
{
    public class Jardim
    {
        private string id;
        private string nome;
        private string localizacao = "";
        private string descricao = "";
        private double area = 0;
        private string topografia = "";
        private string equipaResponsavel = "";
        private string caracteristicasCanteiros = "";
        private List<Canteiro> canteiros = new List<Canteiro>();
        private List<Arvore> arvores = new List<Arvore>();

        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Nome
        {
            get { return nome; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("O nome do jardim não pode estar vazio.");

                if (value.Length > 128)
                    throw new ArgumentException("O nome do jardim não pode ter mais de 128 caracteres.");

                nome = value;
            }
        }

        public string Localizacao
        {
            get { return localizacao; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("A localização do jardim não pode estar vazia.");

                localizacao = value;
            }
        }

        public string Descricao
        {
            get { return descricao; }
            set
            {
                if (value != null && value.Length > 512)
                    throw new ArgumentException("A descrição do jardim não pode ter mais de 512 caracteres.");

                descricao = value;
            }
        }

        public double Area
        {
            get { return area; }
            set
            {
                if (!double.TryParse(value.ToString(), out double parsedValue) || parsedValue < 0)
                    throw new ArgumentException("A área do jardim deve ser um número positivo.");

                area = parsedValue;
            }
        }

        public string Topografia
        {
            get { return topografia; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("A topografia do jardim não pode estar vazia.");

                localizacao = value;
            }
        }

        public string EquipaResponsavel
        {
            get { return equipaResponsavel; }
            set { equipaResponsavel = value; }
        }

        public string CaracteristicasCanteiros
        {
            get { return caracteristicasCanteiros; }
            set { caracteristicasCanteiros = value; }
        }

        public List<Canteiro> MostrarCanteiros() { 
            return canteiros;
        }

        public override string ToString()
        {
            return 
                  $"---\n"
                + $"Nome: {Nome}\n"
                + $"Localização: {Localizacao}\n"
                + $"Descricao: {Descricao}\n"
                + $"Area: {Area}\n"
                + $"Topografia: {Topografia}\n"
                + $"Equipa Responsável: {EquipaResponsavel}\n"
                + $"Características canteiros: {CaracteristicasCanteiros}\n";
        }

        public void AdicionarCanteiro(Canteiro canteiro)
        {
            canteiros.Add(canteiro);
        }
        public void AdicionarArvore(Arvore arvore)
        {
            arvores.Add(arvore);
        }
        public void DeleteArvore(Arvore arvore)
        {
            arvores.Remove(arvore);
        }
    }
}
