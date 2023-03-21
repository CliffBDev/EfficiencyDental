namespace EfficiencyDental.Domain.Entities;

public class User
{
    public int Id { get; set; }
    public string EmployeeNumber { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public UserType UserType { get; set; }
    public IList<Office> Offices { get; set; }
    public Position Position { get; set; }
}