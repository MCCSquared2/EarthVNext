# Contributing to VaultSim

Thanks for contributing! This document describes how to work in this repository so that builds stay reproducible and reviews stay quick.

## Branching & Workflow
- **Default branch:** `main`.
- **Feature branches:** `feature/<short-description>`.
- **Fix branches:** `fix/<issue>` or `hotfix/<issue>`.
- **Release branches:** `release/<version>`.
- Use pull requests for all changes; no direct pushes to `main`.

## Commit Style
- Keep commits scoped and descriptive (e.g., `feat: add room config scriptable object`).
- Prefer present-tense, imperative subject lines.
- Reference issues when relevant (`fixes #123`).

## Pull Request Checklist
- [ ] CI is green (formatting, tests).
- [ ] New scripts compile without warnings.
- [ ] Scenes/prefabs updated intentionally; avoid noisy diffs.
- [ ] Assets larger than 10 MB stored with Git LFS.
- [ ] Documentation updated (README/CHANGELOG/etc.) as needed.

## Code Style
- C#: follow `.editorconfig` (spaces, braces on new lines for namespaces/classes, use `var` when type is obvious, XML docs for public APIs).
- Avoid `#pragma warning disable` unless justified.
- Prefer `readonly` fields for injected dependencies.
- Runtime assemblies defined by `.asmdef` files per feature area.

## Packages & Dependencies
- Add UPM packages via `Packages/manifest.json`. Avoid embedding packages unless necessary.
- Keep `Packages/packages-lock.json` in sync.
- Third-party assets belong in `Assets/ThirdParty/` with clear licensing.

## Assets & LFS
- Binary assets (textures, audio, FBX, PSD, etc.) must be tracked with Git LFS (see `.gitattributes`).
- Keep placeholder art low-res to minimize repo size.

## Testing
- Add EditMode or PlayMode tests for new features when possible.
- Use `./tools/run-tests.sh` or `./tools/run-tests.ps1` to run Unity tests headlessly.

## Adding Scenes/Prefabs
- Place scenes in `Assets/_Project/Scenes/` and register them in `ProjectSettings/EditorBuildSettings.asset` if they should be in builds.
- Prefabs live under `Assets/_Project/Prefabs/`.

## Security
- Never commit secrets. CI uses GitHub Secrets (e.g., `UNITY_LICENSE`).
- Report vulnerabilities via [SECURITY.md](SECURITY.md).
