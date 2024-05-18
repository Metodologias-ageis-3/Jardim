using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin_Jardim
{
    public class Arvore
    {
        private string id;
        private string especie;
        private double altura = 0;
        private double diametroTronco = 0;
        private int idade = 0;
        private Jardim jardim;
        private List<string> historicoTratamentos;
        private string condicaoSaude;
        private Canteiro? canteiro=null;
        private string notasAdicionais;
        private double quantidadeAguaConsumida;
        private DateTime dataPlantio;
        private string equipePlantio;
        private DateTime? dataRemocao;
        private string equipeRemocao;
        private string localizacao;

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

                if (int.TryParse(value, out int n))
                    throw new ArgumentException("O nome da espécie não pode ser um inteiro.");

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
            set {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("A condição de saúde não pode estar vazio.");

                if (value.Length > 128)
                    throw new ArgumentException("A condição de saúde não pode ter mais de 128 caracteres.");

                if (int.TryParse(value, out int n))
                    throw new ArgumentException("A condição de saúde não pode ser um inteiro.");

                condicaoSaude = value;
            }
        }

        public Canteiro? Canteiro
        {
            get { return canteiro; }
            set { canteiro = value; }
        }

        public string NotasAdicionais
        {
            get { return notasAdicionais; }
            set {

                if (value.Length > 128)
                    throw new ArgumentException("As notas adicionais e não pode ter mais de 128 caracteres.");

                if (int.TryParse(value, out int n))
                    throw new ArgumentException("As notas adicionais  não pode ser um inteiro.");
                notasAdicionais = value; }
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
            set {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("A equipa não pode estar vazio.");

                if (value.Length > 128)
                    throw new ArgumentException("A equipa não pode ter mais de 128 caracteres.");

                if (int.TryParse(value, out int n))
                    throw new ArgumentException("A equipa não pode ser um inteiro.");
                equipePlantio = value; }
        }

        public DateTime? DataRemocao
        {
            get { return dataRemocao; }
            set {
                if (value != null)
                {
                    if (value < dataPlantio)
                    {
                        throw new ArgumentException("Erro: A data de remoção não pode ser anterior à data de plantio.");

                    }
                }
                dataRemocao = value; }
        }

        public string EquipeRemocao
        {
            get { return equipeRemocao; }
            set {

                if (value.Length > 128)
                    throw new ArgumentException("A equipa não pode ter mais de 128 caracteres.");

                if (int.TryParse(value, out int n))
                    throw new ArgumentException("A equipa não pode ser um inteiro.");
                equipeRemocao = value; }
        }

        public void AdicionarTratamento(string pTratamento)
        {
            List<string> vTratamentos = new List<string>();

            vTratamentos = historicoTratamentos;
            vTratamentos.Add(pTratamento);

            historicoTratamentos = vTratamentos;
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


        public void Apagar()
        {
            string id = "";
            string especie = "";
            double altura = new double();
            double diametroTronco = new double();
            int idade = new int();
            Jardim jardim = null;
            List<string> historicoTratamentos = new List<string>();
            string condicaoSaude = "";
            Canteiro canteiro = null;
            string notasAdicionais = "";
            double quantidadeAguaConsumida = new double();
            DateTime dataPlantio = new DateTime(); 
            string equipePlantio = "";
            DateTime dataRemocao = new DateTime();
            string equipeRemocao = "";
            string localizacao = "";
        }

        public string Nome
        {
            get { return ToString().Replace('\n', ' ').Replace("---",""); }
        }

        public override string ToString()
        {
            return
                  $"---\n"
                + $"Especie: {Especie}\n"
                + $"Altura: {Altura}\n"
                + $"Idade: {Idade}\n"
                + $"Localizacao: {Localizacao}\n";
        }
    }
}
