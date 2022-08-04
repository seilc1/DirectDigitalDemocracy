using DirectDigitalDemocracy.Modules.Laws;
using FluentAssertions;
using System.Linq;
using Xunit;

namespace DirectDigitalDemocracy.Modules.Tests.Laws
{
    public class TemplateTextParserFixture
    {
        [Fact]
        public void Parse_ShouldParseMultipleVariables()
        {
            // Arrange
            string templateText = "Request to spend {{ credits : 10_000 }} from the fund {{ fund:state:northern alps }} for repairs on the road between Bern and Biel.";

            // Act
            var variables = TemplateTextParser.Parse(templateText).ToList();

            // Assert
            variables.Should().HaveCount(2);

            variables.Should().Contain(v => v.Name == "credits" && v.VariableType == Modules.Laws.Models.VariableType.Credits && v.Value == "10_000");
            variables.Should().Contain(v => v.Name == "fund" && v.VariableType == Modules.Laws.Models.VariableType.Fund && v.Value == "state:northern alps");
        }

        [Fact]
        public void Parse_ShouldParseNoVariables()
        {
            // Arrange
            string templateText = "A member of the Direct Digital Democracy is required to pay an annual fee.";

            // Act
            var variables = TemplateTextParser.Parse(templateText).ToList();

            // Assert
            variables.Should().HaveCount(0);
        }

        [Fact]
        public void Parse_ShouldParseMultipleDoubleVariables()
        {
            // Arrange
            string templateText = @"The fee is to be forwarded to the different region funds with the following percentages:
{{ global_percentage: 10}}%
{{sector_precentage: 25}}%
{{ state_percentage : 40   }}%
{{ city_percentage: 25}}% ";

            // Act
            var variables = TemplateTextParser.Parse(templateText).ToList();

            // Assert
            variables.Should().HaveCount(4);

            variables.Should().Contain(v => v.Name == "global_percentage" && v.VariableType == Modules.Laws.Models.VariableType.Double && v.Value == "10");
            variables.Should().Contain(v => v.Name == "sector_precentage" && v.VariableType == Modules.Laws.Models.VariableType.Double && v.Value == "25");
            variables.Should().Contain(v => v.Name == "state_percentage" && v.VariableType == Modules.Laws.Models.VariableType.Double && v.Value == "40");
            variables.Should().Contain(v => v.Name == "city_percentage" && v.VariableType == Modules.Laws.Models.VariableType.Double && v.Value == "25");
        }


        [Fact]
        public void Parse_ShouldParseRegionVariable()
        {
            // Arrange
            string templateText = @"All exports to {{ region:continent:europe }} are to be taxed by {{ export_tax: 4 }}% to be transfered to the {{ fund: continent:LOCAL }}.";

            // Act
            var variables = TemplateTextParser.Parse(templateText).ToList();

            // Assert
            variables.Should().HaveCount(3);

            variables.Should().Contain(v => v.Name == "region" && v.VariableType == Modules.Laws.Models.VariableType.Region && v.Value == "continent:europe");
            variables.Should().Contain(v => v.Name == "export_tax" && v.VariableType == Modules.Laws.Models.VariableType.Double && v.Value == "4");
            variables.Should().Contain(v => v.Name == "fund" && v.VariableType == Modules.Laws.Models.VariableType.Fund && v.Value == "continent:LOCAL");
        }
    }
}