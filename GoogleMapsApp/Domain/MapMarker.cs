namespace Domain
{
    public class MapMarker
    {
        private int _id;
        private string _name;
        private double _latitude;
        private double _longitude;

     

        public MapMarker(int id, string name, double latitude, double longitude)
        {
            Id = id;
            Name = name;
            Latitude = latitude;
            Longitude = longitude;
        }
        
        public int Id
        {
            get => _id;
            set => _id = value;
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public double Latitude
        {
            get => _latitude;
            set => _latitude = value;
        }

        public double Longitude
        {
            get => _longitude;
            set => _longitude = value;
        }
    }
    
}

