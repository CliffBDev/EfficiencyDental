namespace EfficiencyDental.Domain.Entities;

public class Office
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int PracticeId { get; set; }
    public IList<Room> Rooms { get; set; }
    public IList<User> Users { get; set; }
}