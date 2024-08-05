using Finance.Base.Extensions;
using Finance.Domain.Entities.Auth;
using Finance.Domain.Entities.Companies;
using Finance.Domain.Entities.Menus;
using Finance.Persistence.Context;

namespace Finance.API
{
    public class FakeDataGenerate
    {
        private readonly FinanceDbContext context;
        public FakeDataGenerate(FinanceDbContext _context)
        {
            context = _context;
        }

        public void Generate()
        {
            Company company = new Company
            {
                Id = "0",
                Sector = "Finance",
                Name = "HDI",
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow,
            };

            Company company2 = new Company
            {
                Sector = "Software",
                Name = "Ortak 1",
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow,
            };

            Company company3 = new Company
            {
                Sector = "Marketing",
                Name = "Ortak 2",
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow,
            };

            context.Companies.Add(company);
            context.Companies.Add(company2);
            context.Companies.Add(company3);
            context.SaveChanges();

            Role role1 = new Role
            {
                Name = "Admin",
            };

            Role role2 = new Role
            {
                Name = "BusinessPartner"
            };

            context.Roles.Add(role1);
            context.Roles.Add(role2);
            context.SaveChanges();


            var user = new User();
            user.Name = "Doğukan";
            user.Surname = "Kızıltepe";
            user.EMail = "dogukan@mail.com";
            user.Password = HashPassword.Hash("123456");
            user.Company = company;
            user.Role = role1;
            user.CreatedDate = DateTime.Now;
            context.Users.Add(user);
            context.SaveChanges();


            var user2 = new User();
            user2.Name = "Hasan";
            user2.Surname = "Yılmaz";
            user2.EMail = "hasan@mail.com";
            user2.Password = HashPassword.Hash("123456");
            user2.Company = company2;
            user2.Role = role2;
            user2.CreatedDate = DateTime.Now;
            context.Users.Add(user2);
            context.SaveChanges();

            var user3 = new User();
            user3.Name = "Mehmet";
            user3.Surname = "Aslan";
            user3.EMail = "mehmet@mail.com";
            user3.Password = HashPassword.Hash("123456");
            user3.Company = company3;
            user3.Role = role2;
            user3.CreatedDate = DateTime.Now;
            context.Users.Add(user3);
            context.SaveChanges();

        }
    }
}
