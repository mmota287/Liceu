using Liceu.Seguranca.Entidades;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Liceu.Seguranca.Dados.Contexto
{
    public class SegurancaContexto: IdentityDbContext<UsuarioAplicacao>
    {
        public SegurancaContexto(DbContextOptions<SegurancaContexto> options)
            : base(options)
        {
        }
    }
}
