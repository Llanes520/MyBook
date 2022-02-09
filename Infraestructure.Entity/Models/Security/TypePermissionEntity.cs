using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Infraestructure.Entity.Models
{
    [Table("TypePermission", Schema = "Security")]
    public class TypePermissionEntity
    {
        [Key]
        public int IdTypePermission { get; set; }

        [MaxLength]
        public string TypePermission { get; set; }

        public IEnumerable<PermissionEntity> permissionEntities { get; set; }

    }
}
