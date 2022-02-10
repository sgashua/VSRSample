namespace VSRSample.Domain.Entities
{
    public partial class Employee : BaseEntity
    {
        public int? CompanyId { get; set; }
        public string? Name { get; set; }

        public virtual Company? Company { get; set; }
    }
}
