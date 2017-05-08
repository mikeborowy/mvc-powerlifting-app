using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PowerLiftingApp.Models
{
    public class Contender
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Contender Name is required")]
        [DisplayName("Contender Name")]
        [StringLength(30, MinimumLength = 4)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Bench press weight is required")]
        [DisplayName("Bench Press Personal Record")]
        [Range(0, 500)]
        public Decimal BenchPress { get; set; }

        [Required(ErrorMessage = "Squat weigth is required")]
        [DisplayName("Squat Personal Record")]
        [Range(0, 500)]
        public Decimal Squat { get; set; }

        [Required(ErrorMessage = "Deadlift is required")]
        [DisplayName("Deadlift Personal Record")]
        [Range(0, 500)]
        public Decimal Deadlift { get; set; }
    }
}