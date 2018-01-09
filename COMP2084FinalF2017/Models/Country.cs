namespace COMP2084FinalF2017.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Country
    {
        public int CountryID { get; set; }

        [Display(Name = "Country")]
        [Column("Country")]
        [Required]
        [StringLength(50)]
        public string Country1 { get; set; }

        [Display(Name = "G")]
        public int Gold { get; set; }

        [Display(Name = "S")]
        public int Silver { get; set; }

        [Display(Name = "B")]
        public int Bronze { get; set; }

        [Display(Name = "Total Medals")]
        public int TotalMedals { get; set; }

        [Required]
        [StringLength(100)]
        public string Flag { get; set; }
    }
}
