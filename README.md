# UpgradeAssistantPrefer32Bit
Demonstration for Upgrade Asistant removing Prefer32Bit flag when upgrading project file to SDK style

## 1. Legacy project file

Original file marked with platform `AnyCPU` and `Prefer32Bit`:

```xml
<?xml version="1.0" encoding="utf-8"?>
<Project ToolsVersion="15.0" xmlns="http://schemas.microsoft.com/developer/msbuild/2003">
  (...)
  <PropertyGroup>
    <PlatformTarget>AnyCPU</PlatformTarget>
    <Prefer32Bit>true</Prefer32Bit>
    (...)
  </PropertyGroup>
(...)
</Project>
```

When running this application it consumes 1.6 GiB RAM, as it is run as a 32-bit process with access to large memory area.

If compiled as x86 it would consume 0.8 GiB RAM, and as AnyCpu on 64-bit 3.8 GiB.

## 2. Opgraded to SDK style project file

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFramework>net48</TargetFramework>
    (...)
  </PropertyGroup>
  (...)
</Project>
```

The application now consumes 3.8 GiB RAM, as it is now runned compiled as AnyCpu and runned as 64-bit application.

## Conclusion

After using Upgrade Assistant to convert to SDK style project file, the flag for `Prefer32bit` is lost, and the application runs as 64-bit on 64-bit systems. For standalone applications like this example it will not be an issue, but for larger applications depending on other 32-bit DLL-files this becomes an issue.

Expected outcome is that the application still would compile as **AnyCpu Prefer 32-bit**, so it always will be runned as 32-bit application, but with access to the large memory area on 64-bit operating systems.
