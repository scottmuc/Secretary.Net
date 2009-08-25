namespace Secretary
{
    public class Location
    {
        public static readonly Location Web = new Location("Web");
        public static readonly Location Local = new Location("Local");

        private readonly string name;

        public Location(string name)
        {
            this.name = name;
        }

        public override string ToString()
        {
            return "Location." + name;
        }
    }
}
