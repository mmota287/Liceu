using Liceu.Dominio.Servicos.Usuarios;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Security.Claims;

namespace Liceu.Seguranca.Servicos
{
    public class UsuarioServico: IUsuarioServico
    {
        private readonly IHttpContextAccessor _accessor;

        public UsuarioServico(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public string Name => _accessor.HttpContext.User.Identity.Name;

        public bool IsAuthenticated()
        {
            return _accessor.HttpContext.User.Identity.IsAuthenticated;
        }

        public IEnumerable<Claim> GetClaimsIdentity()
        {
            return _accessor.HttpContext.User.Claims;
        }
    }
}
