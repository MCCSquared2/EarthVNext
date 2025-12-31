# VaultSim

VaultSim is a base-building and management prototype inspired by shelter management games. It ships with a Unity LTS project scaffold, CI/CD automation, and lightweight stubs for core systems so contributors can start iterating quickly. No third-party IP or assets are included.

## Project Status
This repository is a foundation-only scaffold. Systems are stubbed with interfaces and placeholder components to validate compilation, tests, and build automation.

## Badges
- CI: ![CI](https://github.com/USER/REPO/actions/workflows/ci.yml/badge.svg)
- License: ![License: MIT](https://img.shields.io/badge/License-MIT-green.svg)

Update `USER/REPO` with the real GitHub path after forking/creating the repository.

## Prerequisites
- **Unity**: 2022.3.30f1 (LTS). Install via [Unity Hub](https://unity.com/download) with Windows/macOS build support as needed.
- **Git LFS**: Required for binary assets. Install with `git lfs install`.
- **.NET SDK**: For optional formatting tools (`dotnet format`).
- **Node/PowerShell**: For helper scripts (optional).

## Getting Started
1. Clone the repository with LFS: `git clone --recursive <repo-url>` then `git lfs install`.
2. Confirm Unity version: `cat unity-version.txt` (matches `ProjectSettings/ProjectVersion.txt`). Open the project via Unity Hub by adding the repository folder.
3. First open will import packages; allow Unity to regenerate the Library folder.
4. Open the scene `Assets/_Project/Scenes/Main.unity` and press Play to verify the placeholder UI and systems run.

## Running Tests
- From Unity Editor: `Window -> General -> Test Runner`, run EditMode and PlayMode suites.
- CLI (example): `./tools/run-tests.sh` (macOS/Linux) or `./tools/run-tests.ps1` (Windows). These run Unity in batchmode for editmode and playmode tests and export results to `Artifacts/TestResults`.

## CI/CD
- GitHub Actions workflow: `.github/workflows/ci.yml`.
  - Triggers on PRs and pushes to `main`.
  - Steps: checkout, cache Library, install git-lfs, format check (dotnet format), Unity EditMode and PlayMode tests via GameCI.
  - Optional player build (Windows) when `workflow_dispatch` input `buildPlayer` is `true`.
- Configure secrets:
  - `UNITY_LICENSE`: Unity license text for GameCI builders (only required for CI test/build jobs).

## Branching Model
- Default branch: `main` (stable).
- Feature branches: `feature/<short-description>`.
- Release/hotfix branches as needed: `release/<version>`, `hotfix/<issue>`.

## Contributing
See [CONTRIBUTING.md](CONTRIBUTING.md) for code style, PR checklist, and asset guidelines.

## Troubleshooting
- **Missing modules**: Ensure Unity installs the Windows/macOS build modules you need.
- **LFS not installed**: Run `git lfs install` before opening the project.
- **Package restore issues**: Delete `Library/` and re-open; Unity will reimport packages.
- **CI failures**: Confirm `UNITY_LICENSE` secret is set, or disable CI jobs requiring it by removing the `buildPlayer` dispatch input when not needed.

## License
MIT License. See [LICENSE](LICENSE).
