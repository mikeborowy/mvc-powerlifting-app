using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PowerLiftingApp_2.Models
{
    public class Contender
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Contender Name")]
        [StringLength(30, MinimumLength = 4)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Bench press weight is required")]
        [DisplayName("Bench Press (kg)")]
        [Range(0, 500)]
        public Decimal BenchPress { get; set; }

        [Required(ErrorMessage = "Squat weigth is required")]
        [DisplayName("Squat (kg)")]
        [Range(0, 500)]
        public Decimal Squat { get; set; }

        [Required(ErrorMessage = "Deadlift is required")]
        [DisplayName("Deadlift (kg)")]
        [Range(0, 500)]
        public Decimal Deadlift { get; set; }

        [DisplayName("Total Score (kg)")]
        public Decimal TotalResult { get; set; }
    }
}