using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VehicleShowRoomManager.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
        public string Address { get; set; }

        public string Position { get; set; }

        public EmployeeStatus Status { get; set; }

        public enum EmployeeStatus
        {
            ACTIVE = 1,
            DEACTIVE = 0
        }
    }
}