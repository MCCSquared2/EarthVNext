param(
    [string]$RepoRoot = (Resolve-Path "$(Join-Path $PSScriptRoot '..')")
)

$unityVersionFile = Join-Path $RepoRoot "unity-version.txt"
$unityVersion = Get-Content $unityVersionFile
Write-Host "Repo: $RepoRoot"
Write-Host "Expected Unity version: $unityVersion"

git lfs install --skip-repo | Out-Null

if (Get-Command unityhub -ErrorAction SilentlyContinue) {
    Write-Host "Unity Hub detected. Ensure $unityVersion is installed."
} else {
    Write-Warning "Unity Hub not found in PATH. Install it to manage Unity versions."
}

Write-Host "Setup complete."
