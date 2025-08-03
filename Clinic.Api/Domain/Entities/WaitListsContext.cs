namespace Clinic.Api.Domain.Entities
{
    public class WaitListsContext
    {
        public int Id { get; set; }
        public bool AvailableOnSat { get; set; }
        public bool AvailableOnSun { get; set; }
        public bool AvailableOnMon { get; set; }
        public bool AvailableOnTue { get; set; }
        public bool AvailableOnWed { get; set; }
        public bool AvailableOnThr { get; set; }
        public bool Urgent { get; set; }
        public bool OnlyOutsideBussinessHours { get; set; }
        public string? ExtraInfo { get; set; }
        public bool Removed { get; set; }
        public int PatientId { get; set; }
        public int? ModifierId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? LastUpdated { get; set; }
        public int? CreatorId { get; set; }
    }
}
