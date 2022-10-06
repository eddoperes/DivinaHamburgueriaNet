using System;
using System.Collections.Generic;
using System.Text;

namespace DivinaHamburgueria.Domain.Entities
{
    public class Usuario: Entity
    {

        public enum TipoUsuario
        {
            Administrador = 1,
            Auxiliar = 2,
            Caixa = 3
        }

        public enum EstadoUsuario
        {
            Ativado = 1,
            Inativado = 0
        }

        public string Nome { get; private set; } = string.Empty;

        public TipoUsuario Tipo { get; private set; } = TipoUsuario.Caixa;

        public string Email { get; private set; } = string.Empty;

        public string Senha { get; private set; } = string.Empty;

        public string Token { get; private set; } = string.Empty;

        public DateTime DataCriado { get; private set; }

        public DateTime DataAtivado { get; private set; }

        public DateTime DataInativado { get; private set; }

    }
}
