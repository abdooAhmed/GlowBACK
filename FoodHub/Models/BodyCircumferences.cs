namespace FoodHub.Models
{
    public class BodyCircumferences
    {
        public int Id { get; set; }
        public float ShoulderCircumference { get; set; }
        public float ArmCircumference { get; set; }
        public float ThighCircumference { get; set; }
        public float QuailCircumference { get; set; }
        public float WaistCircumference { get; set; }
        public string Name { get; set; }
        public User User { get; set; }
    }

    public class BodyCircumferencesDto
    {
        public float ShoulderCircumference { get; set; }
        public float ArmCircumference { get; set; }
        public float ThighCircumference { get; set; }
        public float QuailCircumference { get; set; }
        public float WaistCircumference { get; set; }
        public string Name { get; set; }
        public string ClientId { get; set; }
    }

}
