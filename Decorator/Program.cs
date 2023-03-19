using Decorator;

Console.Title = "Decorator";


var cloudMailService = new CloudMailService();
cloudMailService.SendMail("Hi there.");

var onPremiseMailService = new OnPremiseMailService();
onPremiseMailService.SendMail("Hi there.");

var statisticsDecorator = new StatisticsDecorator(cloudMailService);
statisticsDecorator.SendMail($"Hi there via {nameof(StatisticsDecorator)} wrapper.");

var messageDatabaseDecorator = new MesasgeDatabaseDecorator(onPremiseMailService);
messageDatabaseDecorator.SendMail($"Hi there via {nameof(MesasgeDatabaseDecorator)} wrapper, message 1.");
messageDatabaseDecorator.SendMail($"Hi there via {nameof(MesasgeDatabaseDecorator)} wrapper, message 2.");

foreach(var message in messageDatabaseDecorator.SentMessages)
{
    Console.WriteLine($"Stored message: \"{message}\"");
}

Console.ReadLine();
