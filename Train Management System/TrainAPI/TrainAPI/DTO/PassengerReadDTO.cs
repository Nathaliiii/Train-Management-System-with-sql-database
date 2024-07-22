namespace TrainAPI.DTO
{
    public class PassengerReadDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Nationality { get; set; }
        // Add any other properties needed for reading a passenger
    }
}
