using Strategy;

Console.Title = "Strategy";

var order = new Order("Marvin Software", "Visual Studio License", 5);

order.ExportService = new CSVExportService();
order.Export();

// OR

order.Export(new JsonExportService());

Console.ReadLine();