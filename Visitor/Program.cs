using Visitor;

Console.Title = "Visitor";

var container = new Container();

container.Customers.Add(new Customer(500, "Sophie"));
container.Customers.Add(new Customer(1000, "Karen"));
container.Customers.Add(new Customer(800, "Sven"));
container.Employees.Add(new Employee(18, "Kevin"));
container.Employees.Add(new Employee(5, "Tom"));

DiscountVisitor visitor = new DiscountVisitor();

container.Accept(visitor);

Console.WriteLine($"Total discount: {visitor.TotalDiscountGiven}");

Console.ReadLine();