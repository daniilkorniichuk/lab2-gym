using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace lab2_gym.Models
{
    public class Subscription
    {
        public int Id { get; set; }

        [Required]
        public int VisitorId { get; set; }

        [Required]
        public int GymId { get; set; }

        [ValidateNever]  
        public Visitor Visitor { get; set; }

        [ValidateNever]
        public Gym Gym { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
