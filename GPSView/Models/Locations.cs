namespace GPSView.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.Locations")]
    public partial class Locations
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string IMEI { get; set; }

        public float Longitude { get; set; }

        public float Latitude { get; set; }

        public float? Altitude { get; set; }

        public float? Accuracy { get; set; }

        public float? Bearing { get; set; }

        public float? Speed { get; set; }

        public long? Time { get; set; }

        public virtual Device Device { get; set; }
    }
}
