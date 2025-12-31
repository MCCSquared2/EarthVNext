param(
    [string]$ProjectPath = (Resolve-Path "$(Join-Path $PSScriptRoot '..')"),
    [string]$UnityPath = "Unity.exe"
)

$resultsDir = Join-Path $ProjectPath "Artifacts/TestResults"
New-Item -ItemType Directory -Force -Path $resultsDir | Out-Null

function Run-Suite {
    param([string]$Suite)
    & $UnityPath -projectPath $ProjectPath -runTests -testPlatform $Suite `
        -logFile (Join-Path $resultsDir "$Suite.log") `
        -testResults (Join-Path $resultsDir "$Suite-results.xml")
}

Write-Host "Running EditMode tests..."
Run-Suite "editmode"

Write-Host "Running PlayMode tests..."
Run-Suite "playmode"

Write-Host "Logs located at $resultsDir"
