using DivinaHamburgueria.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DivinaHamburgueria.Domain.ValueObjects
{

    public class EnderecoCliente: Endereco
    {

        public Cliente Cliente { get; private set; }

    }

}
