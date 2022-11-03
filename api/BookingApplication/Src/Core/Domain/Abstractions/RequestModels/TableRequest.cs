
namespace Domain.Abstractions.RequestModels
{
    public class TableRequest
    {
        public int? Number { get; set; }
        public string? Description { get; set; }
        public Guid? RestaurantId { get; set; }
    }
}
