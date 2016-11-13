#!/bin/bash
## To debug, run this script, then in VS Code, go to the debug view, and
## Pick the "Attach" option, and click the play button.
set -e
make -f MakefileDebug
cat | mono --debug \
  --debugger-agent=transport=dt_socket,server=y,address=127.0.0.1:13375 \
  Scheme4101-debug.exe

