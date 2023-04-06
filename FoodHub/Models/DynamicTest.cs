namespace FoodHub.Models
{
    public class DynamicTest
    {
        public int Id { get; set; }
        public bool Circumduction { get; set; }
        public bool Kyphosis { get; set; }
        public bool Lordosis { get; set; }
        public bool Scoliosis { get; set; }
        public bool Shulder { get; set; }
        public User User { get; set; }
    }

    public class dynamicTestDto
    {
        public string ClientId { get; set; }
        public bool Circumduction { get; set; }
        public bool Kyphosis { get; set; }
        public bool Lordosis { get; set; }
        public bool Scoliosis { get; set; }
        public bool Shulder { get; set; }
    }
}
