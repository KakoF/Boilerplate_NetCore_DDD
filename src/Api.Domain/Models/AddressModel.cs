using System;

namespace Api.Domain.Models
{
    public class AddressModel : BaseModel
    {
        private string _zipCode;
        public string ZipCode
        {
            get { return _zipCode; }
            set { _zipCode = value; }
        }

        private string _address;
        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }
        private string _district;
        public string District
        {
            get { return _district; }
            set { _district = value; }
        }

        private string _number;
        public string Number
        {
            get { return _number; }
            set
            {
                _number = string.IsNullOrEmpty(value) ? "S/N" : value;
            }
        }

        private Guid _countyId;
        public Guid CountyId
        {
            get { return _countyId; }
            set { _countyId = value; }
        }
    }
}