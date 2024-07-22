namespace TrainAPI.DTO
{
    public class SeatCreateDTO
    {
        public string SeatNumber { get; set; }
        public bool IsAvailable { get; set; }
        public decimal Price { get; set; }
        // Add any other properties needed for creating a seat
    }
}

