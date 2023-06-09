namespace EfficiencyDental.Domain.Entities;

public class Patient
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public bool Insured { get; set; }
    public string SocialSecurityNumber { get; set; }
    public Insurance Insurance { get; set; }
}