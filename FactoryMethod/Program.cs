using FactoryMethod;

Console.Title = "Factory Method";

var factories = new List<DiscountFactory>
{
    new CodeDiscountFactory(Guid.NewGuid()),
    new CountryDiscountFactory("BE")
};

foreach (var fact in factories)
{
    var discountService = fact.createDiscountService();
    Console.WriteLine($"Percentage {discountService.DiscountPercentage} comming from {discountService}");
}

Console.ReadLine();