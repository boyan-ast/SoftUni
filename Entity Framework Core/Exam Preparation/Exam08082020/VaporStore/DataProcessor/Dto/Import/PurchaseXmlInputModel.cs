﻿using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace VaporStore.DataProcessor.Dto.Import
{
    [XmlType("Purchase")]
    public class PurchaseXmlInputModel
    {
        [XmlAttribute("title")]
        [Required]
        public string Title { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        [RegularExpression(@"^[A-Z0-9]{4}-[A-Z0-9]{4}-[A-Z0-9]{4}$")]
        public string Key { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]{4} [0-9]{4} [0-9]{4} [0-9]{4}$")]
        public string Card { get; set; }

        [Required]
        public string Date { get; set; }
    }
}
