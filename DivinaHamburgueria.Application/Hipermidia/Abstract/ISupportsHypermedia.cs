using System.Collections.Generic;

namespace DivinaHamburgueria.Application.Hypermedia.Abstract
{
    public interface ISupportsHypermedia
    {

        List<HypermediaLink> Links { get; set; }

    }

}
