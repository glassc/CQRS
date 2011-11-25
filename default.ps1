$framework = '4.0'

properties {
	$base_dir  = resolve-path .
	$build_dir = "$base_dir\build"
	$src_dir = "$base_dir\src"
	$package_dir = "$src_dir\packages"
	$solution = "$src_dir\CQRS.sln"
	$release_dir = "$base_dir\release"
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

task Package -depends Compile {
}
