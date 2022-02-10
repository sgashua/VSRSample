namespace VSRSample.Domain.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public bool? Status { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public BaseEntity()
        {
            Status = true;
        }
    }
}
