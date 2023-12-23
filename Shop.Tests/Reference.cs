using System.IO;
using System.Reflection;
using System.Text;
using Xunit;

namespace Shop.Tests;

public class Reference
{
    private readonly string _filename;
    private readonly Encoding _encoding;

    private string TestsDir => @"C:\Dev\AI\Coding\example-shop\Shop.Tests";
    private string OutputDir => Path.Combine(TestsDir, "Output");

    private string ActualDir => Path.Combine(OutputDir, "Actual");
    private string ActualPath => Path.Combine(ActualDir, _filename);

    private string ReferenceDir => Path.Combine(OutputDir, "Reference");
    private string ReferencePath => Path.Combine(ReferenceDir, _filename);

    public Reference(string filename, Encoding encoding = null)
    {
        _filename = filename;
        _encoding = encoding ?? Encoding.UTF8;

        Assert.True(File.Exists(Path.Combine(TestsDir, $"{nameof(Reference)}.cs")),
            $"Wrong TestsDir: {TestsDir}; Make sure to run the tests from the test project's directory.");

        Directory.CreateDirectory(OutputDir);
        Directory.CreateDirectory(ActualDir);
        Directory.CreateDirectory(ReferenceDir);
    }

    public void Verify(string actual)
    {
        File.WriteAllText(ActualPath, actual, _encoding);

        Assert.True(File.Exists(ReferencePath), $"Reference file is missing: {_filename}");
        var reference = File.ReadAllText(ReferencePath, _encoding);

        Assert.True(reference == actual, $"Actual output is not matching reference: {_filename}");
    }
}