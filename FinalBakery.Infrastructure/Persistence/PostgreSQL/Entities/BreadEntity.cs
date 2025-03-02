using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalBakery.Domain.Common;

namespace FinalBakery.Infrastructure.Persistence.PostgreSQL.Entities
{
    public class BreadEntity : BaseEntity, IAuditableEntity
    {
        public string Bread_Name { get; set; } = string.Empty;
        public BreadInstanceEntity BreadInstance { get; set; } = default!;
        public ICollection<OrderItemEntity> OrderItems { get; set; } = default!;
        public ICollection<ChefEntity> Chefs { get; set; } = default!;
        public ICollection<OfficeEntity> Offices { get; set; } = default!;
        public ICollection<OfficeBreadEntity> OfficesBreads { get; set; } = default!;
        public float Bread_Cost { get; set; }
        public AuditInfo Audit{ get; set; } = default!;
    }
}
