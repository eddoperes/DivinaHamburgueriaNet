using DivinaHamburgueria.Application.Hypermedia;
using DivinaHamburgueria.Application.Hypermedia.Abstract;
using System.Collections.Generic;

namespace DivinaHamburgueria.Application.DTOs
{
    public class QuantityAlarmTriggeredDTO: ISupportsHypermedia
    {

        public int Id { get; set; }

        public int EatableId { get; set; }

        public int MinimumQuantity { get; set; }

        public float VerifiedQuantity { get; set; }

        public int UnityId { get; set; }

        public List<HypermediaLink> Links { get; set; } = new List<HypermediaLink>();

    }
}
