namespace BlazorWebAssemblyApp_CrashCourse.Models
{
    public interface IEmployee
    {
        string Object_ID { get; set; }
        List<Employee> GetAllEmployees();
    }
}
