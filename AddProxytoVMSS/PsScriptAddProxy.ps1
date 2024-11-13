# Define the proxy address
$proxy = "http://proxy.server.address:port"

# Update the current PowerShell session environment
[System.Environment]::SetEnvironmentVariable("http_proxy", $proxy, [System.EnvironmentVariableTarget]::Process)
[System.Environment]::SetEnvironmentVariable("https_proxy", $proxy, [System.EnvironmentVariableTarget]::Process)

# Append proxy settings to /etc/environment if not already present
$environmentFile = "/etc/environment"
$proxyEntries = @"
http_proxy=\"$proxy\"
https_proxy=\"$proxy\"
"@

if (-not (Get-Content $environmentFile | Select-String -Pattern "http_proxy|https_proxy")) {
    $proxyEntries | Out-File -Append -FilePath $environmentFile -Encoding utf8
    Write-Output "Proxy settings added to /etc/environment."
} else {
    Write-Output "Proxy settings already exist in /etc/environment."
}

# Immediately export the proxy settings for the current shell
Invoke-Expression "export http_proxy=$proxy"
Invoke-Expression "export https_proxy=$proxy"

# Notify the user
Write-Output "Proxy settings applied. No restart required for the current session and new shells."
