using DataRiskIntelligence.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataRiskIntelligence.Persistance;

public static class ModelBuilderExtensions
{
    public static void Seed(this ModelBuilder modelBuilder)
    {
        var quotes = new Quote[]
        {
            new() { Id = 1, Text = "Anyone who has ever made anything of importance was disciplined." } ,
            new() { Id = 2, Text = "Don’t spend time beating on a wall, hoping to transform it into a door." } ,
            new() { Id = 3, Text = "Creativity is intelligence having fun." },
            new() { Id = 4, Text = "Optimism is the one quality more associated with success and happiness than any other." },
            new() { Id = 5 ,Text = "Always keep your eyes open. Keep watching. Because whatever you see can inspire you." },
            new() { Id = 6, Text = "What you get by achieving your goals is not as important as what you become by achieving your goals." },
            new() { Id = 7, Text = "If the plan doesn’t work, change the plan, but never the goal." },
            new() { Id = 8, Text = "I destroy my enemies when I make them my friends." },
            new() { Id = 9, Text = "Don’t live the same year 75 times and call it a life." },
            new() { Id = 10, Text = "You cannot save people, you can just love them." }
        };

        var people = new Person[]
        {
            new (){ Id = 1, FirstName = "Andrew", LastName="Hendrixson" },
            new (){ Id = 2, FirstName = "Coco", LastName="Chanel" },
            new (){ Id = 3, FirstName = "Albert", LastName="Einstein" },
            new (){ Id = 4, FirstName = "Brian", LastName="Tracy" },
            new (){ Id = 5, FirstName = "Grace", LastName="Coddington" },
            new (){ Id = 6, FirstName = "Henry David", LastName="Thoreau" },
            new (){ Id = 7, FirstName = "Unknown", LastName="Unknown" },
            new (){ Id = 8, FirstName = "Abraham", LastName="Lincoln" },
            new (){ Id = 9, FirstName = "Robin", LastName="Shaurma" },
            new (){ Id = 10, FirstName = "Anaïs", LastName="Nin" }
        };

        for (int i = 0; i < 10; i++)
        {
            quotes[i].PersonId = people[i].Id;
        }
        modelBuilder.Entity<Person>().HasData(people);
        modelBuilder.Entity<Quote>().HasData(quotes);
    }
}
