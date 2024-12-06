namespace EmploymentTest.Model
{
    public class Repository
    {
        public class Owner
        {
            public string avatar_url { get; set; }
        }

        public class Root
        {
            public int id { get; set; }
            public string name { get; set; }
            public Owner owner { get; set; }
            public string description { get; set; }
            public string html_url { get; set; }
            public string avatar_url => owner.avatar_url;
        }
    }
}
