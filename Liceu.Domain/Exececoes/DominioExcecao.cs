using System;
using System.Collections.Generic;
using System.Text;

namespace Liceu.Dominio.Exececoes
{
    public class DominioExcecao : Exception
    {
        public DominioExcecao(string message) : base(message)
        {
        }
    }
}
