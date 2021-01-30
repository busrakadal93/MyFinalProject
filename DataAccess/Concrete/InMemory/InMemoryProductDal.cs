using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        //global değişken
        List<Product> _products;
        //bellekte referans aldığında oluşacak blok constructor ctor tabtab
        public InMemoryProductDal()
        {
            //Oracle, SQL Server, Postgres, MongoDB
            _products = new List<Product> { 
                //bellekte ürün tanımlamadı
                new Product{ProductId=1,CategoryId=1,ProductName="Bardak",UnitPrice=15,UnitsInStock=15},
                new Product{ProductId=2,CategoryId=1,ProductName="Kamera",UnitPrice=500,UnitsInStock=3},
                new Product{ProductId=3,CategoryId=2,ProductName="Telefon",UnitPrice=1500,UnitsInStock=2},
                new Product{ProductId=4,CategoryId=2,ProductName="Klavye",UnitPrice=150,UnitsInStock=65},
                new Product{ProductId=5,CategoryId=2,ProductName="Mouse",UnitPrice=85,UnitsInStock=1}
            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            //Product productToDelete = null;
            ////Tek tek elimdeki elemanları dolaşıp elimdeki elemana eşit olunca onu siliyorum.
            //foreach (var p in _products)
            //{
            //    if (product.ProductId == p.ProductId)
            //    {
            //        productToDelete = p;
            //    }
            //}
            //_products.Remove(productToDelete);

            //LINQ - Language Integrated Query Dile Gömülü Sorgulama
            Product productToDelete = _products.SingleOrDefault(p=>p.ProductId==product.ProductId); //Tek bir eleman bulmaya yarar. //=> lambda demek //p o an dolaştığım ürün
            //SingleOrDefault(p=>p.ProductId==product.ProductId) foreach i yapıyor. her p için p nin product id si benim gönderdiğime eşit mi eşitse sil
            _products.Remove(productToDelete);
        }

        public List<Product> GetAll()
        {
            //veritabanındaki datayı businessa vermemiz lazım
            return _products; //veritabanını olduğu gibi döndürüyoruz.
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            //yeni bir liste oluşturup döndürür
            return _products.Where(p => p.CategoryId == categoryId).ToList();
        }

        public void Update(Product product)
        {
            //Gönderdiğim ürün id sine sahip olan listedeki ürünü bul demek.
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;
        }
    }
}
