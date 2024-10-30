#Configurar Github Credentials Windows Environment
..\.github\ConfigurarGithubCredentialsWindows.ps1

#Criar o arquivo e atribuir .\develop\docker-compose\.env
Add-Content -Path ..\..\develop\docker-compose\.env -Value "USERNAME_GITHUB=$env:USERNAME_GITHUB"
Add-Content -Path ..\..\develop\docker-compose\.env -Value "PERSONAL_ACCESS_TOKEN_GITHUB=$env:PERSONAL_ACCESS_TOKEN_GITHUB"

#Criar Repositorio do Github
$terraformTool = "./terraform.exe"
$terraformToolExiste = [System.IO.File]::Exists($terraformTool)
$terraformZip = "./terraform.zip"
if($terraformToolExiste){
	Invoke-WebRequest -Uri "https://releases.hashicorp.com/terraform/1.9.8/terraform_1.9.8_windows_386.zip" -OutFile $terraformZip
	Expand-Archive -LiteralPath $terraformZip -DestinationPath $terraformPath
	Remove-Item -Path $terraformZip -Force:$true -Confirm:$false -Recurse:$true
}

$solutionProject = $(Get-ChildItem -Path ./ -Filter "*.sln").Name
$solutionProjectName = [io.path]::GetFileNameWithoutExtension($solutionProject)
$projectName = "${solutionProjectName}.api"
Write-Host $projectName

../../terraform/terraform.exe init

../../terraform/terraform.exe plan -var 'github_token=$env:PERSONAL_ACCESS_TOKEN_GITHUB' -var 'project_name=$projectName'

../../terraform/terraform.exe apply -auto-approve -var 'github_token=$env:PERSONAL_ACCESS_TOKEN_GITHUB' -var 'project_name=$projectName'