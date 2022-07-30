using DataRiskIntelligence.Domain.Entities;

namespace DataRiskIntelligence.Domain.Extensions;

public static class PersonExtensions
{
    public static string GetFullName(this Person person) => $"{person?.FirstName} {person.LastName}";
}