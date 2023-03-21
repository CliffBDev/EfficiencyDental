namespace EfficiencyDental.Domain.Entities;

public class Appointment
{
    public int Id { get; set; }
    public DateTime StartTimeUTC { get; set; }
    public int LengthInMinutes { get; set; }
    public DateTime ProjectedEndTime { get; set; }
    public Patient Patient { get; set; }
    public User Provider { get; set; }
    public List<User> MedicalStaff { get; set; }
    public Office Office { get; set; }
    public Room Room { get; set; }
    public AppointmentStatus AppointmentStatus { get; set; }
    public AppointmentType AppointmentType { get; set; }
}