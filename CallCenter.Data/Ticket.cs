using CallCenter.Helper.GeneralEnumTypes;
using System;
using System.ComponentModel.DataAnnotations;

namespace CallCenter.Data
{
    public class Ticket
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }

        [Required]
        [EnumDataType(typeof(TicketStatus))]
        public TicketStatus Status { get; set; }

        [Required]
        public DateTime CreateDate { get; set; }

        [Required]
        public int TicketOwnerId { get; set; }

        [Required]
        public int ResponsedUserId { get; set; }
        public virtual Employee ResponsedUser { get; set; }

        public int Bonus { get; set; }
    }
}
