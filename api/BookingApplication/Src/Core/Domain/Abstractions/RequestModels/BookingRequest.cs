
namespace Domain.Abstractions.RequestModels
{
    public class BookingRequest
    {
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public Guid? ClientId { get; set; }
        public Guid? TableId { get; set; }
    }
}
