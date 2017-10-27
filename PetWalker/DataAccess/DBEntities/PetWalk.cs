using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetWalker.DataAccess.DBEntities
{
    [Table("pet_walk", Schema = "public")]
    public class PetWalk
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("walk_name")]
        public string Name { get; set; }

        [Column("walk_date")]
        public DateTime WalkDate { get; set; }

        [Column("pet_id")]
        public long? PetId { get; set; }

        [Column("pack_id")]
        public long? PackId { get; set; }
    }
}
