$root = $PSScriptRoot

Set-Location "$($root)\\Services\\Env";

Start-Job -Name "Env-Start-Job" -FilePath ".\\up.ps1";
Wait-Job -Name "Env-Start-Job";

Set-Location "$($root)";