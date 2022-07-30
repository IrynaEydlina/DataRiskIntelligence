using System.ComponentModel.DataAnnotations.Schema;

namespace DataRiskIntelligence.Domain.Entities;

public class Quote
{
    public int Id { get; set; }
    public string Text { get; set; }

    [ForeignKey("Person")]
    public int PersonId { get; set; }
    public Person Person { get; set; }
}