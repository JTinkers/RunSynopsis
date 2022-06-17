$root = $PSScriptRoot

Set-Location "$($root)\\Apps\\app";
    
Start-Job -Name "Service-Start-Job:$service" -FilePath ".\\start.ps1";

Start-Sleep -Seconds 5