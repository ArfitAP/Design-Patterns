using TemplateMethod;

Console.Title = "Template Method";

ExchangeMailParser exchangeMailParser = new();
Console.WriteLine(exchangeMailParser.ParseMailBody("1"));
Console.WriteLine();

ApacheMailParser apacheMailParser = new();
Console.WriteLine(apacheMailParser.ParseMailBody("2"));
Console.WriteLine();

EudoreMailParser eudoreMailParser = new();
Console.WriteLine(eudoreMailParser.ParseMailBody("3"));

Console.ReadLine();