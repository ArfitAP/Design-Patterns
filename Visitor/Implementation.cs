namespace Visitor
{
    public class Customer : IElement
    {
        public decimal AmountOrdered { get; private set; }
        public decimal Discount { get; set; }
        public string Name { get; private set; }

        public Customer(decimal amountOrdered, string name)
        {
            AmountOrdered = amountOrdered;
            Name = name;
        }

        public void Accept(IVisitor visitor)
        {
            //visitor.VisitCustomer(this);
            visitor.Visit(this);
            Console.WriteLine($"Visited {nameof(Customer)}, discount given: {Discount}");
        }
    }

    public class Employee : IElement
    {
        public decimal YearsEmployed { get; private set; }
        public decimal Discount { get; set; }
        public string Name { get; private set; }

        public Employee(decimal yearsEmployed, string name)
        {
            YearsEmployed = yearsEmployed;
            Name = name;
        }

        public void Accept(IVisitor visitor)
        {
            //visitor.VisitEmployee(this);
            visitor.Visit(this);
            Console.WriteLine($"Visited {nameof(Employee)}, discount given: {Discount}");
        }
    }

    /*public interface IVisitor
    {
        void VisitCustomer(Customer customer);
        void VisitEmployee(Employee employee);
    }*/

    public interface IVisitor
    {
        void Visit(IElement element);
    }

    public interface IElement
    {
        void Accept(IVisitor visitor);
    }

    public class DiscountVisitor : IVisitor
    {
        public decimal TotalDiscountGiven { get; set; }

        public void Visit(IElement element)
        {
            if(element is Customer)
            {
                VisitCustomer((Customer)element);
            }
            else if(element is Employee)
            {
                VisitEmployee((Employee)element);
            }
        }

        private void VisitCustomer(Customer customer)
        {
            var discount = customer.AmountOrdered / 10;
            customer.Discount = discount;

            TotalDiscountGiven += discount;
        }

        private void VisitEmployee(Employee employee)
        {
            var discount = employee.YearsEmployed < 10 ? 100 : 200;
            employee.Discount = discount;

            TotalDiscountGiven += discount;
        }
    }

    public class Container
    {
        public List<Employee> Employees { get; set; } = new List<Employee>();
        public List<Customer> Customers { get; set; } = new List<Customer>();

        public void Accept(IVisitor visitor)
        {
            foreach(var employee in Employees) 
            {
                employee.Accept(visitor);
            }

            foreach (var customer in Customers)
            {
                customer.Accept(visitor);
            }
        }
    }

}

