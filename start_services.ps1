$root = $PSScriptRoot

$services = @(
    'Auth',
    'Contact',
    'Content',
    'Storage',
    'Mailing',
    'Gateway'
);

foreach ($service in $services) 
{
    Set-Location "$($root)\\Services\\$service";
    
    Start-Job -Name "Service-Start-Job:$service" -FilePath ".\\start.ps1";

    Start-Sleep -Seconds 5

    Set-Location "$($root)";
}

foreach ($service in $services) 
{
    Wait-Job -Name "Service-Start-Job:$service";
}