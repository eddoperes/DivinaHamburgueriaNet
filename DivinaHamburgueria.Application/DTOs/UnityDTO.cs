using DivinaHamburgueria.Application.Hypermedia;
using DivinaHamburgueria.Application.Hypermedia.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DivinaHamburgueria.Application.DTOs
{
    public class UnityDTO : ISupportsHypermedia
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "The name is required.")]
        [MinLength(3)]
        [MaxLength(100)]
        public string Name { get; set; } = String.Empty;

        public List<HypermediaLink> Links { get; set; } = new List<HypermediaLink>();

    }
}
