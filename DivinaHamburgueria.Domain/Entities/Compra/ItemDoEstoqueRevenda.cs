using System;
using System.Collections.Generic;
using System.Text;

namespace DivinaHamburgueria.Domain.Entities
{
    public class ItemDoEstoqueRevenda : ItemDoEstoque
    {

        public int ComestivelId { get; private set; }

        public Comestivel? Comestivel { get; private set; }

        public String Nome
        {
            get
            {
                if (Comestivel != null)
                    return Comestivel.Nome;
                return "";
            }
        }

        public void NotificarComestivel(Comestivel? comestivel)
        {
            Comestivel = comestivel;
        }

    }
}
