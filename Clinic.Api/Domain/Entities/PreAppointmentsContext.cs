namespace Clinic.Api.Domain.Entities
{
    public class PreAppointmentsContext
    {
        public int Id { get; set; }
        public int PractitionerId { get; set; }
        public int BusinessId { get; set; }
        public int AppointmentTypeId { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
        public string? Time { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Mobile { get; set; }
        public string? Code { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
