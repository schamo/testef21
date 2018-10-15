using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestEf21
{
    public class ChildEntity
    {
        [Key]
        public int Key { get; set; }

        public bool CanView { get; set; }

        public int ParentKey { get; set; }

        [ForeignKey("ParentKey")]
        public virtual ParentEntity Parent { get; set; }
    }
}
