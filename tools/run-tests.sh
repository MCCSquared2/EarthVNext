#!/usr/bin/env bash
set -euo pipefail

PROJECT_PATH="$(cd "$(dirname "$0")/.." && pwd)"
UNITY_PATH=${UNITY_PATH:-unity-editor}
RESULTS_DIR="$PROJECT_PATH/Artifacts/TestResults"
mkdir -p "$RESULTS_DIR"

run_suite() {
  local suite=$1
  "$UNITY_PATH" -projectPath "$PROJECT_PATH" -runTests -testPlatform "$suite" \
    -logFile "$RESULTS_DIR/${suite}.log" \
    -testResults "$RESULTS_DIR/${suite}-results.xml" || true
}

echo "Running EditMode tests..."
run_suite editmode

echo "Running PlayMode tests..."
run_suite playmode

echo "Logs located at $RESULTS_DIR"
