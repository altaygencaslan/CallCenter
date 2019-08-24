using System;
using CallCenter.Business.DTO;
using CallCenter.Business.UnitOfWork;
using CallCenter.Data;

namespace CallCenter.Business.Repositories
{
    public class TicketRepository : ITicketRepository
    {
        public bool AssignToMe(TicketDto ticket)
        {
            Ticket updatingTicket = Worker.Connection.Ticket.Find(ticket.Id);
            if (updatingTicket != null)
            {
                updatingTicket.Status = ticket.Status;
                updatingTicket.ResponsedUserId = ticket.ResponsedUserId;

                return Worker.SaveChanges() > 0;
            }

            return false;
        }

        public bool CloseTicket(TicketDto ticket)
        {
            bool status = false;
            using (var transaction = Worker.Connection.Database.BeginTransaction())
            {
                Ticket updatingTicket = Worker.Connection.Ticket.Find(ticket.Id);
                if (updatingTicket != null)
                {
                    updatingTicket.Description = ticket.Description;
                    updatingTicket.Status = ticket.Status;
                    updatingTicket.ResponsedUserId = ticket.ResponsedUserId;

                    Worker.EmployeeRepository.BonusUpdate(ticket.ResponsedUserId, ticket.Bonus);
                }

                status = Worker.SaveChanges() > 0;
                transaction.Commit();                
            }

            return status;
        }

        public bool Update(TicketDto ticket)
        {
            Ticket updatingTicket = Worker.Connection.Ticket.Find(ticket.Id);
            if (updatingTicket != null)
            {
                updatingTicket.Description = ticket.Description;
                updatingTicket.Status = ticket.Status;
                updatingTicket.ResponsedUserId = ticket.ResponsedUserId;

                return Worker.SaveChanges() > 0;
            }

            return false;
        }
    }
}
