# ISSUE
```json
{
  "author": "adlan.elm@gmail.com",
  "cleanCodeAttribute": "FOCUSED",
  "cleanCodeAttributeCategory": "ADAPTABLE",
  "codeVariants": [],
  "component": "Shop:Shop.Data/IOrder.cs",
  "creationDate": "2023-12-02T12:56:54+01:00",
  "debt": "20min",
  "effort": "20min",
  "flows": [],
  "hash": "acd6f3dc089615a05e38bffe36d5bbbb",
  "impacts": [
    {
      "severity": "MEDIUM",
      "softwareQuality": "MAINTAINABILITY"
    }
  ],
  "key": "AYxrM9VHedpPdGXiJkN3",
  "line": 17,
  "message": "Method has 9 parameters, which is greater than the 7 authorized.",
  "messageFormattings": [],
  "project": "Shop",
  "quickFixAvailable": false,
  "rule": "csharpsquid:S107",
  "scope": "MAIN",
  "severity": "MAJOR",
  "status": "OPEN",
  "tags": [
    "brain-overload"
  ],
  "textRange": {
    "endLine": 27,
    "endOffset": 13,
    "startLine": 17,
    "startOffset": 44
  },
  "type": "CODE_SMELL",
  "updateDate": "2023-12-15T02:59:29+01:00"
}
```

# PATH
`C:\Dev\AI\Coding\example-shop\Shop.Data/IOrder.cs`

# ORIGINAL
```cs
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Shop.Data.Enums;
using Shop.Data.Models;

namespace Shop.Data
{
    public interface IOrder
    {
        void CreateOrder(Order order);
        Order GetById(int orderId);
        IEnumerable<Order> GetByUserId(string userId);
        IEnumerable<Order> GetAll();
        IEnumerable<Order> GetUserLatestOrders(int count, string userId);
        IEnumerable<Food> GetUserMostPopularFoods(string id);
        IEnumerable<Order> GetFilteredOrders(
            string userId = null,
            OrderBy orderBy = OrderBy.None,
            int offset = 0,
            int limit = 10,
            decimal? minimalPrice = null,
            decimal? maximalPrice = null,
            DateTime? minDate = null,
            DateTime? maxDate = null,
            string zipCode = null
            );
    }
}
```

# SYSTEM
MODEL ADOPTS ROLE OF CODEULATOR.
[CONTEXT: U LOVE TO CODE!]
[CODE]:
1.[Fund]: 1a.CharId 1b.TskDec 1c.SynPrf 1d.LibUse 1e.CnAdhr 1f.OOPBas 
2.[Dsgn]: 2a.AlgoId 2b.CdMod 2c.Optim 2d.ErrHndl 2e.Debug 2f.OOPPatt 
3.[Tst]: 3a.CdRev 3b.UntTest 3c.IssueSpt 3d.FuncVer 3e.OOPTest 
4.[QualSec]: 4a.QltyMet 4b.SecMeas 4c.OOPSecur 
5.[QA]: 5a.QA 5b.OOPDoc 6.[BuiDep]: 6a.CI/CD 6b.ABuild 6c.AdvTest 6d.Deploy 6e.OOPBldProc 
7.[ConImpPrac]: 7a.AgileRetr 7b.ContImpr 7c.OOPBestPr 
8.[CodeRevAna]: 8a.PeerRev 8b.CdAnalys 8c-CdsOptim 8d.Docs 8e.OOPCdRev

You are an expert C# developer working on an ASP.NET Service based on .NET Core.


# INSTRUCTION
Consider the following original source code from an ASP.NET service based on .NET Core:
```cs
// TOP-MARKER
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Shop.Data.Enums;
using Shop.Data.Models;

namespace Shop.Data
{
    public interface IOrder
    {
        void CreateOrder(Order order);
        Order GetById(int orderId);
        IEnumerable<Order> GetByUserId(string userId);
        IEnumerable<Order> GetAll();
        IEnumerable<Order> GetUserLatestOrders(int count, string userId);
        IEnumerable<Food> GetUserMostPopularFoods(string id);
        IEnumerable<Order> GetFilteredOrders(
            string userId = null,
            OrderBy orderBy = OrderBy.None,
            int offset = 0,
            int limit = 10,
            decimal? minimalPrice = null,
            decimal? maximalPrice = null,
            DateTime? minDate = null,
            DateTime? maxDate = null,
            string zipCode = null
            );
    }
}
```

The static code analysis found this issue:
```
Method has 9 parameters, which is greater than the 7 authorized.
```

