#!/usr/bin/env bash

echo uploading files...
scp webapi/bin/Release/net5.0/linux-x64/* marand:apps/mockpiler

echo restarting service...
ssh marand "sudo systemctl restart mockpiler.service"

echo deploy complete

