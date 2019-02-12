using System;

namespace Liceu.Dominio.Compartilhado
{
    public abstract class Entidade
    {
        public Guid Id { get; set; }

        public DateTime DataCriacao { get; set; }

        public DateTime DataAtualizacao { get; set; }
    }
}
