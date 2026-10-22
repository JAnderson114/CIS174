namespace CIS174_M06RazorTemplates.Models
{
    public class OlympicSession
    {
        private const string FavoritesKey = "olympicFavorites";

        private readonly ISession session;

        public OlympicSession(ISession session)
        {
            this.session = session;
        }

        public List<OlympicCountry> GetFavorites()
        {
            return session.GetObject<List<OlympicCountry>>(
                FavoritesKey) ?? new List<OlympicCountry>();
        }

        public void SetFavorites(List<OlympicCountry> countries)
        {
            session.SetObject(FavoritesKey, countries);
        }

        public int GetFavoriteCount()
        {
            return GetFavorites().Count;
        }

        public void ClearFavorites()
        {
            session.Remove(FavoritesKey);
        }

        public bool IsFavorite(string countryName)
        {
            return GetFavorites().Any(c =>
                c.Country == countryName);
        }
    }
}