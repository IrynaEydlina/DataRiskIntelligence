using System.ComponentModel.DataAnnotations;

namespace DataRiskIntelligence.Requests;

public class PersonModel
{
    [Required]
    [MaxLength(100)]
    public string FirstName { get; set; }

    [Required]
    [MaxLength(100)]
    public string LastName { get; set; }
}