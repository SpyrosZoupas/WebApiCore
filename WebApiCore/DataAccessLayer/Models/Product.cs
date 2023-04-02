using System.Data.SqlTypes;
using System.Reflection;

namespace DataAccessLayer.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public SqlMoney Price { get; set; }
        public Byte[]? ProductImage { get; set; }

    }
}
