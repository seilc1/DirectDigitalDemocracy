namespace DirectDigitalDemocracy.Core.Regions
{
    public record Region(string Level, string Name, Region? Parent)
    {
        public const string GlobalName = "GLOBAL";

        public static Region Global => new (GlobalName, GlobalName, null);
    }
}