namespace casaWinOS.Data
{
    public interface ISelectableApp
    {
        string Name { get; set; }
        string Url { get; set; }
        string IconPath { get; set; }

        void UpdateUrl(string url);
        void UpdateIconPath(string path);
        void UpdateName(string name);
    }
}