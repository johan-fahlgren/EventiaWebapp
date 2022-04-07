namespace DataLayer.Model
{
    public class RoleApplication
    {
        public int id { get; set; }
        public ICollection<EventiaUser>? Applicants { get; set; }

    }
}
