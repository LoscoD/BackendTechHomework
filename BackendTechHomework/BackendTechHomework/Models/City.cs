
namespace BackendTechHomework.Models
{
    class City
    {
        public int Id { get; set; }
        public string Uuid { get; set; }
        public bool Top { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Content { get; set; }
        public string MetaDescription { get; set; }
        public string MetaTitle { get; set; }
        public string Headline { get; set; }
        public string More { get; set; }
        public int Weight { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public Country Country { get; set; }
        public string CoverImageUrl { get; set; }
        public string Url { get; set; }
        public int ActivitiesCount { get; set; }
        public string TimeZone { get; set; }
        public int ListCount { get; set; }
        public int VenueCount { get; set; }
        public bool ShowInPopular { get; set; }
    }
}
