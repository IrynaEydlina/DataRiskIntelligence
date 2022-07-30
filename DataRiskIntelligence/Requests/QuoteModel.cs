using System.ComponentModel.DataAnnotations;

namespace DataRiskIntelligence.Requests;

public class QuoteModel
{
    [Required]
    [MaxLength(1000)]
    public string Text { get; set; }

    [Required]
    public int PersonId { get; set; }
}
