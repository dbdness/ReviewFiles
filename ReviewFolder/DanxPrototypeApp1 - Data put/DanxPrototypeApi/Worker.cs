namespace DanxPrototypeApi
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Worker")]
    public partial class Worker
    {
        [Key]
        public int Worker_id { get; set; }

        [Required]
        [StringLength(20)]
        public string Worker_name { get; set; }

        [Required]
        [StringLength(50)]
        public string Worker_adress { get; set; }

        public int Worker_age { get; set; }
    }
}