The issue is reported at these code lines, but it may involve other lines:
```cs
        IEnumerable<Order> GetFilteredOrders(
            string userId = null,
            OrderBy orderBy = OrderBy.None,
            int offset = 0,
            int limit = 10,
            decimal? minimalPrice = null,
            decimal? maximalPrice = null,
            DateTime? minDate = null,
            DateTime? maxDate = null,
            string zipCode = null
            );
```

- Issue category: FOCUSED (ADAPTABLE)
- Issue severity: MAJOR


Please ALWAYS honor ALL of these general rules while resolving the issue:
- Work ONLY from the context provided, refuse to make any guesses.
- Do NOT write any code if you do not have enough information in this context
  to resolve the issue or you do not know how to fix it.
- Do NOT use any kind of placeholders, always write out the full code.
- Do NOT lose any of the original (intended) functionality, remove only the bug. 
- Do NOT apologize.
- Do NOT refer to your knowledge cut-off date.
- Do NOT explain the code itself, we can read it as well.
- Do NOT include excessive comments.
- Do NOT remove original comments unrelated to the issue or the code modified.
- Do NOT break the code's intended functionality.
- Do NOT introduce any performance or security issues.
- Do NOT change comments or string literals unrelated to your task.
- Do NOT remove code (even if it is commented out or disabled) unless asked explicitly.
- Do UPDATE comments which apply to code you have to change.
- ALWAYS write code which is easily readable by humans.
- If you are asked to remove code, then DO REMOVE it, not just comment it out.
- If you are asked to remove commented out code, then DO REMOVE it. Do NOT uncomment it.


Make sure the understand all the above, then work on resolving the issue by completing these steps:

1. Take a deep breath and think about the problem. Provide a very concise,
   step by step plan for resolving the issue. It will serve only for your 
   reference and not part of the actual output.

2. Stop here and ignore the rest of tasks if and only if you feel that
   some crucial information is missing to properly solve the issue or
   you do not know how to solve it. 

3. Copy the WHOLE original source code with modifications to resolve the issue.
   Your modifications should be concise and limited to the topic of the
   issue. Do NOT modify any code, data or comments unrelated to the issue.
   Do NOT attempt to fix or cleanup anything which is unrelated to the issue.
   Make sure that your changes are compatible with all existing functionality.
   Provide the modified source code in a SINGLE CODE BLOCK without the use of
   any placeholders. Write out the full code, because it will replace the original.

4. Check these failure conditions by reviewing the changes your made to the source code.
   - Are the changes you made fail to fully resolve the issue?
   - Have you missed any related changes humans would expect to be part as your issue resolution? 
   - Have you made any changes, additions or removals to code, data or comments not related to the issue?
   - Has any part of the source code replaced by a placeholder?
   If the answer to all these questions are NO, then approve the code changes
   by saying "APPROVE_CHANGES" and nothing else after the code block.
   If you do not approve the changes, then provide a concise explanation why.    


# PARAMS
```json
{
  "number_of_completions": 16,
  "max_tokens": 3930,
  "temperature": 0.3
}
```

# COMPLETION

The issue is about the method `GetFilteredOrders` having too many parameters. This is generally considered a bad practice as it makes the method harder to use and maintain. It also makes it more difficult to understand what the method does.

Here is the refactored code:

```cs
// TOP-MARKER
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Shop.Data.Enums;
using Shop.Data.Models;

namespace Shop.Data
{
    public interface IOrder
    {
        void CreateOrder(Order order);
        Order GetById(int orderId);
        IEnumerable<Order> GetByUserId(string userId);
        IEnumerable<Order> GetAll();
        IEnumerable<Order> GetUserLatestOrders(int count, string userId);
        IEnumerable<Food> GetUserMostPopularFoods(string id);
        IEnumerable<Order> GetFilteredOrders(OrderFilter filter);
    }

    public class OrderFilter
    {
        public string UserId { get; set; }
        public OrderBy OrderBy { get; set; }
        public int Offset { get; set; }
        public int Limit { get; set; }
        public decimal? MinimalPrice { get; set; }
        public decimal? MaximalPrice { get; set; }
        public DateTime? MinDate { get; set; }
        public DateTime? MaxDate { get; set; }
        public string ZipCode { get; set; }
    }
}
```

In this refactored code, I've created a new class `OrderFilter` that holds all the parameters of the `GetFilteredOrders` method. This way, the method now only has one parameter, which is an instance of `OrderFilter`. This makes the method easier to use and understand.

APPROVE_CHANGES


