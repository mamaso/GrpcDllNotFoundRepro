# Grpc & vstest 'dll not found' repro

I'm unable to use Grpc.Core out-of-box in test projects running with vstest.

When I attempt to run a test that spins up a grpc server, I get the following error:

`Message: System.IO.FileNotFoundException : Error loading native library. Not found in any of the possible locations: <repo>\TestProj\bin\Debug\netcoreapp2.0\grpc_csharp_ext.x64.dll,<repo>\TestProj\bin\Debug\netcoreapp2.0\runtimes/win/native\grpc_csharp_ext.x64.dll,<repo>\TestProj\bin\Debug\netcoreapp2.0\../..\runtimes/win/native\grpc_csharp_ext.x64.dll`

I can manually copy the `runtimes` folder from the nuget package to the test output directory, but that's not a good long-term solution.

In contrast to the test project, when starting the grpc server from a console app outside of the vstest context the dll is found without errors.

The console app and the test project have the identical generated `runtimeconfigs`, which is how I think these dlls are normally found:
```
// runtimeconfig.deps.json
{
  "runtimeOptions": {
    "additionalProbingPaths": [
      "C:\\Users\\mamaso\\.dotnet\\store\\|arch|\\|tfm|",
      "C:\\Users\\mamaso\\.nuget\\packages"
    ]
  }
}

// runtimeconfig.json
{
  "runtimeOptions": {
    "tfm": "netcoreapp2.0",
    "framework": {
      "name": "Microsoft.NETCore.App",
      "version": "2.0.0-preview2-25407-01"
    }
  }
}
```
