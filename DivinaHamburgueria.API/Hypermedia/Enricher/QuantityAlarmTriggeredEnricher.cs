using Microsoft.AspNetCore.Mvc;
using DivinaHamburgueria.API.Hypermedia.Constants;
using System.Text;
using DivinaHamburgueria.Application.DTOs;
using DivinaHamburgueria.Application.Hypermedia;

namespace DivinaHamburgueria.API.Hypermedia.Enricher
{

    public class QuantityAlarmTriggeredEnricher : ContentResponseEnricher<QuantityAlarmTriggeredDTO>
    {

        private readonly object _lock = new object();

        protected override Task EnrichModel(QuantityAlarmTriggeredDTO content, IUrlHelper urlHelper)
        {
            var path = "api/quantityalarmstriggered/v1";
            string link = GetLink(content.Id, urlHelper, path);
            content.Links.Add(new HypermediaLink()
            {
                Action = HttpActionVerb.GET,
                Href = link,
                Rel = RelationType.self,
                Type = ResponseTypeFormat.DefaultGet 
            });

            return Task.FromResult<object>("");
            //return null;
        }

        private string GetLink(int id, IUrlHelper urlHelper, string path)
        {
            lock (_lock)
            {
                var url = new { controller = path, id = id };
                return new StringBuilder(urlHelper.Link("DefaultApi",url)).Replace("%2F","/").Replace("?version=1", "").ToString();
            }
        }

    }

}
