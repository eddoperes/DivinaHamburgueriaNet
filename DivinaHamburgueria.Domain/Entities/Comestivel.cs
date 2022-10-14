﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DivinaHamburgueria.Domain.Entities
{
    public class Comestivel: Entity
    {

        public Comestivel(string nome)
        {
            Nome = nome;
        }

        public string Nome { get; private set; } = string.Empty;

    }
}
