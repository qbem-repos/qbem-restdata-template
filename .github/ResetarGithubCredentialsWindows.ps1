$env:USERNAME_GITHUB = $null
$env:PERSONAL_ACCESS_TOKEN_GITHUB = $null
[Environment]::SetEnvironmentVariable("USERNAME_GITHUB", $env:USERNAME_GITHUB, "User")
[Environment]::SetEnvironmentVariable("PERSONAL_ACCESS_TOKEN_GITHUB", $env:PERSONAL_ACCESS_TOKEN_GITHUB, "User")
