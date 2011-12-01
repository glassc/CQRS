$framework = '4.0'

properties {
	$base_dir  = resolve-path .
	$build_dir = "$base_dir\build"
	$src_dir = "$base_dir\src"
	$package_dir = "$src_dir\packages"
	$solution = "$src_dir\CQRS.sln"
	$release_dir = "$base_dir\release"
	$tools_dir = "$base_dir\Tools"
	
	
}


task Help {

	""
	"Task List"
	"----------------------------------------------------------"
	"Compile  - Compile the framework"
	"Test     - Run the tests"
	"Package  - Create a NuGet package in the release directory"
	
}


task Clean {
	
	remove-item -force -recurse $build_dir -ErrorAction SilentlyContinue
}

task Initialize -depends Clean {
	
    new-item $build_dir -itemType directory
}

task Compile -depends Initialize {
    msbuild /t:rebuild $solution
}

task Test -depends Compile {
	exec { &"$package_dir\NUnit.2.5.10.11092\tools\nunit-console.exe" "$build_dir\UnitTests.dll" }
}

task Package -depends Compile, CreatePackageStructure, CopyPackageFiles {
	if( (Test-Path $release_dir) -eq $false )
	{
		new-item $release_dir -itemType directory
	}
	&"$tools_dir\NuGet.exe" pack "$build_dir\package\CQRS.nuspec" -OutputDirectory "$release_dir"	
}

task CreatePackageStructure {
	new-item "$build_dir\package" -itemType directory
	new-item "$build_dir\package\lib" -itemType directory
	new-item "$build_dir\package\lib\net40" -itemType directory
	
}

task CopyPackageFiles {
	cp "CQRS.nuspec" "$build_dir\package"
	cp "$build_dir\CQRS.dll" "$build_dir\package\lib\net40"
}