using CallCenter.Business.DTO;
using System.Collections.Generic;

namespace CallCenter.Business.Repositories
{
    public interface ITicketRepository
    {
        TicketDto Read(int id);
        IEnumerable<TicketDto> ReadAll();
        bool Update(TicketDto ticket);
        bool AssignToMe(TicketDto ticket);
        bool CloseTicket(TicketDto ticket);
    }
}
