namespace YMS.Migrations.Entities
{
    public class BaseEntity
    {
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }
        public DateTimeOffset CreatedDate { get; set; }= DateTime.Now;
        public DateTimeOffset? UpdatedDate { get; set; }
         public Guid? CreatedById  { get; set; }

    }
}
