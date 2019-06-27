using Avana.DataAccess.Entities.Schema;
using FVTC.LearningInnovations.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Avana.DataAccess.Entities
{
    [Table(nameof(device))]
    public class Device : IEntity<int>
    {
        [Key]
        [Column(nameof(device.device_id))]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Column(nameof(device.model_family_id))]
        [StringLength(10)]
        public string ModelFamilyId { get; set; }
        public ModelFamily ModelFamily { get; set; }


        [Column(nameof(device.description))]
        [StringLength(50)]
        public string Description { get; set; }

        [Required]
        [Column(nameof(device.mac_address))]
        [MaxLength(6)]
        public byte[] MacAddress { get; set; }
        
    }

    [Table(nameof(model_family))]
    public class ModelFamily
    {
        [Key]
        [Column(nameof(model_family.model_family_id))]
        public string Id { get; set; }

        [StringLength(10)]
        [Column(nameof(model_family.name))]
        public string Name { get; set; }

        [Column(nameof(model_family.is_active))]
        public bool IsActive { get; set; }

        public ICollection<Device> Devices { get; set; }
    }
}
