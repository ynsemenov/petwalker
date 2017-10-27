using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetWalker.DataAccess.DBEntities
{
    [Table("pack", Schema = "public")]
    public class Pack
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("pack_name")]
        public string Name { get; set; }
    }
}
