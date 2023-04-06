namespace FoodHub.Models
{
    public class FitnessTest
    {
        public int Id { get; set; }
        public int ArmFirstSit { get; set; }
        public int ArmSecondSit { get; set; }
        public int ArmThirdSit { get; set; }
        public int CurlUpFirstSit { get; set; }
        public int CurlUpSecondSit { get; set; }
        public int CurlUpThirdSit { get; set; }
        public int ModifiedFirstSit { get; set; }
        public int ModifiedSecondSit { get; set; }
        public int ModifiedThirdSit { get; set; }
        public int PushUpFirstSit { get; set; }
        public int PushUpSecondSit { get; set; }
        public int PushUpThirdSit { get; set; }
        public int PlankFirstSit { get; set; }
        public int PlankSecondSit { get; set; }
        public int PlankThirdSit { get; set; }
        public int SidePlankFirstSit { get; set; }
        public int SidePlankSecondSit { get; set; }
        public int SidePlankThirdSit { get; set; }
        public int WallSetFirstSit { get; set; }
        public int WallSetSecondSit { get; set; }
        public int WallSetThirdSit { get; set; }
        public User User { get; set; }
    }

    public class FitnessTestDto
    {
        public int ArmFirstSit { get; set; }
        public int ArmSecondSit { get; set; }
        public int ArmThirdSit { get; set; }
        public int CurlUpFirstSit { get; set; }
        public int CurlUpSecondSit { get; set; }
        public int CurlUpThirdSit { get; set; }
        public int ModifiedFirstSit { get; set; }
        public int ModifiedSecondSit { get; set; }
        public int ModifiedThirdSit { get; set; }
        public int PushUpFirstSit { get; set; }
        public int PushUpSecondSit { get; set; }
        public int PushUpThirdSit { get; set; }
        public int PlankFirstSit { get; set; }
        public int PlankSecondSit { get; set; }
        public int PlankThirdSit { get; set; }
        public int SidePlankFirstSit { get; set; }
        public int SidePlankSecondSit { get; set; }
        public int SidePlankThirdSit { get; set; }
        public int WallSetFirstSit { get; set; }
        public int WallSetSecondSit { get; set; }
        public int WallSetThirdSit { get; set; }
        public string ClientId { get; set; }
    }
}

