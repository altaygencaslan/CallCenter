using System;
using System.Collections.Generic;
using System.Linq;
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
                updatingTicket.Status = Helper.GeneralEnumTypes.TicketStatus.ASSIGNED;
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

                    Worker.EmployeeRepository.BonusUpdate(ticket.ResponsedUserId.Value, ticket.Bonus);
                }

                status = Worker.SaveChanges() > 0;
                transaction.Commit();
            }

            return status;
        }

        public TicketDto Read(int id)
        {
            return Worker.Connection
                         .Ticket
                         .Where(w => w.Id == id)
                         .Select(s => new TicketDto
                         {
                             Id = s.Id,
                             Description = s.Description,
                             CreateDate = s.CreateDate,
                             Bonus = s.Bonus,
                             ResponsedUserId = s.ResponsedUserId,
                             ResponsedUserFullName = s.ResponsedUser.Name + " " + s.ResponsedUser.LastName,
                             AssignedToMe = (s.ResponsedUserId == CallCenter.Helper.AccountInformations.SignedIn.Id),
                             Status = s.Status,
                             TicketOwnerId = s.TicketOwnerId
                         })
                         .FirstOrDefault();
        }

        public IEnumerable<TicketDto> ReadAll()
        {
            return Worker.Connection
                         .Ticket
                         .OrderBy(o => o.ResponsedUserId)
                         .OrderBy(o => o.CreateDate)
                         .Select(s => new TicketDto
                         {
                             Id = s.Id,
                             Description = s.Description,
                             CreateDate = s.CreateDate,
                             Bonus = s.Bonus,
                             ResponsedUserId = s.ResponsedUserId,
                             ResponsedUserFullName = s.ResponsedUser.Name + " " + s.ResponsedUser.LastName,
                             Status = s.Status,
                             TicketOwnerId = s.TicketOwnerId,
                         })
                         .ToList();
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
