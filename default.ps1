$framework = '4.0'

properties {
	$base_dir  = resolve-path .
	$build_dir = "$base_dir\build"
	$solution = "$base_dir\src\CQRS.sln"
	
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


