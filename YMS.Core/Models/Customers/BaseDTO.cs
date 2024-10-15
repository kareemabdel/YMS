namespace YMS.Core.Models.Customers
{
    public class BaseDTO
    {
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }
        public DateTimeOffset CreatedDate { get; set; }= DateTime.Now;
        public DateTimeOffset? UpdatedDate { get; set; }
         public Guid? CreatedById  { get; set; }

    }
}
