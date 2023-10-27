namespace TwitchLib.Api.Helix.Models.Helpers
{
    public class ExtensionAnalytics
    {
        public string Date { get; set; }
        public string ExtensionName { get; set; }
        public string ExtensionClientId { get; set; }
        public int Installs { get; set; }
        public int Uninstalls { get; set; }
        public int Activations { get; set; }
        public int UniqueActiveChannels { get; set; }
        public int Renders { get; set; }
        public int UniqueRenders { get; set; }
        public int Views { get; set; }
        public int UniqueViewers { get; set; }
        public int UniqueInteractors { get; set; }
        public int Clicks { get; set; }
        public double ClicksPerInteractor { get; set; }
        public double InteractionRate { get; set; }

        public ExtensionAnalytics(string row)
        {
            var p = row.Split(',');
            Date = p[0];
            ExtensionName = p[1];
            ExtensionClientId = p[2];
            Installs = int.Parse(p[3]);
            Uninstalls = int.Parse(p[4]);
            Activations = int.Parse(p[5]);
            UniqueActiveChannels = int.Parse(p[6]);
            Renders = int.Parse(p[7]);
            UniqueRenders = int.Parse(p[8]);
            Views = int.Parse(p[9]);
            UniqueViewers = int.Parse(p[10]);
            UniqueInteractors = int.Parse(p[11]);
            Clicks = int.Parse(p[12]);
            ClicksPerInteractor = double.Parse(p[13]);
            InteractionRate = double.Parse(p[14]);
        }
    }
}
