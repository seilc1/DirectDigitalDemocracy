using DirectDigitalDemocracy.Core.Regions;
using DirectDigitalDemocracy.Modules.Laws.Models;
using System.Text.RegularExpressions;

namespace DirectDigitalDemocracy.Modules.Laws
{
    public class TemplateTextParser
    {
        private static readonly Regex VariableRegex = new ("\\{\\{([^\\}]*)\\}\\}", RegexOptions.Compiled);
        private static readonly Regex RegionRegex = new ("^\\w+\\:[a-zA-Z ]+$", RegexOptions.Compiled);

        public const string Separator = ":";
        public const string CreditsVariableName = "Credits";
        public const string FundVariableName = "Fund";

        public static TemplateTextParser Instance { get; } = new TemplateTextParser();

        private TemplateTextParser() { }

        public static IEnumerable<Variable> Parse(string lawTemplateText) 
            => VariableRegex.Matches(lawTemplateText).Select(ParseVariable);

        private static Variable ParseVariable(Match variableMatch)
        {
            string result = variableMatch.Groups[1].Value.Trim();
            int separatorIndex = result.IndexOf(":");

            string name = result[0..separatorIndex].Trim();
            string value = result[(separatorIndex+1)..^0].Trim();

            return new Variable(name, value, EvaluateType(name, value));
        }

        private static VariableType EvaluateType(string name, string value)
        {
            if (name.Equals(CreditsVariableName, StringComparison.OrdinalIgnoreCase) && ValidateDoubleValue(value))
            {
                return VariableType.Credits;
            }

            if (ValidateRegionValue(value))
            {
                if (name.Equals(FundVariableName, StringComparison.OrdinalIgnoreCase))
                {
                    return VariableType.Fund;
                }

                return VariableType.Region;
            }

            if (ValidateDoubleValue(value))
            {
                if (name.Equals(CreditsVariableName, StringComparison.OrdinalIgnoreCase))
                {
                    return VariableType.Credits;
                }

                return VariableType.Double;
            }

            throw new FormatException($" Variable:`{name}` with value:`{value} could not parsed.");
        }

        private static bool ValidateDoubleValue(string value)
            => double.TryParse(value.Replace("_", string.Empty), out _);

        private static bool ValidateRegionValue(string value)
            => value.Equals(Region.GlobalName, StringComparison.OrdinalIgnoreCase) || RegionRegex.IsMatch(value);
    }
}