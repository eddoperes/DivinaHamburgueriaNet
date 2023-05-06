using DivinaHamburgueria.API.Hypermedia.Abstract;

namespace DivinaHamburgueria.API.Hypermedia.Filters
{
    public class HypermediaFilterOptions
    {

        public List<IResponseEnricher> ContentResponseEnricherList { get; set; } = new List<IResponseEnricher>();

    }

}
