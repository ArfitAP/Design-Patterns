namespace Memento
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Employee(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }

    public class Manager : Employee
    {
        public List<Employee> Employees = new();

        public Manager(int id, string name) : base(id, name)
        {

        }
    }

    public interface IEmployeeManagerRepository
    {
        void AddEmployee(int managerId, Employee employee);
        void RemoveEmployee(int managerId, Employee employee);
        bool HasEmployee(int managerId, int employeeId);
        void WriteDataStore();
    }

    public class EmployeeManagerRepository : IEmployeeManagerRepository
    {
        private List<Manager> _managers = new() { new Manager(1, "Katie"), new Manager(2, "Geoff") };

        public void AddEmployee(int managerId, Employee employee)
        {
            _managers.First(m => m.Id == managerId).Employees.Add(employee);
        }

        public void RemoveEmployee(int managerId, Employee employee)
        {
            _managers.First(m => m.Id == managerId).Employees.Remove(employee);
        }

        public bool HasEmployee(int managerId, int employeeId)
        {
            return _managers.First(m => m.Id == managerId).Employees.Any(e => e.Id == employeeId);
        }

        public void WriteDataStore()
        {
            foreach (var manager in _managers)
            {
                Console.WriteLine($"Manager {manager.Id}, {manager.Name}");
                if (manager.Employees.Any())
                {
                    foreach (var employee in manager.Employees)
                    {
                        Console.WriteLine($"\t Employee {employee.Id}, {employee.Name}");
                    }
                }
                else
                {
                    Console.WriteLine("\t No employees.");
                }
            }
        }
    }

    public interface ICommand
    {
        void Execute();
        void Undo();
        bool CanExecute();
        AddEmployeeToManagerListMemento CreateMemento();
        void RestoreMemento(AddEmployeeToManagerListMemento memento);
    }

    public class AddEmployeeToManagerListMemento
    {
        public int _managerId { get; private set; }
        public Employee? _employee { get; private set; }

        public AddEmployeeToManagerListMemento(int managerId, Employee? employee)
        {
            _managerId = managerId;
            _employee = employee;
        }
    }

    public class AddEmployeeToManagerList : ICommand
    {
        private readonly IEmployeeManagerRepository _employeeManagerRepository;
        private int _managerId;
        private Employee? _employee;

        public AddEmployeeToManagerList(IEmployeeManagerRepository employeeManagerRepository, int managerId, Employee? employee)
        {
            _employeeManagerRepository = employeeManagerRepository;
            _managerId = managerId;
            _employee = employee;
        }

        public AddEmployeeToManagerListMemento CreateMemento()
        {
            return new AddEmployeeToManagerListMemento(_managerId, _employee);
        }

        public void RestoreMemento(AddEmployeeToManagerListMemento memento)
        {
            _managerId = memento._managerId;
            _employee = memento._employee;
        }

        public void Execute()
        {
            if (_employee == null) return;
            _employeeManagerRepository.AddEmployee(_managerId, _employee);
        }

        public void Undo()
        {
            if (_employee == null) return;
            _employeeManagerRepository.RemoveEmployee(_managerId, _employee);
        }

        public bool CanExecute()
        {
            if (_employee == null)
            {
                return false;
            }

            if (_employeeManagerRepository.HasEmployee(_managerId, _employee.Id))
            {
                return false;
            }

            return true;
        }
    }

    public class CommandManager
    {
        private readonly Stack<AddEmployeeToManagerListMemento> _mementos = new();
        private AddEmployeeToManagerList? _command;

        public void Invoke(ICommand command)
        {
            if(_command == null)
            {
                _command = (AddEmployeeToManagerList)command;
            }

            if (command.CanExecute())
            {
                command.Execute();
                _mementos.Push(command.CreateMemento());
            }
        }

        public void Undo()
        {
            if (_mementos.Any())
            {
                _command?.RestoreMemento(_mementos.Pop());
                _command?.Undo();
            }
        }

        public void UndoAll()
        {
            while (_mementos.Any())
            {
                _command?.RestoreMemento(_mementos.Pop());
                _command?.Undo();
            }
        }
    }

}