# REPLACEMENT
```cs
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Shop.Data.Enums;
using Shop.Data.Models;

namespace Shop.Data
{
    public interface IOrder
    {
        void CreateOrder(Order order);
        Order GetById(int orderId);
        IEnumerable<Order> GetByUserId(string userId);
        IEnumerable<Order> GetAll();
        IEnumerable<Order> GetUserLatestOrders(int count, string userId);
        IEnumerable<Food> GetUserMostPopularFoods(string id);
        IEnumerable<Order> GetFilteredOrders(OrderFilter filter);
    }

    public class OrderFilter
    {
        public string UserId { get; set; }
        public OrderBy OrderBy { get; set; }
        public int Offset { get; set; }
        public int Limit { get; set; }
        public decimal? MinimalPrice { get; set; }
        public decimal? MaximalPrice { get; set; }
        public DateTime? MinDate { get; set; }
        public DateTime? MaxDate { get; set; }
        public string ZipCode { get; set; }
    }
}

```

ERROR: Failed to build solution: ['dotnet', 'build']
Exit code: 1
Output:
MSBuild version 17.8.3+195e7f5a3 for .NET
  Determining projects to restore...
C:\Program Files\dotnet\sdk\8.0.100\Sdks\Microsoft.NET.Sdk\targets\Microsoft.NET.EolTargetFrameworks.targets(32,5): warning NETSDK1138: The target framework 'netcoreapp2.2' is out of support and will not receive security updates in the future. Please refer to https://aka.ms/dotnet-core-support for more information about the support policy. [C:\Dev\AI\Coding\example-shop\Shop.Web\Shop.Web.csproj]
C:\Dev\AI\Coding\example-shop\Shop.Web\Shop.Web.csproj : warning NU1504: Duplicate 'PackageReference' items found. Remove the duplicate items or use the Update functionality to ensure a consistent restore behavior. The duplicate 'PackageReference' items are: Microsoft.VisualStudio.Web.CodeGeneration.Design 2.2.0, Microsoft.VisualStudio.Web.CodeGeneration.Design 2.2.4.
C:\Dev\AI\Coding\example-shop\Shop.Web\Shop.Web.csproj : warning NU1603: Microsoft.Extensions.Primitives 2.0.0-preview1-final depends on System.Runtime.CompilerServices.Unsafe (>= 4.4.0-preview1-25219-04) but System.Runtime.CompilerServices.Unsafe 4.4.0-preview1-25219-04 was not found. An approximate best match of System.Runtime.CompilerServices.Unsafe 4.4.0-preview1-25305-02 was resolved. [C:\Dev\AI\Coding\example-shop\Shop.sln]
C:\Dev\AI\Coding\example-shop\Shop.Service\Shop.Service.csproj : warning NU1903: Package 'Microsoft.NETCore.App' 2.2.0 has a known high severity vulnerability, https://github.com/advisories/GHSA-2xjx-v99w-gqf3 [C:\Dev\AI\Coding\example-shop\Shop.sln]
C:\Dev\AI\Coding\example-shop\Shop.Data\Shop.Data.csproj : warning NU1903: Package 'Microsoft.AspNetCore.All' 2.2.0 has a known high severity vulnerability, https://github.com/advisories/GHSA-6px8-22w5-w334 [C:\Dev\AI\Coding\example-shop\Shop.sln]
C:\Dev\AI\Coding\example-shop\Shop.Data\Shop.Data.csproj : warning NU1903: Package 'Microsoft.AspNetCore.All' 2.2.0 has a known high severity vulnerability, https://github.com/advisories/GHSA-mv2r-q4g5-j8q5 [C:\Dev\AI\Coding\example-shop\Shop.sln]
C:\Dev\AI\Coding\example-shop\Shop.Web\Shop.Web.csproj : warning NU1903: Package 'Microsoft.AspNetCore.All' 2.2.0 has a known high severity vulnerability, https://github.com/advisories/GHSA-6px8-22w5-w334 [C:\Dev\AI\Coding\example-shop\Shop.sln]
C:\Dev\AI\Coding\example-shop\Shop.Service\Shop.Service.csproj : warning NU1903: Package 'Microsoft.NETCore.App' 2.2.0 has a known high severity vulnerability, https://github.com/advisories/GHSA-6px8-22w5-w334 [C:\Dev\AI\Coding\example-shop\Shop.sln]
C:\Dev\AI\Coding\example-shop\Shop.Data\Shop.Data.csproj : warning NU1902: Package 'Microsoft.AspNetCore.All' 2.2.0 has a known moderate severity vulnerability, https://github.com/advisories/GHSA-prrf-397v-83xh [C:\Dev\AI\Coding\example-shop\Shop.sln]
C:\Dev\AI\Coding\example-shop\Shop.Web\Shop.Web.csproj : warning NU1903: Package 'Microsoft.AspNetCore.All' 2.2.0 has a known high severity vulnerability, https://github.com/advisories/GHSA-mv2r-q4g5-j8q5 [C:\Dev\AI\Coding\example-shop\Shop.sln]
C:\Dev\AI\Coding\example-shop\Shop.Service\Shop.Service.csproj : warning NU1902: Package 'Microsoft.NETCore.App' 2.2.0 has a known moderate severity vulnerability, https://github.com/advisories/GHSA-x5qj-9vmx-7g6g [C:\Dev\AI\Coding\example-shop\Shop.sln]
C:\Dev\AI\Coding\example-shop\Shop.Data\Shop.Data.csproj : warning NU1903: Package 'Microsoft.NETCore.App' 2.2.0 has a known high severity vulnerability, https://github.com/advisories/GHSA-2xjx-v99w-gqf3 [C:\Dev\AI\Coding\example-shop\Shop.sln]
C:\Dev\AI\Coding\example-shop\Shop.Web\Shop.Web.csproj : warning NU1902: Package 'Microsoft.AspNetCore.All' 2.2.0 has a known moderate severity vulnerability, https://github.com/advisories/GHSA-prrf-397v-83xh [C:\Dev\AI\Coding\example-shop\Shop.sln]
C:\Dev\AI\Coding\example-shop\Shop.Data\Shop.Data.csproj : warning NU1903: Package 'Microsoft.NETCore.App' 2.2.0 has a known high severity vulnerability, https://github.com/advisories/GHSA-6px8-22w5-w334 [C:\Dev\AI\Coding\example-shop\Shop.sln]
C:\Dev\AI\Coding\example-shop\Shop.Web\Shop.Web.csproj : warning NU1903: Package 'Microsoft.NETCore.App' 2.2.0 has a known high severity vulnerability, https://github.com/advisories/GHSA-2xjx-v99w-gqf3 [C:\Dev\AI\Coding\example-shop\Shop.sln]
C:\Dev\AI\Coding\example-shop\Shop.Data\Shop.Data.csproj : warning NU1902: Package 'Microsoft.NETCore.App' 2.2.0 has a known moderate severity vulnerability, https://github.com/advisories/GHSA-x5qj-9vmx-7g6g [C:\Dev\AI\Coding\example-shop\Shop.sln]
C:\Dev\AI\Coding\example-shop\Shop.Web\Shop.Web.csproj : warning NU1903: Package 'Microsoft.NETCore.App' 2.2.0 has a known high severity vulnerability, https://github.com/advisories/GHSA-6px8-22w5-w334 [C:\Dev\AI\Coding\example-shop\Shop.sln]
C:\Dev\AI\Coding\example-shop\Shop.Web\Shop.Web.csproj : warning NU1902: Package 'Microsoft.NETCore.App' 2.2.0 has a known moderate severity vulnerability, https://github.com/advisories/GHSA-x5qj-9vmx-7g6g [C:\Dev\AI\Coding\example-shop\Shop.sln]
  All projects are up-to-date for restore.
