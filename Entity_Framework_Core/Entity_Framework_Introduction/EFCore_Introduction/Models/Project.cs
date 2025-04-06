namespace SoftUni.Models
{
    public partial class Project
    {
        public Project()
        {
            //Employees = new HashSet<Employee>();
            EmployeesProjects = new HashSet<EmployeeProject>();
        }

        public int ProjectId { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        //public virtual ICollection<Employee> Employees { get; set; }
        public ICollection<EmployeeProject> EmployeesProjects { get; set; }
    }
}
