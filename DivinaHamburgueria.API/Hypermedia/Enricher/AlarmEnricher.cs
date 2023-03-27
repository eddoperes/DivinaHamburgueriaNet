using Microsoft.AspNetCore.Mvc;
using DivinaHamburgueria.API.Hypermedia.Constants;
using System.Text;
using DivinaHamburgueria.Application.DTOs;
using DivinaHamburgueria.Application.Hypermedia;

namespace DivinaHamburgueria.API.Hypermedia.Enricher
{
    public class AlarmEnricher : ContentResponseEnricher<AlarmDTO>
    {

        private readonly object _lock = new object();

        protected override Task EnrichModel(AlarmDTO content, IUrlHelper urlHelper)
        {
            var path = "api/alarms/v1";
            string link = GetLink(content.Id, urlHelper, path);
            content.Links.Add(new HypermediaLink()
            {
                Action = HttpActionVerb.GET,
                Href = link,
                Rel = RelationType.self,
                Type = ResponseTypeFormat.DefaultGet 
            });

            content.Links.Add(new HypermediaLink()
            {
                Action = HttpActionVerb.POST ,
                Href = link,
                Rel = RelationType.self,
                Type = ResponseTypeFormat.DefaultPost
            });

            content.Links.Add(new HypermediaLink()
            {
                Action = HttpActionVerb.PUT ,
                Href = link,
                Rel = RelationType.self,
                Type = ResponseTypeFormat.DefaultPut
            });

            content.Links.Add(new HypermediaLink()
            {
                Action = HttpActionVerb.DELETE,
                Href = link,
                Rel = RelationType.self,
                Type = "int"
            });

            return Task.FromResult<object>("");
            //return null;
        }

        private string GetLink(int id, IUrlHelper urlHelper, string path)
        {
            lock (_lock)
            {
                var url = new { controller = path, id = id };
                return new StringBuilder(urlHelper.Link("DefaultApi",url)).Replace("%2F","/").Replace("?version=1","").ToString();
            }
        }

    }

}
