namespace BlazorWebAssemblyApp_CrashCourse.Models
{
    public class EmployeeService : IEmployee
    {
        public string Object_ID { get; set; }
        List<Employee> _employees;

        public EmployeeService()
        {
            Object_ID=Guid.NewGuid().ToString();    //assign a new id whenever construtor is called
            _employees = new List<Employee>
            {
                new Employee{Name="Ali", Dept="IT"},
                new Employee{Name="Hamza", Dept="CS"},
            };
            Console.WriteLine("object created");
        }

        public List<Employee> GetAllEmployees()
        {
            
            return _employees;
        }
    }
}
