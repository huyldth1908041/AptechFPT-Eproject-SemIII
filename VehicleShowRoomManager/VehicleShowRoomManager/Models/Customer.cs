using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VehicleShowRoomManager.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Phone { get; set; }
        public string Address { get; set; }
        public CustomerStatus Status { get; set; }
        
        public enum CustomerStatus
        {
            Active = 1, Deactive = 0, Delete = -1
        }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }


    }
}