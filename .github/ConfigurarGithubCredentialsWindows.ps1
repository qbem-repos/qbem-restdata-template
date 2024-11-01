#Configurar Github Credentials Windows Environment
try {		
	$env:USERNAME_GITHUB = [Environment]::GetEnvironmentVariable("USERNAME_GITHUB", "User")
	$env:PERSONAL_ACCESS_TOKEN_GITHUB = [Environment]::GetEnvironmentVariable("PERSONAL_ACCESS_TOKEN_GITHUB", "User")	

	if($env:USERNAME_GITHUB -eq $null -and $env:PERSONAL_ACCESS_TOKEN_GITHUB-eq $null) {
		Write-Host "As variáveis USERNAME_GITHUB e PERSONAL_ACCESS_TOKEN_GITHUB não foram atribuídas."
		Add-Type -AssemblyName "Microsoft.VisualBasic"
		$env:USERNAME_GITHUB = [Microsoft.VisualBasic.Interaction]::InputBox("Github", "Entre com o seu do github USERNAME_GITHUB")
		$env:PERSONAL_ACCESS_TOKEN_GITHUB = [Microsoft.VisualBasic.Interaction]::InputBox("Github", "Entre com o seu PAT Token do github PERSONAL_ACCESS_TOKEN_GITHUB")
		[Environment]::SetEnvironmentVariable("USERNAME_GITHUB", $env:USERNAME_GITHUB, "User")
		[Environment]::SetEnvironmentVariable("PERSONAL_ACCESS_TOKEN_GITHUB", $env:PERSONAL_ACCESS_TOKEN_GITHUB, "User")
		Write-Host "$USERNAME_GITHUB e $PERSONAL_ACCESS_TOKEN_GITHUB adicionados na variáveis."
	}
	else {
		Write-Host "As variáveis USERNAME_GITHUB e PERSONAL_ACCESS_TOKEN_GITHUB já foram atribuídas!"
	}	
} catch {        
	$env:USERNAME_GITHUB = $null
	$env:PERSONAL_ACCESS_TOKEN_GITHUB = $null
	[Environment]::SetEnvironmentVariable("USERNAME_GITHUB", $env:USERNAME_GITHUB, "User")
	[Environment]::SetEnvironmentVariable("PERSONAL_ACCESS_TOKEN_GITHUB", $env:PERSONAL_ACCESS_TOKEN_GITHUB, "User")
}