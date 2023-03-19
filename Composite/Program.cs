Console.Title = "Composite";

var root = new Composite.Directory("root", 0);
var topLevelFile = new Composite.File("toplevel.txt", 100);
var toplevelDirectory1 = new Composite.Directory("topleveldirectory1", 4);
var toplevelDirectory2 = new Composite.Directory("topleveldirectory2", 4);

root.Add(topLevelFile);
root.Add(toplevelDirectory1);
root.Add(toplevelDirectory2);

var subLevelFile1 = new Composite.File("sublevel1.txt", 200);
var subLevelFile2 = new Composite.File("sublevel2.txt", 150);

toplevelDirectory2.Add(subLevelFile1);
toplevelDirectory2.Add(subLevelFile2);

Console.WriteLine($"Size of topLevelDirectory1: {toplevelDirectory1.GetSize()}");
Console.WriteLine($"Size of topLevelDirectory2: {toplevelDirectory2.GetSize()}");
Console.WriteLine($"Size of root: {root.GetSize()}");

Console.ReadLine();