C:\Program Files\dotnet\sdk\8.0.100\Sdks\Microsoft.NET.Sdk\targets\Microsoft.NET.Sdk.DefaultItems.targets(65,5): warning NETSDK1071: A PackageReference to 'Microsoft.AspNetCore.All' specified a Version of `2.2.0`. Specifying the version of this package is not recommended. For more information, see https://aka.ms/sdkimplicitrefs [C:\Dev\AI\Coding\example-shop\Shop.Data\Shop.Data.csproj]
C:\Dev\AI\Coding\example-shop\Shop.Service\Shop.Service.csproj : warning NU1903: Package 'Microsoft.NETCore.App' 2.2.0 has a known high severity vulnerability, https://github.com/advisories/GHSA-2xjx-v99w-gqf3
C:\Dev\AI\Coding\example-shop\Shop.Service\Shop.Service.csproj : warning NU1903: Package 'Microsoft.NETCore.App' 2.2.0 has a known high severity vulnerability, https://github.com/advisories/GHSA-6px8-22w5-w334
C:\Dev\AI\Coding\example-shop\Shop.Service\Shop.Service.csproj : warning NU1902: Package 'Microsoft.NETCore.App' 2.2.0 has a known moderate severity vulnerability, https://github.com/advisories/GHSA-x5qj-9vmx-7g6g
C:\Dev\AI\Coding\example-shop\Shop.Data\Shop.Data.csproj : warning NU1903: Package 'Microsoft.AspNetCore.All' 2.2.0 has a known high severity vulnerability, https://github.com/advisories/GHSA-6px8-22w5-w334
C:\Dev\AI\Coding\example-shop\Shop.Data\Shop.Data.csproj : warning NU1903: Package 'Microsoft.AspNetCore.All' 2.2.0 has a known high severity vulnerability, https://github.com/advisories/GHSA-mv2r-q4g5-j8q5
C:\Dev\AI\Coding\example-shop\Shop.Data\Shop.Data.csproj : warning NU1902: Package 'Microsoft.AspNetCore.All' 2.2.0 has a known moderate severity vulnerability, https://github.com/advisories/GHSA-prrf-397v-83xh
C:\Dev\AI\Coding\example-shop\Shop.Data\Shop.Data.csproj : warning NU1903: Package 'Microsoft.NETCore.App' 2.2.0 has a known high severity vulnerability, https://github.com/advisories/GHSA-2xjx-v99w-gqf3
C:\Dev\AI\Coding\example-shop\Shop.Data\Shop.Data.csproj : warning NU1903: Package 'Microsoft.NETCore.App' 2.2.0 has a known high severity vulnerability, https://github.com/advisories/GHSA-6px8-22w5-w334
C:\Dev\AI\Coding\example-shop\Shop.Data\Shop.Data.csproj : warning NU1902: Package 'Microsoft.NETCore.App' 2.2.0 has a known moderate severity vulnerability, https://github.com/advisories/GHSA-x5qj-9vmx-7g6g
C:\Program Files\dotnet\sdk\8.0.100\Sdks\Microsoft.NET.Sdk\targets\Microsoft.NET.EolTargetFrameworks.targets(32,5): warning NETSDK1138: The target framework 'netcoreapp2.2' is out of support and will not receive security updates in the future. Please refer to https://aka.ms/dotnet-core-support for more information about the support policy. [C:\Dev\AI\Coding\example-shop\Shop.Web\Shop.Web.csproj]
C:\Dev\AI\Coding\example-shop\Shop.Web\Shop.Web.csproj : warning NU1504: Duplicate 'PackageReference' items found. Remove the duplicate items or use the Update functionality to ensure a consistent restore behavior. The duplicate 'PackageReference' items are: Microsoft.VisualStudio.Web.CodeGeneration.Design 2.2.0, Microsoft.VisualStudio.Web.CodeGeneration.Design 2.2.4.
C:\Program Files\dotnet\sdk\8.0.100\Sdks\Microsoft.NET.Sdk\targets\Microsoft.NET.Sdk.DefaultItems.targets(65,5): warning NETSDK1071: A PackageReference to 'Microsoft.AspNetCore.All' specified a Version of `2.2.0`. Specifying the version of this package is not recommended. For more information, see https://aka.ms/sdkimplicitrefs [C:\Dev\AI\Coding\example-shop\Shop.Web\Shop.Web.csproj]
  Sonar: (Shop.Data.csproj) The analysis targets file not found: C:\Dev\AI\Coding\example-shop\.sonarqube\bin\targets\SonarQube.Integration.targets
