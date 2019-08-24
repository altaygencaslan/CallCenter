using CallCenter.Business.DTO;
using System;
namespace CallCenter.Business.Repositories
{
    public interface ITicketRepository
    {
        bool Update(TicketDto ticket);
        bool AssignToMe(TicketDto ticket);
        bool CloseTicket(TicketDto ticket);
    }
}
