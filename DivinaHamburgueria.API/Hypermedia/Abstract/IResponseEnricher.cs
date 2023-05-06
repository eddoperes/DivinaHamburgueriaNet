using Microsoft.AspNetCore.Mvc.Filters;

namespace DivinaHamburgueria.API.Hypermedia.Abstract
{
    public interface IResponseEnricher
    {

        bool CanEnrich(ResultExecutingContext context);

        Task Enrich(ResultExecutingContext context);

    }

}
