using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetWalker.DataAccess.DBEntities
{
    [Table("pet_pack", Schema = "public")]
    public class PetPack
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("pack_id")]
        public long PackId { get; set; }

        [Column("pet_id")]
        public long PetId { get; set; }
    }
}
