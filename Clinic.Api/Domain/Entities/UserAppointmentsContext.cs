namespace Clinic.Api.Domain.Entities
{
    public class UserAppointmentsContext
    {
        public int Id { get; set; }
        public int PractitionerId { get; set; }
        public int BusinessId { get; set; }
        public int? OutOfTurn { get; set; }
        public int? DefaultAppointmentTypeId { get; set; }
        public int? ModifierId { get; set; }
        public DateTime CreatedOn { get; set; }

    }
}
