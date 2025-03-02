using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalBakery.Domain.Common;

namespace FinalBakery.Domain.Entities
{
    public class Bread : BaseEntity, IAuditableEntity
    {
        public string Bread_Name { get; set; } = string.Empty;
        public ICollection<Ingredient> Ingredients { get; set; } = [];
        public ICollection<Preparation> Preparation_Steps { get; set; } = [];
        public AuditInfo Audit { get; set; } = default!;
    }
}
