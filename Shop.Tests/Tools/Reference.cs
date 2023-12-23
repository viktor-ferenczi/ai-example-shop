using System.IO;
using System.Reflection;
using System.Text;
using Shop.Tests.Tools;
using Xunit;

namespace Shop.Tests.Tools;

public class Reference
{
    private readonly string _filename;
    private readonly Encoding _encoding;

    private string ProjectDir => ProjectInfo.FindProjectDir();
    private string OutputDir => Path.Combine(ProjectDir, "Output");

    private string ActualDir => Path.Combine(OutputDir, "Actual");
    private string ActualPath => Path.Combine(ActualDir, _filename);

    private string ReferenceDir => Path.Combine(OutputDir, "Reference");
    private string ReferencePath => Path.Combine(ReferenceDir, _filename);

    public Reference(string filename, Encoding encoding = null)
    {
        _filename = filename;
        _encoding = encoding ?? Encoding.UTF8;

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