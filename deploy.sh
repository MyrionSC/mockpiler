#!/usr/bin/env bash

# upload dlls to marand/share
cd console/bin/Release/net5.0/win-x64
zip mockpiler.zip *
scp mockpiler.zip marand:/var/www/marand/share

# === Old deploy to webapi
# echo uploading files...
# scp webapi/bin/Release/net5.0/linux-x64/* marand:apps/mockpiler

# echo restarting service...
# ssh marand "sudo systemctl restart mockpiler.service"

# echo deploy complete

