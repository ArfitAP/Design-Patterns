namespace Strategy
{
    public interface IExportService
    {
        void Export(Order order);
    }

    public class JsonExportService : IExportService
    {
        public void Export(Order order)
        {
            Console.WriteLine($"Exporting {order.Name} to JSON.");
        }
    }

    public class XMLExportService : IExportService
    {
        public void Export(Order order)
        {
            Console.WriteLine($"Exporting {order.Name} to XML.");
        }
    }

    public class CSVExportService : IExportService
    {
        public void Export(Order order)
        {
            Console.WriteLine($"Exporting {order.Name} to CSV.");
        }
    }

    public class Order
    {
        public string Customer { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int Amount { get; set; }

        public IExportService? ExportService { get; set; }

        public Order(string customer, string name, int amount)
        {
            Customer = customer;
            Name = name;
            Amount = amount;
        }

        public void Export()
        {
            ExportService?.Export(this);
        }

        // OR

        public void Export(IExportService exportService)
        {
            if (exportService is null) return;

            exportService.Export(this);
        }
    }
}
