using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin_Jardim
{
    public class Jardim
    {
        private int id;
        private string nome;
        private string localizacao;
        private string descricao;
        private double area;
        private string topografia;
        private string equipaResponsavel;
        private string caracteristicasCanteiros;

        public int Id
        {
            get { return id; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("O ID do jardim deve ser um número positivo.");

                id = value;
            }
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
                if (value <= 0)
                    throw new ArgumentException("A área do jardim deve ser um número positivo.");

                area = value;
            }
        }

        public string Topografia
        {
            get { return topografia; }
            set { topografia = value; }
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

        public override string ToString()
        {
            return 
                  $"Nome: {Nome}\n"
                + $"Localização: {Localizacao}\n"
                + $"Descricao: {Descricao}\n"
                + $"Area: {Area}\n"
                + $"Topografia: {Topografia}\n"
                + $"Equipa Responsável: {EquipaResponsavel}\n"
                + $"Características canteiros: {CaracteristicasCanteiros}\n";
        }
    }
}
