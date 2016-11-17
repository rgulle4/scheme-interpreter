#!/bin/bash
INPUT_FILE="test1.scm"
if [ $# == 1 ]; then
  INPUT_FILE="${1}"
fi

DIFF_TOOL='diff'
if [ $# == 2 ]; then
  INPUT_FILE="${1}"
  DIFF_TOOL="${2}"
fi

make
cat $INPUT_FILE | mono Scheme4101-reference.exe > out-reference.txt 2>&1
cat $INPUT_FILE | mono Scheme4101.exe > out-ours.txt 2>&1

echo > out-diff.txt
echo "# diff for output of Scheme4101-reference.exe vs our Scheme4101.exe" >> out-diff.txt
echo "# Using input file: $INPUT_FILE" >> out-diff.txt
$DIFF_TOOL out-reference.txt out-ours.txt >> out-diff.txt
echo "Begin diff (in out-diff.txt)..."
cat out-diff.txt
echo "End diff (in out-diff.txt)..."
