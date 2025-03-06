namespace TDDTestingMVC.Models
{
    public class AreaCirculo
    {
        public int area { get; set; }

        public float pi { get; set; }

        public int CalcularArea()
        {
            return (int)(pi * area * area);
        }
    }
}
