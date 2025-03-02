namespace FinalBakery.Domain.Common
{
    public interface IAuditableEntity
    {
        public AuditInfo Audit { get; set; }
    }
}
