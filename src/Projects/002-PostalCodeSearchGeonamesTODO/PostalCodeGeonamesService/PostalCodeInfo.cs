namespace CSD.PostalCodeApp.Geonames
{
    public class PostalCodeInfo
    {
        public string AdminCode2 { get; set; }
        public string AdminCode1 { get; set; }
        public string AdminName2 { get; set; }
        public double Lng { get; set; }
        public string CountryCode { get; set; }
        public string PostalCode { get; set; }
        public string AdminName1 { get; set; }
        public string ISO31662 { get; set; }
        public string PlaceName { get; set; }
        public double Lat { get; set; }
    }

    public class PostalCodesInfo
    {
        public List<PostalCodeInfo> PostalCodes { get; set; }
    }

}
