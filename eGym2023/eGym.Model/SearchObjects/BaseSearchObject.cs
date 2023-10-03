namespace eGym2023.Model.SearchObjects
{
    public class BaseSearchObject
    {
        public int? Page { get; set; }
        public int? PageSize { get; set; }
        //Dodati validaciju da se moze unijeti samo asc ili desc
        public string? OrderBy { get; set; }
        public string? OrderDirection { get; set; }
    }
}
