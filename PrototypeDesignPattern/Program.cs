using System;

namespace PrototypeDesignPattern
{
    //bu classı implemente eden classlar içerideki metodu uygulamak zorunda olduklarından metot da AventurePrototype'ı döndürmek zorunda olduğundan
    //ki kendi de abstract olduğundan türeyen tip kendi çalışma zamanını geriye döndürmekle yükümlüdür
    abstract class AdventurePrototype
    {
        public abstract AdventurePrototype Clone();
    }

    //Concrete Prototype
    class Product : AdventurePrototype
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal ListPrice { get; set; }

        public Product(int productId, string name, decimal listPrice)
        {
            ProductId = productId;
            Name = name;
            ListPrice = listPrice;
        }

        public override AdventurePrototype Clone()
        {
            return this.MemberwiseClone() as AdventurePrototype;
        }
        public override string ToString()
        {
            return $"{this.ProductId} {this.Name} {this.ListPrice}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Product lcdTv = new Product(1000, "ABC Lcd TV 106", 1000);
            //bunu ürettikten sonra yarın öbürgün bunun seri üretimine geçmek istediğimizi düşünelim.

            Product lcdTV2 = (lcdTv.Clone() as Product);
            lcdTV2.ProductId = 1001;
            lcdTV2.Name = "CBA Lcd TV 107";
            lcdTV2.ListPrice = 1001;


            Console.WriteLine(lcdTv.ToString());
            Console.WriteLine(lcdTV2.ToString());
            Console.ReadKey();
        }

    }


}