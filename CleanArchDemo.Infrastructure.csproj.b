<Project Sdk="Microsoft.NET.Sdk">

  <ItemGroup>
    <ProjectReference Include="..\CleanArchDemo.Application\CleanArchDemo.Application.csproj" />
    <ProjectReference Include="..\CleanArchDemo.Domain\CleanArchDemo.Domain.csproj" />
  </ItemGroup>

  <ItemGroup>
    <PackageReference Include="Microsoft.Build.Framework" Version="18.0.2" />
    <PackageReference Include="Microsoft.CodeAnalysis.Analyzers" Version="3.12.0-beta1.25218.8">
      <PrivateAssets>all</PrivateAssets>
      <IncludeAssets>runtime; build; native; contentfiles; analyzers; buildtransitive</IncludeAssets>
    </PackageReference>
    <PackageReference Include="Microsoft.CodeAnalysis.Common" Version="5.0.0" />
    <PackageReference Include="Microsoft.CodeAnalysis.CSharp" Version="5.0.0" />
    <PackageReference Include="Microsoft.CodeAnalysis.CSharp.Workspaces" Version="5.0.0" />
    <PackageReference Include="Microsoft.CodeAnalysis.Workspaces.Common" Version="5.0.0" />
    <PackageReference Include="Microsoft.EntityFrameworkCore" Version="10.0.2" />
    <PackageReference Include="Microsoft.EntityFrameworkCore.Relational" Version="10.0.2" />
    <PackageReference Include="Microsoft.Extensions.Caching.Abstractions" Version="10.0.2" />
    <PackageReference Include="Microsoft.Extensions.Caching.Memory" Version="10.0.2" />
    <PackageReference Include="Microsoft.Extensions.Configuration.Abstractions" Version="10.0.2" />
    <PackageReference Include="Microsoft.Extensions.DependencyInjection" Version="10.0.2" />
    <PackageReference Include="Microsoft.Extensions.DependencyInjection.Abstractions" Version="10.0.2" />
    <PackageReference Include="Microsoft.Extensions.DependencyModel" Version="10.0.2" />
    <PackageReference Include="Microsoft.Extensions.Logging" Version="10.0.2" />
    <PackageReference Include="Microsoft.Extensions.Logging.Abstractions" Version="10.0.2" />
    <PackageReference Include="Microsoft.Extensions.Options" Version="10.0.2" />
    <PackageReference Include="Microsoft.Extensions.Primitives" Version="10.0.2" />
    <PackageReference Include="Microsoft.VisualStudio.SolutionPersistence" Version="1.0.52" />
    <PackageReference Include="Npgsql.EntityFrameworkCore.PostgreSQL" Version="10.0.0" />
    <PackageReference Include="System.Composition" Version="10.0.2" />
    <PackageReference Include="System.Composition.AttributedModel" Version="10.0.2" />
    <PackageReference Include="System.Composition.Convention" Version="10.0.2" />
    <PackageReference Include="System.Composition.Hosting" Version="10.0.2" />
    <PackageReference Include="System.Composition.Runtime" Version="10.0.2" />
    <PackageReference Include="System.Composition.TypedParts" Version="10.0.2" />
  </ItemGroup>

  <ItemGroup>
    <Folder Include="InMemory\" />
  </ItemGroup>

  <PropertyGroup>
    <TargetFramework>net10.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
  </PropertyGroup>

</Project>
