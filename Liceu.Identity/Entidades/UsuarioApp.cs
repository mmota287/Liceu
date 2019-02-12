using System;
using System.Collections.Generic;
using System.Text;

namespace Liceu.Seguranca.Entidades
{
    public class UsuarioApp
    {
        public int IdUsuario { get; set; }

        public string Cpf { get; set; }

        public virtual UsuarioAplicacao UsuarioAplicacao { get; set; }
    }
}
