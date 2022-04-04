namespace App11.Classes
{
    public class MobSpec
    {
        public string MobName;
        public int ImageResourceId;
        public string Display;
        public string Camera;
        public string Battary;
        public string Processor;
        public string Price;

        public MobSpec(string MobName, int ImageResourceId, string Display, string Camera, string Battary, string Processor, string Price)
        {
            this.MobName = MobName;
            this.ImageResourceId = ImageResourceId;
            this.Display = Display;
            this.Camera = Camera;
            this.Battary = Battary;
            this.Processor = Processor;
            this.Price = Price;
        }
    }
}