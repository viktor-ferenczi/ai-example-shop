using System;
using System.IO;
using System.Linq;

namespace Shop.Tests.Tools;

public static class ProjectInfo
{
    public static string FindSolutionDir()
    {
        // Start with the current directory of the test assembly
        var directory = new DirectoryInfo(Directory.GetCurrentDirectory());

        while (directory != null && !directory.GetFiles("*.sln").Any())
        {
            directory = directory.Parent;
        }

        if (directory == null)
            throw new InvalidOperationException("Could not find the solution folder");

        return directory.FullName;
    }

    public static string FindProjectDir()
    {
        // Start with the current directory of the test assembly
        var directory = new DirectoryInfo(Directory.GetCurrentDirectory());

        while (directory != null && !directory.GetFiles("*.csproj").Any())
        {
            directory = directory.Parent;
        }

        if (directory == null)
            throw new InvalidOperationException("Could not find the project folder");

        return directory.FullName;
    }
}