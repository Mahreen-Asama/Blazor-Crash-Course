using BlazorWebAssemblyApp_CrashCourse.Controls;

namespace BlazorWebAssemblyApp_CrashCourse.Pages
{
    public partial class ParentComponent
    {
        public string Message { get; set; } = "I am msg from parent";
        public int Age { get; set; } = 12;
        public string Name { get; set; } = "Ali";

        //for event call back
        string message = "default msg";
        private void GetMessage(string m)
        {
            message = m;
        }

        //for child component reference
        private string parentMsg = "Parent's own msg before click";
        private ChildComponent c1;

        void OnClick()
        {
            parentMsg = "Parent's own msg after click";
            c1.show();
        }

    }
}
