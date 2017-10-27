using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetWalker.DataAccess.DBEntities
{
    [Table("size", Schema = "public")]
    public class Size
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("size_name")]
        public string Name { get; set; }
    }
}
