using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Liceu.Dominio.Servicos.Usuarios
{
    public interface IUsuarioServico
    {
        string Name { get; }
        bool IsAuthenticated();
        IEnumerable<Claim> GetClaimsIdentity();
    }
}
