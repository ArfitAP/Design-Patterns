using Mediator;

Console.Title = "Mediator";

TeamChatRoom room = new();

var sven = new Lawyer("Sven");
var kenneth = new Lawyer("Kenneth");
var ann = new AccountManager("Ann");
var john = new AccountManager("John");
var kylie = new AccountManager("Kylie");

room.Register(sven);
room.Register(kenneth);
room.Register(ann);
room.Register(john);
room.Register(kylie);

ann.Send("Hi everyone");
sven.Send("On it!");

sven.Send("Ann", "Could you join me ?");

ann.SendTo<AccountManager>("The file was approved !");
Console.ReadLine();
