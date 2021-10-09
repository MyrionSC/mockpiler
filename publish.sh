#!/usr/bin/env bash

dotnet.exe publish -c Release -r win-x64 --self-contained false
#dotnet.exe publish -c Release -r linux-x64 --self-contained false