C:\Dev\AI\Coding\example-shop\Shop.Web\Shop.Web.csproj : warning NU1603: Microsoft.Extensions.Primitives 2.0.0-preview1-final depends on System.Runtime.CompilerServices.Unsafe (>= 4.4.0-preview1-25219-04) but System.Runtime.CompilerServices.Unsafe 4.4.0-preview1-25219-04 was not found. An approximate best match of System.Runtime.CompilerServices.Unsafe 4.4.0-preview1-25305-02 was resolved.
C:\Dev\AI\Coding\example-shop\Shop.Web\Shop.Web.csproj : warning NU1903: Package 'Microsoft.AspNetCore.All' 2.2.0 has a known high severity vulnerability, https://github.com/advisories/GHSA-6px8-22w5-w334
C:\Dev\AI\Coding\example-shop\Shop.Web\Shop.Web.csproj : warning NU1903: Package 'Microsoft.AspNetCore.All' 2.2.0 has a known high severity vulnerability, https://github.com/advisories/GHSA-mv2r-q4g5-j8q5
C:\Dev\AI\Coding\example-shop\Shop.Web\Shop.Web.csproj : warning NU1902: Package 'Microsoft.AspNetCore.All' 2.2.0 has a known moderate severity vulnerability, https://github.com/advisories/GHSA-prrf-397v-83xh
C:\Dev\AI\Coding\example-shop\Shop.Web\Shop.Web.csproj : warning NU1903: Package 'Microsoft.NETCore.App' 2.2.0 has a known high severity vulnerability, https://github.com/advisories/GHSA-2xjx-v99w-gqf3
C:\Dev\AI\Coding\example-shop\Shop.Web\Shop.Web.csproj : warning NU1903: Package 'Microsoft.NETCore.App' 2.2.0 has a known high severity vulnerability, https://github.com/advisories/GHSA-6px8-22w5-w334
C:\Dev\AI\Coding\example-shop\Shop.Web\Shop.Web.csproj : warning NU1902: Package 'Microsoft.NETCore.App' 2.2.0 has a known moderate severity vulnerability, https://github.com/advisories/GHSA-x5qj-9vmx-7g6g
  Shop.Data -> C:\Dev\AI\Coding\example-shop\Shop.Data\bin\Debug\netcoreapp2.2\Shop.Data.dll
  Sonar: (Shop.Service.csproj) The analysis targets file not found: C:\Dev\AI\Coding\example-shop\.sonarqube\bin\targets\SonarQube.Integration.targets
