using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin_Jardim
{
    public class Arvore
    {
        private int id;
        private string especie;
        private double altura;
        private double diametroTronco;
        private int idade;
        private string localizacao;
        private List<string> historicoTratamentos;
        private string condicaoSaude;
        private int jardimId;
        private int canteiroId;
        private string notasAdicionais;
        private DateTime dataInicio;
        private DateTime dataFim;
        private double quantidadeAguaConsumida;
        private DateTime dataPlantio;
        private string equipePlantio;
        private DateTime dataRemocao;
        private string equipeRemocao;

        public Arvore()
        {
            historicoTratamentos = new List<string>();
        }

        public int Id
        {
            get { return id; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("O ID da árvore deve ser um número positivo.");

                id = value;
            }
        }

        public string Especie
        {
            get { return especie; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("O nome da espécie não pode estar vazio.");

                if (value.Length > 128)
                    throw new ArgumentException("O nome da espécie não pode ter mais de 128 caracteres.");

                especie = value;
            }
        }

        public double Altura
        {
            get { return altura; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("A altura da árvore deve ser um número positivo.");

                altura = value;
            }
        }

        public double DiametroTronco
        {
            get { return diametroTronco; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("O diâmetro do tronco da árvore deve ser um número positivo.");

                diametroTronco = value;
            }
        }

        public int Idade
        {
            get { return idade; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("A idade da árvore deve ser um número positivo.");

                idade = value;
            }
        }

        public string Localizacao
        {
            get { return localizacao; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("A localização da árvore não pode estar vazia.");

                localizacao = value;
            }
        }

        public List<string> HistoricoTratamentos
        {
            get { return historicoTratamentos; }
            set { historicoTratamentos = value; }
        }

        public string CondicaoSaude
        {
            get { return condicaoSaude; }
            set { condicaoSaude = value; }
        }

        public int JardimId
        {
            get { return jardimId; }
            set { jardimId = value; }
        }

        public int CanteiroId
        {
            get { return canteiroId; }
            set { canteiroId = value; }
        }

        public string NotasAdicionais
        {
            get { return notasAdicionais; }
            set { notasAdicionais = value; }
        }

        public DateTime DataInicio
        {
            get { return dataInicio; }
            set { dataInicio = value; }
        }

        public DateTime DataFim
        {
            get { return dataFim; }
            set { dataFim = value; }
        }

        public double QuantidadeAguaConsumida
        {
            get { return quantidadeAguaConsumida; }
            set { quantidadeAguaConsumida = value; }
        }

        public DateTime DataPlantio
        {
            get { return dataPlantio; }
            set { dataPlantio = value; }
        }

        public string EquipePlantio
        {
            get { return equipePlantio; }
            set { equipePlantio = value; }
        }

        public DateTime DataRemocao
        {
            get { return dataRemocao; }
            set { dataRemocao = value; }
        }

        public string EquipeRemocao
        {
            get { return equipeRemocao; }
            set { equipeRemocao = value; }
        }
    }
}
