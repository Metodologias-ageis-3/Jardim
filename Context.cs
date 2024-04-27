using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin_Jardim
{
    internal class Context
    {
        public List<Canteiro> canteiros = new List<Canteiro>();
        public List<Arvore> arvores = new List<Arvore>();
        public List<Jardim> jardim = new List<Jardim>();
    }
}
