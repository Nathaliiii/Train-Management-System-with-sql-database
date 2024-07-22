namespace TrainAPI.DTO
{
    public class SeatReadDTO
    {
        public int Id { get; set; }
        public string SeatNumber { get; set; }
        public bool IsAvailable { get; set; }
        public decimal Price { get; set; }
        // Add any other properties needed for reading a seat
    }
}

