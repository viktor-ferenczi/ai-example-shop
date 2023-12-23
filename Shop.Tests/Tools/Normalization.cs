using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Shop.Tests.Tools;

public static class Normalization
{
    public static string NormalizePageContent(string html)
    {
        html = NormalizeRequestVerificationToken(html);
        html = NormalizeFoodTotalIds(html);
        return html;
    }

    public static string NormalizeRequestVerificationToken(string html)
    {
        const string pattern = @"(<input[^>]*name=""__RequestVerificationToken""[^>]*value="")[^""]*("")";
        return Regex.Replace(html, pattern, $"$1NORMALIZED-VERIFICATION-TOKEN$2");
    }

    private static string NormalizeFoodTotalIds(string html)
    {
        const string idPattern = @"id=""foodTotal-(\d+)""";
        var matches = Regex.Matches(html, idPattern);
        var uniqueIds = new HashSet<string>();
        foreach (Match match in matches)
        {
            uniqueIds.Add(match.Groups[1].Value);
        }

        var idMappings = new Dictionary<string, string>();
        var counter = 1;
        foreach (var id in uniqueIds)
        {
            idMappings[id] = $"foodTotal-NORMALIZED-FOOD-TOTAL-{counter}";
            counter++;
        }

        foreach (var mapping in idMappings)
        {
            html = Regex.Replace(html, $"foodTotal-{mapping.Key}", mapping.Value);
        }

        return html;
    }
}