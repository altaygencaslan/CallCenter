using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CallCenter.Data
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        //TODO: Must hashed
        [Required]
        [MaxLength(50)]
        public string Password { get; set; }
        
        public int Bonus { get; set; }

        public virtual ICollection<Ticket> TicketList { get; set; }
    }
}
