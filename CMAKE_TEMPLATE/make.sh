#!/bin/sh

cd "$(dirname "$0")"

rm -r _linux
mkdir -p _linux
cd _linux

cmake ../
make
