$projects = 
@{
    Server = @('RunSynopsis.Common');
};

$root = $PSScriptRoot

foreach ($project in $projects.keys) 
{
    Set-Location "$($root)\\$project";

    Write-Output "Updating $project"

    foreach ($package in $projects[$project])
    {
        Write-Output "`tBumping $package"

        dotnet add package "$package";
    }

    Set-Location "$($root)";
}