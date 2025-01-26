namespace casaWinOS.Data
{
    public class SelectableApp : ISelectableApp
    {
        private string name;
        private string iconPath;
        private string url;
        public SelectableApp(string name, string iconPath, string url)
        {
            this.name = name;
            this.iconPath = iconPath;
            this.url = url;
        }


        // Parameterless constructor required by Entity Framework
        public SelectableApp() { }

        public int Id {  get; set; }

        public string Name
        {
            get => this.name;
            set
            {
                if (this.name != value)
                {
                    this.name = value;
                }
            }
        }

        public string Url
        {
            get => this.url;
            set
            {
                if (this.url != value)
                {
                    this.url = value;
                }
            }
        }

        public string IconPath
        {
            get => this.iconPath;
            set
            {
                if (this.iconPath != value)
                {
                    this.iconPath = value;
                }
            }
        }

        public void UpdateIconPath(string path)
        {
            this.IconPath = path;
        }

        public void UpdateName(string name)
        {
            this.Name = name;
        }

        public void UpdateUrl(string url)
        {
            this.Url = url;
        }
    }
}
