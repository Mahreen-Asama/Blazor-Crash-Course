using BlazorWebAssemblyApp_CrashCourse.Models;
using Microsoft.AspNetCore.Components;

namespace BlazorWebAssemblyApp_CrashCourse.Pages
{
    public partial class EmployeeCmpt
    {
        [Inject]
        IEmployee service { get; set; }

        List<Employee> list;
        protected override void OnInitialized()
        {
            Console.WriteLine("Parent : OnInitialized");
            base.OnInitialized();

            list = service.GetAllEmployees();
        }
    }
}
