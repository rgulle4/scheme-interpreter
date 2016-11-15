#!/bin/bash
## To debug, run this script, then in VS Code, go to the debug view, and
## Pick the "Attach" option, and click the play button.
set -e

INPUT_FILE=""

if [ $# == 1 ]; then
  INPUT_FILE="${1}"   ## store $1 wo trailing `/`
fi

make -f MakefileDebug
cat $INPUT_FILE | mono --debug \
  --debugger-agent=transport=dt_socket,server=y,address=127.0.0.1:13375 \
  Scheme4101-debug.exe

