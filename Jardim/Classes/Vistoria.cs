using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Admin_Jardim
{
    internal class Vistoria
    {
        static public List<string> SINTOMAS = new List<string> {
            "Inclinação Tronco",
            "Codominância Tronco",
            "Codominância Ramos",
            "Casca Inclusa Tronco",
            "Casca Inclusa Ramos",
            "Fendas / Fissuras Colo",
            "Fendas / Fissuras Tronco",
            "Fendas / Fissuras Ramos",
            "Torção Tronco",
            "Fendas / Cicatrizes Colo",
            "Fendas / Cicatrizes Tronco",
            "Fendas / Cicatrizes Ramos",
            "Podridão Colo",
            "Podridão Tronco",
            "Podridão Ramos",
            "Cavidades Colo",
            "Cavidades Tronco",
            "Cavidades Ramos",
            "Estruturas Fungos Colo",
            "Estruturas Fungos Tronco",
            "Estruturas Fungos Ramos",
            "Exsudações Colo",
            "Exsudações Tronco",
            "Exsudações Ramos",
            "Madeira morta Ramos",
            "Cancros Tronco",
            "Cancros Ramos",
            "Rebentos ladrões / Epicórmicos",
            "Pragas Tronco",
            "Pragas Ramos"
        };

        private DateTime dataVistoria;
        private double alturaEstimada;
        private double diametroTronco;
        private double diametroCopa;
        private Dictionary<string, int> sintomas = new Dictionary<string, int>();
        private Arvore arvore;

        public DateTime DataVistoria
        {
            get { return dataVistoria; }
            set { dataVistoria = value; }
        }

        public double AlturaEstimada
        {
            get { return alturaEstimada; }
            set
            {
                if (value < 0 || value > 200) // Limite máximo definido como 200 metros
                    throw new ArgumentException("A altura estimada deve estar entre 0 e 200 metros.");

                alturaEstimada = Math.Round(value, 2);
            }
        }

        public double DiametroTronco
        {
            get { return diametroTronco; }
            set
            {
                if (value < 0 || value > 30) // Limite máximo definido como 30 metros
                    throw new ArgumentException("O diâmetro do tronco deve estar entre 0 e 30 metros.");

                diametroTronco = Math.Round(value, 2);
            }
        }

        public double DiametroCopa
        {
            get { return diametroCopa; }
            set
            {
                if (value < 0 || value > 100) // Limite máximo definido como 100 metros
                    throw new ArgumentException("O diâmetro da copa deve estar entre 0 e 100 metros.");

                diametroCopa = Math.Round(value, 2);
            }
        }

        public Dictionary<string, int> Sintomas
        {
            get { return sintomas; }
            set { sintomas = value; }
        }

        public Arvore Arvore
        {
            get { return arvore; }
            set { arvore = value; }
        }

        public void AdicionarSintoma(string sintoma, int classificacao)
        {
            if (classificacao < 0 || classificacao > 3)
                throw new ArgumentException("A classificação do sintoma deve estar entre 0 e 3.");

            sintomas[sintoma] = classificacao;
        }

        public void RegistrarDataFimArvore()
        {
            if (AlturaEstimada == 0)
            {
                DataVistoria = DateTime.Now;
            }
        }

        public override string ToString()
        {
            return
                  "---\n"
                + $"Data: {DataVistoria:dd/MM/yyyy}\n"
                + $"Altura Estimada: {AlturaEstimada:F2}\n"
                + $"Diâmetro do tronco: {DiametroTronco:F2}\n"
                + $"Diâmetro da copa: {DiametroCopa:F2}\n";
        }
    }
}
