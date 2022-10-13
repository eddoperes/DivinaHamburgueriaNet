﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DivinaHamburgueria.Domain.Entities
{
    public class Ingrediente: Entity
    {

        public Comestivel Comestivel { get; private set; }

        public int Quantidade { get; private set; } = 0;

        public Unidade Unidade { get; private set; }

    }
}
