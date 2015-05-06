namespace DanxPrototypeApi
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LoggedInEmployee")]
    public partial class LoggedInEmployee
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        public DateTime? Last_login { get; set; }

        public DateTime? Last_logout { get; set; }

        public TimeSpan? Total_hours { get; set; }
    }
}
