namespace Challenge.MELI.Domain.Dtos
{
    public class StatsDto
    {
        public int Call { get; set; }
        public double Distance { get; set; }
        public double Average { get; set; }
        public double MinDist { get; set; }
        public double MaxDist { get; set; }

        public double CalculateAvarage(double call,double distance)
        {
            var average = distance / call;

            return average;
        }

        public void UpdateMinMax(double distance)
        {
            this.MinDist = distance <= this.MinDist ? distance : this.MinDist;
            this.MaxDist = distance >= this.MaxDist ? distance : this.MaxDist;
        }
    }
}
