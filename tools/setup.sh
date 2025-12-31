#!/usr/bin/env bash
set -euo pipefail

REPO_ROOT="$(cd "$(dirname "$0")/.." && pwd)"
UNITY_VERSION_FILE="$REPO_ROOT/unity-version.txt"
UNITY_VERSION="$(cat "$UNITY_VERSION_FILE")"

echo "Repo: $REPO_ROOT"
echo "Expected Unity version: $UNITY_VERSION"

if ! command -v git >/dev/null 2>&1; then
  echo "git is required" >&2
  exit 1
fi

git lfs install --skip-repo || true

echo "Verifying Unity install via Unity Hub..."
if command -v unityhub >/dev/null 2>&1; then
  echo "Unity Hub detected. Ensure $UNITY_VERSION is installed with Windows/macOS modules as needed."
else
  echo "Unity Hub not found in PATH. Install Unity Hub to manage Unity versions." >&2
fi

if [ -d "$REPO_ROOT/.git" ]; then
  echo "Ensuring hooks directory exists"
  mkdir -p "$REPO_ROOT/.git/hooks"
fi

echo "Setup complete."
