using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin_Jardim
{
    public class Arvore
    {
        private string id;
        private string especie;
        private double altura;
        private double diametroTronco;
        private int idade;
        private Jardim jardim;
        private List<string> historicoTratamentos;
        private string condicaoSaude;
        private Canteiro canteiro;
        private string notasAdicionais;
        private double quantidadeAguaConsumida;
        private DateTime dataPlantio;
        private string equipePlantio;
        private DateTime? dataRemocao;
        private string equipeRemocao;

        public Arvore()
        {
            historicoTratamentos = new List<string>();
        }

        public string Id
        {
            get { return id; }
            set
            {
                if (value == "")
                    throw new ArgumentException("O ID da árvore nao pode estar vazio.");

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

        public Jardim Jardim
        {
            get { return jardim; }
            set { jardim = value; }
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

        public Canteiro Canteiro
        {
            get { return canteiro; }
            set { canteiro = value; }
        }

        public string NotasAdicionais
        {
            get { return notasAdicionais; }
            set { notasAdicionais = value; }
        }


        public double QuantidadeAguaConsumida
        {
            get { return quantidadeAguaConsumida; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("O diâmetro do tronco da árvore deve ser um número positivo.");

                quantidadeAguaConsumida = value;
            }
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

        public DateTime? DataRemocao
        {
            get { return dataRemocao; }
            set { dataRemocao = value; }
        }

        public string EquipeRemocao
        {
            get { return equipeRemocao; }
            set { equipeRemocao = value; }
        }

        public override string ToString()
        {
            return
                  $"---\n"
                + $"Especie: {Especie}\n"
                + $"Altura: {Altura}\n"
                + $"Idade: {Idade}\n";
        }
    }
}
