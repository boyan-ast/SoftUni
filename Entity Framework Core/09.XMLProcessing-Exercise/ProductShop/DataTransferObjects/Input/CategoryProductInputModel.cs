using System.Xml.Serialization;

namespace ProductShop.DataTransferObjects.Input
{
    [XmlType("CategoryProduct")]
    public class CategoryProductInputModel
    {
        public int CategoryId { get; set; }

        public int ProductId { get; set; }
    }
}