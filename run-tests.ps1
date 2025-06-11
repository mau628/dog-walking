Clear-Host

# Delete all folders inside TestResults directory
$testResultsPath = Join-Path $PSScriptRoot "TestResults"
if (Test-Path $testResultsPath) {
    Get-ChildItem -Path $testResultsPath -Directory | Remove-Item -Recurse -Force
}

# Run the tests
dotnet test --collect:"XPlat Code Coverage" --settings coverlet.runsettings

# Get the latest test results directory, get directory name only, and remove the "TestResults\" prefix
$latestTestResultsDir = Get-ChildItem -Path $testResultsPath -Directory | Sort-Object LastWriteTime -Descending | Select-Object -First 1 | ForEach-Object { $_.Name }
# Check if the latest test results directory exists
if (-not $latestTestResultsDir) {
    Write-Host "No test results found."
    exit 1
}

# Run ReportGenerator to generate the coverage report
$reportGeneratorPath = Join-Path $env:USERPROFILE ".nuget\packages\reportgenerator\5.1.24\tools\net7.0\ReportGenerator.dll"
dotnet "$reportGeneratorPath" -reports:"TestResults\$latestTestResultsDir\coverage.cobertura.xml" -targetdir:"TestResults\Report" -reporttypes:Html

# Open the coverage report in the default browser
Start-Process "TestResults\Report\index.html"