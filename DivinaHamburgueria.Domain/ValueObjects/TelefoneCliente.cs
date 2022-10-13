using DivinaHamburgueria.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DivinaHamburgueria.Domain.ValueObjects
{
    public class TelefoneCliente: Telefone
    {

        public Cliente? Cliente { get; private set; }

    }
}
