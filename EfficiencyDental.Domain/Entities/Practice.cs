namespace EfficiencyDental.Domain.Entities;

public class Practice
{
    public int Id { get; set; }
    public string Name { get; set; }
    public IList<Office> Offices { get; set; }
}