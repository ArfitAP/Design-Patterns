using Facade;

Console.Title = "Facade";

var facade = new DoscountFacade();

Console.WriteLine($"Discount percentage for customer with id 1: {facade.CalculateDiscountPercentage(1)}");
Console.WriteLine($"Discount percentage for customer with id 10: {facade.CalculateDiscountPercentage(10)}");

Console.ReadLine();
