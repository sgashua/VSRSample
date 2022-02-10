namespace VSRSample.Domain.Entities
{
    public partial class Company : BaseEntity
    {
        public Company()
        {
            Employees = new HashSet<Employee>();
        }

        public string? Name { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
