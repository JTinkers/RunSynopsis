$services = @(
    'Auth',
    'Contact',
    'Content',
    'Gateway',
    'Mailing',
    'Storage'
);

$containers = @{}
$containers['Auth'] = 'rsauth-env';
$containers['Contact'] = 'rscontact-env';
$containers['Content'] = 'rscontent-env';
$containers['Gateway'] = 'rsgateway-env';
$containers['Mailing'] = 'rsmailing-env';
$containers['Storage'] = 'rsstorage-env';

foreach ($service in $services) 
{
    Write-Host "Stopping service located in '$service'";

    Set-Location "$PSScriptRoot\\Services\\$service";

    docker-compose -f ".\docker-compose.yml" -f ".\obj\Docker\docker-compose.vs.debug.g.yml" -p $containers[$service] down

    Set-Location "..\\";
}