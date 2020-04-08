
namespace CQRS_Example
{
    using CQRS_Example.Commands;
    using CQRS_Example.Model;
    using CQRS_Example.Queries;
    using System;
    
    class Program
    {
        //This would be in Dependency Injection and acessible everywhere we need events
        public static EventBroker EventBroker;

        static void Main(string[] args)
        {
            //Singleton EventBroker
            EventBroker = new EventBroker();

            Product balenciagaShoes = new Product(1, "Red Balenciaga Sneakers");
            Console.WriteLine($"Created new product: {balenciagaShoes.ToString()}");

            var balenciagaShoesDescriptionQuery = new ProductDescriptionQuery(balenciagaShoes);

            var productDescription = EventBroker.Query<string>(balenciagaShoesDescriptionQuery);
            Console.WriteLine($"Product Description from Query is {productDescription}");

            Console.WriteLine("Changing product description...");
            EventBroker.Command(new ChangeProductDescriptionCommand(balenciagaShoes, "Black Balenciaga Shoes"));

            productDescription = EventBroker.Query<string>(balenciagaShoesDescriptionQuery);
            Console.WriteLine($"New Product Description from Query is {productDescription}");
}
    }
}
