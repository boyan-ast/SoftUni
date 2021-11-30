﻿using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace BookShop.DataProcessor.ImportDto
{
    [XmlType("Book")]
    public class BookXmlInputModel
    {
        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        public string Name { get; set; }

        [Range(1, 3)]
        public int Genre { get; set; }

        [Range(0.01, double.MaxValue)]
        public decimal Price { get; set; }

        [Range(50, 5000)]
        public int Pages { get; set; }

        [Required]
        public string PublishedOn { get; set; }
    }
}
