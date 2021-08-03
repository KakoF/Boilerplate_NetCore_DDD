using System;

namespace Api.Domain.Models
{
    public class CityModel : BaseModel
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _iso;
        public string Iso
        {
            get { return _iso; }
            set { _iso = value; }
        }
        private string _slug;
        public string Slug
        {
            get { return _slug; }
            set { _slug = value; }
        }
        private double _lat;
        public double Lat
        {
            get { return _lat; }
            set { _lat = value; }
        }
        private double _long;
        public double Long
        {
            get { return _long; }
            set { _long = value; }
        }

        private int _stateId;
        public int StateId
        {
            get { return _stateId; }
            set { _stateId = value; }
        }
    }
}