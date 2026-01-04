using Bogus;
using CRM.Core.Enums;
using CRM.Core.Models;
using CRM.Infrastructure.Data;
using CRM.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CRM.Api.Seeding
{
    public static class DataSeeder
    {
        public static async Task SeedData(CrmDbContext context, IServiceProvider serviceProvider)
        {
            if (await context.Companies.AnyAsync()) return;

            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            var admin = await userManager.FindByEmailAsync("admin@crm.pl");
            var manager = await userManager.FindByEmailAsync("manager@crm.pl");
            var basicUser = await userManager.FindByEmailAsync("user@crm.pl");

            var users = new[] { admin, manager, basicUser };

            if (users is null || manager is null || basicUser is null) return;
                
            foreach (var user in users)
            {
                Faker<Company> companyFaker = new Faker<Company>()
               .RuleFor(c => c.Id, f => f.Random.Guid())
               .RuleFor(c => c.UserId, user.Id)
               .RuleFor(c => c.Name, f => f.Company.CompanyName())
               .RuleFor(c => c.Industry, f => f.Commerce.Department())
               .RuleFor(c => c.Website, f => f.Internet.Url())
               .RuleFor(c => c.PhoneNumber, f => f.Phone.PhoneNumber("#########"))
               .RuleFor(c => c.Address, f => f.Address.FullAddress())
               .RuleFor(c => c.CreatedAt, f => f.Date.Past(5));

                var companies = companyFaker.Generate(15);

                await context.Companies.AddRangeAsync(companies);

                foreach (var company in companies)
                {
                    Faker<Contact> contactFaker = new Faker<Contact>()
                        .RuleFor(c => c.Id, f => f.Random.Guid())
                        .RuleFor(c => c.CompanyId, company.Id)
                        .RuleFor(c => c.UserId, user.Id)
                        .RuleFor(c => c.FirstName, f => f.Person.FirstName)
                        .RuleFor(c => c.LastName, f => f.Person.LastName)
                        .RuleFor(c => c.Email, (f, c) => f.Internet.Email(c.FirstName, c.LastName))
                        .RuleFor(c => c.PhoneNumber, f => f.Phone.PhoneNumber("#########"))
                        .RuleFor(c => c.Position, f => f.Name.JobTitle())
                        .RuleFor(c => c.CreatedAt, f => f.Date.Between(company.CreatedAt, DateTime.Now));
                    
                    var contacts = contactFaker.Generate(5);

                    await context.Contacts.AddRangeAsync(contacts);

                    foreach (var contact in contacts)
                    {
                        Faker<Activity> activityFaker = new Faker<Activity>()
                            .RuleFor(a => a.Id, f => f.Random.Guid())
                            .RuleFor(a => a.CompanyId, company.Id)
                            .RuleFor(a => a.ContactId, contact.Id)
                            .RuleFor(a => a.UserId, user.Id)
                            .RuleFor(a => a.Type, f => f.PickRandom<ActivityType>())
                            .RuleFor(a => a.Subject, f => f.Lorem.Sentence().TrimEnd('.'))
                            .RuleFor(a => a.Description, f => f.Lorem.Paragraph().OrNull(f, 0.2f))
                            .RuleFor(a => a.CreatedAt, f => f.Date.Between(contact.CreatedAt, DateTime.Now));


                        var activities = activityFaker.GenerateBetween(1, 5);

                        await context.Activities.AddRangeAsync(activities);

                        Faker<Lead> leadFaker = new Faker<Lead>()
                            .RuleFor(l => l.Id, f => f.Random.Guid())
                            .RuleFor(l => l.CompanyId, company.Id)
                            .RuleFor(a => a.ContactId, contact.Id)
                            .RuleFor(a => a.UserId, user.Id)
                            .RuleFor(a => a.Title, f => f.Lorem.Sentence().TrimEnd('.'))
                            .RuleFor(a => a.Value, f => f.Random.Decimal(500, 50000))
                            .RuleFor(a => a.Stage, f => f.PickRandom<LeadStage>())
                            .RuleFor(a => a.CreatedAt, f => f.Date.Between(contact.CreatedAt, DateTime.Now));
                        
                        if (new Random().NextDouble() > 0.7)
                        {
                            var leads = leadFaker.Generate();
                            await context.Leads.AddRangeAsync(leads);
                        }
                    }
                }
            }
            await context.SaveChangesAsync();

        }
    }
}
