namespace EntitySamples.Behavior
{
    public class FlightDate
    {
        public DateTime Departure { get; set; }
        public DateTime Returning { get; set; }
        public FlightDate(DateTime departure,DateTime returning)
        {
            if (departure > returning) throw new InvalidOperationException("Incorrect Inputs");            
            Departure = departure;
            Returning = returning;
        }
    }
}
