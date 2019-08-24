using CallCenter.Helper.GeneralEnumTypes;
using System;

namespace CallCenter.Business.DTO
{
    public class TicketDto
    {
        public int Id { get; set; }
        public string Description { get; set; }        
        public TicketStatus Status { get; set; }        
        public DateTime CreateDate { get; set; }        
        public int TicketOwnerId { get; set; }        
        public int ResponsedUserId { get; set; }
        public int Bonus { get; set; }
    }
}
