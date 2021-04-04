using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VehicleShowRoomManager.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Customer Name")]
        public string Name { get; set; }
        [Required]
        [Phone]
        public string Phone { get; set; }
        public string Address { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public CustomerStatus Status { get; set; }
        
        public enum CustomerStatus
        {
            Active = 1, Deactive = 0, Delete = -1
        }
      
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }


    }
}