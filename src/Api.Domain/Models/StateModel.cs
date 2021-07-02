namespace Api.Domain.Models
{
    public class StateModel : BaseModel
    {
        private string _initials;
        public string Initials
        {
            get { return _initials; }
            set { _initials = value; }
        }

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


    }
}