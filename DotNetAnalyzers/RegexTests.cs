using System.Text.RegularExpressions;
using FluentAssertions;

namespace DotNetAnalyzers;

public class RegexTests
{
    private const string pattern = @"^[0-9]{3}\.[0-9]{3}\.[0-9]{3}$";

    [TestCase("123.456.789", true)]
    [TestCase("123456789", false)]
    public void ValidateInput(string input, bool expected)
    {
        bool isMatch = Regex.IsMatch(input, pattern);

        isMatch.Should().Be(expected);
    }
}
