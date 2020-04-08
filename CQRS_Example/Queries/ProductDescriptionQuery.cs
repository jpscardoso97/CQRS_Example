using CQRS_Example.Model;

namespace CQRS_Example.Queries
{
    public class ProductDescriptionQuery : Query
    {
        public Product Target { get; }

        public ProductDescriptionQuery(Product target)
        {
            this.Target = target;
        }
    }
}
