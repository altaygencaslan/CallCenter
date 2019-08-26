namespace CallCenter.Business.Migrations
{
    using CallCenter.Data;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Text;

    internal sealed class Configuration : DbMigrationsConfiguration<CallCenter.Business.CallCenterDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CallCenter.Business.CallCenterDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            /*
            context.Employee.Add(new Employee
            {
                Name = "User1Name",
                LastName = "User1LastName",
                Email = "user1@callcenter.com",
                Bonus = 0,
                Password = ConvertToPass("123456")
            });

            context.Employee.Add(new Employee
            {
                Name = "User2Name",
                LastName = "User2LastName",
                Email = "user2@callcenter.com",
                Bonus = 0,
                Password = ConvertToPass("654321")
            });

            context.Employee.Add(new Employee
            {
                Name = "User3Name",
                LastName = "User3LastName",
                Email = "user3@callcenter.com",
                Bonus = 0,
                Password = ConvertToPass("112233")
            });

            context.Employee.Add(new Employee
            {
                Name = "Misafir1Name",
                LastName = "Misafir1LastName",
                Email = "misafir1@callcenter.com",
                Bonus = 0,
                Password = ConvertToPass("112233")
            });


            context.Employee.Add(new Employee
            {
                Name = "Misafir2Name",
                LastName = "Misafir2LastName",
                Email = "misafir2@callcenter.com",
                Bonus = 0,
                Password = ConvertToPass("112233")
            });

            context.Employee.Add(new Employee
            {
                Name = "Misafir3Name",
                LastName = "Misafir3LastName",
                Email = "misafir3@callcenter.com",
                Bonus = 0,
                Password = ConvertToPass("112233")
            });
            
            context.Ticket.Add(new Ticket
            {
                TicketOwnerId = 4,
                Description = "Bilgisayarım sıklıkla mavi ekran hatası alıyorum",
                ResponsedUserId = 1,
                Status = Helper.GeneralEnumTypes.TicketStatus.ASSIGNED,
                Bonus = 3,
                CreateDate = DateTime.Parse("25.08.2019 15:17")

            });

            context.Ticket.Add(new Ticket
            {
                TicketOwnerId = 5,
                Description = "İnternete giremiyorum",
                Status = Helper.GeneralEnumTypes.TicketStatus.OPEN,
                Bonus = 3,
                CreateDate = DateTime.Parse("25.08.2019 16:25")
            });

            context.Ticket.Add(new Ticket
            {
                TicketOwnerId = 6,
                Description = "Kullanıcı yetkilerimde YETKI1 yok",
                Status = Helper.GeneralEnumTypes.TicketStatus.OPEN,
                Bonus = 3,
                CreateDate = DateTime.Parse("25.08.2019 18:40")
            });

            context.Ticket.Add(new Ticket
            {
                TicketOwnerId = 4,
                Description = "Kullanıcı yetkilerimde YETKI99 yok",
                Status = Helper.GeneralEnumTypes.TicketStatus.OPEN,
                Bonus = 3,
                CreateDate = DateTime.Parse("25.08.2019 18:42")
            });
            */
        }

        private string ConvertToPass(string value)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(value);
            return Convert.ToBase64String(plainTextBytes);
        }
    }
}
