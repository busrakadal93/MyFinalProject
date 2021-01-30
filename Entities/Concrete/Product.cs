using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    //public yazdık : Bu classa diğer katmanlarda ulaşabilsin diye yazdık.
    //Data Access ürünü eklicek, Business ürünü kontrol edicek, consoleUI ürünü göstericek
    //internal : Sadece Entities erişebilir demek (default olarak bu zaten)
    public class Product:IEntity
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public short UnitsInStock { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
