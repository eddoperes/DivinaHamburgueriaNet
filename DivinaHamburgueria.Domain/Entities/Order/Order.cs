using DivinaHamburgueria.Domain.Validation;
using System;

namespace DivinaHamburgueria.Domain.Entities
{
    public abstract class Order: Entity
    {

        public Order(int userId, int customerId, decimal total, 
                     string? observation = null, DateTime? creationDate = null)
        {
            //called by entity framework   
            ValidateDomain(userId, customerId, total,
                           observation, creationDate);
        }

        public Order(int id, int userId, int customerId, decimal total,
                     string? observation = null, DateTime? creationDate = null)
        {
            DomainExceptionValidation.When(id < 0, "Invalid id. Smaller than zero.");
            this.Id = id;
            //called by mapper
            ValidateDomain(userId, customerId, total,
                           observation, creationDate);
        }

        private void ValidateDomain(int userId, int customerId, decimal total,
                                    string? observation = null, DateTime? creationDate = null)
        {            
            DomainExceptionValidation.When(userId <= 0, "Invalid user id. Smaller or equal than zero.");            
            DomainExceptionValidation.When(customerId <= 0, "Invalid customer id. Smaller or equal than zero.");
            DomainExceptionValidation.When(total <= 0, "Invalid total. Smaller or equal than zero.");
            this.UserId = userId;
            this.Observation = observation;
            this.CustomerId = customerId;
            this.Total = total;
            this.CreationDate = creationDate;           
        }

        public int UserId { get; private set; }

        public User? User { get; private set; }

        public string? Observation { get; private set; }

        public int CustomerId { get; private set; }

        public Customer? Customer { get; private set; }

        public decimal Total { get; private set; }

        public DateTime? CreationDate { get; private set; }

    }
}
