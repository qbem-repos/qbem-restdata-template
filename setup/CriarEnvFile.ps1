#Criar o arquivo e atribuir as variáveis .\develop\docker-compose\.env
param(
	[Parameter(Mandatory=$false)]
    [String]$SolutionDir = $pwd	
)

$envFile = '.env'
$envFullFile = "$SolutionDir\develop\docker-compose\$envFile"
$envFileExiste = [System.IO.File]::Exists($envFullFile)
if($envFileExiste){
	Write-Host "Env file ja existente!"
	return;
}

Add-Content -Path "$SolutionDir\develop\docker-compose\$envFile" -Value "USERNAME_GITHUB=$env:USERNAME_GITHUB"
Add-Content -Path "$SolutionDir\develop\docker-compose\$envFile" -Value "PERSONAL_ACCESS_TOKEN_GITHUB=$env:PERSONAL_ACCESS_TOKEN_GITHUB"
Add-Content -Path "$SolutionDir\develop\docker-compose\$envFile" -Value "MONGO_API_ROOT_USERNAME=root"
Add-Content -Path "$SolutionDir\develop\docker-compose\$envFile" -Value "MONGO_API_ROOT_PASSWORD=example"
Add-Content -Path "$SolutionDir\develop\docker-compose\$envFile" -Value "POSTGRES_DB=postgres"
Add-Content -Path "$SolutionDir\develop\docker-compose\$envFile" -Value "POSTGRES_USER=admin"
Add-Content -Path "$SolutionDir\develop\docker-compose\$envFile" -Value "POSTGRES_PASSWORD=Postgres2024!"
Add-Content -Path "$SolutionDir\develop\docker-compose\$envFile" -Value "PGADMIN_DEFAULT_EMAIL=admin@admin.qbem"
Add-Content -Path "$SolutionDir\develop\docker-compose\$envFile" -Value "PGADMIN_DEFAULT_PASSWORD=admin"

Write-Host "Env file criado com sucesso!"