C:\Dev\AI\Coding\example-shop\Shop.Service\OrderService.cs(12,33): error CS0535: 'OrderService' does not implement interface member 'IOrder.GetFilteredOrders(OrderFilter)' [C:\Dev\AI\Coding\example-shop\Shop.Service\Shop.Service.csproj]

Build FAILED.

C:\Program Files\dotnet\sdk\8.0.100\Sdks\Microsoft.NET.Sdk\targets\Microsoft.NET.EolTargetFrameworks.targets(32,5): warning NETSDK1138: The target framework 'netcoreapp2.2' is out of support and will not receive security updates in the future. Please refer to https://aka.ms/dotnet-core-support for more information about the support policy. [C:\Dev\AI\Coding\example-shop\Shop.Web\Shop.Web.csproj]
C:\Dev\AI\Coding\example-shop\Shop.Web\Shop.Web.csproj : warning NU1504: Duplicate 'PackageReference' items found. Remove the duplicate items or use the Update functionality to ensure a consistent restore behavior. The duplicate 'PackageReference' items are: Microsoft.VisualStudio.Web.CodeGeneration.Design 2.2.0, Microsoft.VisualStudio.Web.CodeGeneration.Design 2.2.4.
C:\Dev\AI\Coding\example-shop\Shop.Web\Shop.Web.csproj : warning NU1603: Microsoft.Extensions.Primitives 2.0.0-preview1-final depends on System.Runtime.CompilerServices.Unsafe (>= 4.4.0-preview1-25219-04) but System.Runtime.CompilerServices.Unsafe 4.4.0-preview1-25219-04 was not found. An approximate best match of System.Runtime.CompilerServices.Unsafe 4.4.0-preview1-25305-02 was resolved. [C:\Dev\AI\Coding\example-shop\Shop.sln]
C:\Dev\AI\Coding\example-shop\Shop.Service\Shop.Service.csproj : warning NU1903: Package 'Microsoft.NETCore.App' 2.2.0 has a known high severity vulnerability, https://github.com/advisories/GHSA-2xjx-v99w-gqf3 [C:\Dev\AI\Coding\example-shop\Shop.sln]
C:\Dev\AI\Coding\example-shop\Shop.Data\Shop.Data.csproj : warning NU1903: Package 'Microsoft.AspNetCore.All' 2.2.0 has a known high severity vulnerability, https://github.com/advisories/GHSA-6px8-22w5-w334 [C:\Dev\AI\Coding\example-shop\Shop.sln]
C:\Dev\AI\Coding\example-shop\Shop.Data\Shop.Data.csproj : warning NU1903: Package 'Microsoft.AspNetCore.All' 2.2.0 has a known high severity vulnerability, https://github.com/advisories/GHSA-mv2r-q4g5-j8q5 [C:\Dev\AI\Coding\example-shop\Shop.sln]
C:\Dev\AI\Coding\example-shop\Shop.Web\Shop.Web.csproj : warning NU1903: Package 'Microsoft.AspNetCore.All' 2.2.0 has a known high severity vulnerability, https://github.com/advisories/GHSA-6px8-22w5-w334 [C:\Dev\AI\Coding\example-shop\Shop.sln]
C:\Dev\AI\Coding\example-shop\Shop.Service\Shop.Service.csproj : warning NU1903: Package 'Microsoft.NETCore.App' 2.2.0 has a known high severity vulnerability, https://github.com/advisories/GHSA-6px8-22w5-w334 [C:\Dev\AI\Coding\example-shop\Shop.sln]
C:\Dev\AI\Coding\example-shop\Shop.Data\Shop.Data.csproj : warning NU1902: Package 'Microsoft.AspNetCore.All' 2.2.0 has a known moderate severity vulnerability, https://github.com/advisories/GHSA-prrf-397v-83xh [C:\Dev\AI\Coding\example-shop\Shop.sln]
C:\Dev\AI\Coding\example-shop\Shop.Web\Shop.Web.csproj : warning NU1903: Package 'Microsoft.AspNetCore.All' 2.2.0 has a known high severity vulnerability, https://github.com/advisories/GHSA-mv2r-q4g5-j8q5 [C:\Dev\AI\Coding\example-shop\Shop.sln]
C:\Dev\AI\Coding\example-shop\Shop.Service\Shop.Service.csproj : warning NU1902: Package 'Microsoft.NETCore.App' 2.2.0 has a known moderate severity vulnerability, https://github.com/advisories/GHSA-x5qj-9vmx-7g6g [C:\Dev\AI\Coding\example-shop\Shop.sln]
C:\Dev\AI\Coding\example-shop\Shop.Data\Shop.Data.csproj : warning NU1903: Package 'Microsoft.NETCore.App' 2.2.0 has a known high severity vulnerability, https://github.com/advisories/GHSA-2xjx-v99w-gqf3 [C:\Dev\AI\Coding\example-shop\Shop.sln]
C:\Dev\AI\Coding\example-shop\Shop.Web\Shop.Web.csproj : warning NU1902: Package 'Microsoft.AspNetCore.All' 2.2.0 has a known moderate severity vulnerability, https://github.com/advisories/GHSA-prrf-397v-83xh [C:\Dev\AI\Coding\example-shop\Shop.sln]
C:\Dev\AI\Coding\example-shop\Shop.Data\Shop.Data.csproj : warning NU1903: Package 'Microsoft.NETCore.App' 2.2.0 has a known high severity vulnerability, https://github.com/advisories/GHSA-6px8-22w5-w334 [C:\Dev\AI\Coding\example-shop\Shop.sln]
C:\Dev\AI\Coding\example-shop\Shop.Web\Shop.Web.csproj : warning NU1903: Package 'Microsoft.NETCore.App' 2.2.0 has a known high severity vulnerability, https://github.com/advisories/GHSA-2xjx-v99w-gqf3 [C:\Dev\AI\Coding\example-shop\Shop.sln]
C:\Dev\AI\Coding\example-shop\Shop.Data\Shop.Data.csproj : warning NU1902: Package 'Microsoft.NETCore.App' 2.2.0 has a known moderate severity vulnerability, https://github.com/advisories/GHSA-x5qj-9vmx-7g6g [C:\Dev\AI\Coding\example-shop\Shop.sln]
C:\Dev\AI\Coding\example-shop\Shop.Web\Shop.Web.csproj : warning NU1903: Package 'Microsoft.NETCore.App' 2.2.0 has a known high severity vulnerability, https://github.com/advisories/GHSA-6px8-22w5-w334 [C:\Dev\AI\Coding\example-shop\Shop.sln]
C:\Dev\AI\Coding\example-shop\Shop.Web\Shop.Web.csproj : warning NU1902: Package 'Microsoft.NETCore.App' 2.2.0 has a known moderate severity vulnerability, https://github.com/advisories/GHSA-x5qj-9vmx-7g6g [C:\Dev\AI\Coding\example-shop\Shop.sln]
C:\Program Files\dotnet\sdk\8.0.100\Sdks\Microsoft.NET.Sdk\targets\Microsoft.NET.Sdk.DefaultItems.targets(65,5): warning NETSDK1071: A PackageReference to 'Microsoft.AspNetCore.All' specified a Version of `2.2.0`. Specifying the version of this package is not recommended. For more information, see https://aka.ms/sdkimplicitrefs [C:\Dev\AI\Coding\example-shop\Shop.Data\Shop.Data.csproj]
C:\Dev\AI\Coding\example-shop\Shop.Service\Shop.Service.csproj : warning NU1903: Package 'Microsoft.NETCore.App' 2.2.0 has a known high severity vulnerability, https://github.com/advisories/GHSA-2xjx-v99w-gqf3
C:\Dev\AI\Coding\example-shop\Shop.Service\Shop.Service.csproj : warning NU1903: Package 'Microsoft.NETCore.App' 2.2.0 has a known high severity vulnerability, https://github.com/advisories/GHSA-6px8-22w5-w334
C:\Dev\AI\Coding\example-shop\Shop.Service\Shop.Service.csproj : warning NU1902: Package 'Microsoft.NETCore.App' 2.2.0 has a known moderate severity vulnerability, https://github.com/advisories/GHSA-x5qj-9vmx-7g6g
C:\Dev\AI\Coding\example-shop\Shop.Data\Shop.Data.csproj : warning NU1903: Package 'Microsoft.AspNetCore.All' 2.2.0 has a known high severity vulnerability, https://github.com/advisories/GHSA-6px8-22w5-w334
C:\Dev\AI\Coding\example-shop\Shop.Data\Shop.Data.csproj : warning NU1903: Package 'Microsoft.AspNetCore.All' 2.2.0 has a known high severity vulnerability, https://github.com/advisories/GHSA-mv2r-q4g5-j8q5
C:\Dev\AI\Coding\example-shop\Shop.Data\Shop.Data.csproj : warning NU1902: Package 'Microsoft.AspNetCore.All' 2.2.0 has a known moderate severity vulnerability, https://github.com/advisories/GHSA-prrf-397v-83xh
C:\Dev\AI\Coding\example-shop\Shop.Data\Shop.Data.csproj : warning NU1903: Package 'Microsoft.NETCore.App' 2.2.0 has a known high severity vulnerability, https://github.com/advisories/GHSA-2xjx-v99w-gqf3
C:\Dev\AI\Coding\example-shop\Shop.Data\Shop.Data.csproj : warning NU1903: Package 'Microsoft.NETCore.App' 2.2.0 has a known high severity vulnerability, https://github.com/advisories/GHSA-6px8-22w5-w334
C:\Dev\AI\Coding\example-shop\Shop.Data\Shop.Data.csproj : warning NU1902: Package 'Microsoft.NETCore.App' 2.2.0 has a known moderate severity vulnerability, https://github.com/advisories/GHSA-x5qj-9vmx-7g6g
C:\Program Files\dotnet\sdk\8.0.100\Sdks\Microsoft.NET.Sdk\targets\Microsoft.NET.EolTargetFrameworks.targets(32,5): warning NETSDK1138: The target framework 'netcoreapp2.2' is out of support and will not receive security updates in the future. Please refer to https://aka.ms/dotnet-core-support for more information about the support policy. [C:\Dev\AI\Coding\example-shop\Shop.Web\Shop.Web.csproj]
C:\Dev\AI\Coding\example-shop\Shop.Web\Shop.Web.csproj : warning NU1504: Duplicate 'PackageReference' items found. Remove the duplicate items or use the Update functionality to ensure a consistent restore behavior. The duplicate 'PackageReference' items are: Microsoft.VisualStudio.Web.CodeGeneration.Design 2.2.0, Microsoft.VisualStudio.Web.CodeGeneration.Design 2.2.4.
C:\Program Files\dotnet\sdk\8.0.100\Sdks\Microsoft.NET.Sdk\targets\Microsoft.NET.Sdk.DefaultItems.targets(65,5): warning NETSDK1071: A PackageReference to 'Microsoft.AspNetCore.All' specified a Version of `2.2.0`. Specifying the version of this package is not recommended. For more information, see https://aka.ms/sdkimplicitrefs [C:\Dev\AI\Coding\example-shop\Shop.Web\Shop.Web.csproj]
C:\Dev\AI\Coding\example-shop\Shop.Web\Shop.Web.csproj : warning NU1603: Microsoft.Extensions.Primitives 2.0.0-preview1-final depends on System.Runtime.CompilerServices.Unsafe (>= 4.4.0-preview1-25219-04) but System.Runtime.CompilerServices.Unsafe 4.4.0-preview1-25219-04 was not found. An approximate best match of System.Runtime.CompilerServices.Unsafe 4.4.0-preview1-25305-02 was resolved.
C:\Dev\AI\Coding\example-shop\Shop.Web\Shop.Web.csproj : warning NU1903: Package 'Microsoft.AspNetCore.All' 2.2.0 has a known high severity vulnerability, https://github.com/advisories/GHSA-6px8-22w5-w334
C:\Dev\AI\Coding\example-shop\Shop.Web\Shop.Web.csproj : warning NU1903: Package 'Microsoft.AspNetCore.All' 2.2.0 has a known high severity vulnerability, https://github.com/advisories/GHSA-mv2r-q4g5-j8q5
C:\Dev\AI\Coding\example-shop\Shop.Web\Shop.Web.csproj : warning NU1902: Package 'Microsoft.AspNetCore.All' 2.2.0 has a known moderate severity vulnerability, https://github.com/advisories/GHSA-prrf-397v-83xh
C:\Dev\AI\Coding\example-shop\Shop.Web\Shop.Web.csproj : warning NU1903: Package 'Microsoft.NETCore.App' 2.2.0 has a known high severity vulnerability, https://github.com/advisories/GHSA-2xjx-v99w-gqf3
C:\Dev\AI\Coding\example-shop\Shop.Web\Shop.Web.csproj : warning NU1903: Package 'Microsoft.NETCore.App' 2.2.0 has a known high severity vulnerability, https://github.com/advisories/GHSA-6px8-22w5-w334
C:\Dev\AI\Coding\example-shop\Shop.Web\Shop.Web.csproj : warning NU1902: Package 'Microsoft.NETCore.App' 2.2.0 has a known moderate severity vulnerability, https://github.com/advisories/GHSA-x5qj-9vmx-7g6g
C:\Dev\AI\Coding\example-shop\Shop.Service\OrderService.cs(12,33): error CS0535: 'OrderService' does not implement interface member 'IOrder.GetFilteredOrders(OrderFilter)' [C:\Dev\AI\Coding\example-shop\Shop.Service\Shop.Service.csproj]
    38 Warning(s)
    1 Error(s)

Time Elapsed 00:00:00.72

