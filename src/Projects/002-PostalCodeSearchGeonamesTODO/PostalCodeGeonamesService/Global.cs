namespace CSD.PostalCodeApp.Geonames
{
    static class Global
    {
        public const string PostalCodeUrlTemplate = @"http://api.geonames.org/postalCodeSearchJSON?postalcode={0}&maxRows=10&username=csystem&style=full&country=tr";
    }
}
