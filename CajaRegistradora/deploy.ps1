# Script to deploy the application
$source = "CajaRegistradora/bin/Release/net6.0-windows/win-x64/publish"
$destination = "C:/CajaRegistradora"

if (Test-Path $destination) {
    Remove-Item -Recurse -Force $destination
}

New-Item -ItemType Directory -Force -Path $destination
Copy-Item -Recurse -Force $source -Destination $destination
