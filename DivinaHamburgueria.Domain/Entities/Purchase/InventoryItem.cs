using DivinaHamburgueria.Domain.Validation;
using DivinaHamburgueria.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;
using static DivinaHamburgueria.Domain.Entities.Menu;
using static DivinaHamburgueria.Domain.Entities.User;

namespace DivinaHamburgueria.Domain.Entities
{
    public class InventoryItem : Entity
    {

        public InventoryItem(string? brand, int content,
                             int unityId, InventoryItemType type, int eatableId) 
        {
            //called by entity framework   
            ValidateDomain(brand, content,
                           unityId, type, eatableId);
        }

        public InventoryItem(int id, string? brand, int content,
                             int unityId, InventoryItemType type, int eatableId)
        {
            DomainExceptionValidation.When(id < 0, "Invalid id. Smaller than zero.");
            this.Id = id;
            //called by mapper
            ValidateDomain(brand, content,
                           unityId, type, eatableId);
        }

        private void ValidateDomain(string? brand, int content, 
                                    int unityId, InventoryItemType type, int eatableId)
        {
            DomainExceptionValidation.When(content <= 0, "Invalid content. Smaller or equal than zero.");
            DomainExceptionValidation.When(unityId <= 0, "Invalid unit id. Smaller or equal than zero.");
            DomainExceptionValidation.When(type < InventoryItemType.Recipe || type > InventoryItemType.Resale, "Invalid type. Out of range 1 to 2.");
            DomainExceptionValidation.When(eatableId <= 0, "Invalid eatable id. Smaller or equal than zero.");
            this.Brand = brand;
            this.Content = content;
            this.UnityId = unityId;
            this.Type = type;
            this.EatableId = eatableId;
        }

        public enum InventoryItemType
        {
            Recipe = 1,
            Resale = 2
        }

        public string? Brand { get; private set; }

        public int Content { get; private set; }

        public int UnityId { get; private set; }

        public Unity? Unity { get; private set; }

        public InventoryItemType Type { get; private set; } = InventoryItemType.Recipe;

        public int EatableId { get; private set; }

        public Eatable? Eatable { get; private set; }

        public String Name
        {
            get
            {
                if (Eatable != null)
                    return Eatable.Name;
                return "";
            }
        }

        public void NotificarComestivel(Eatable? eatable)
        {
            Eatable = eatable;
        }

    }
}
