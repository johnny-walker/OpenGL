#!/bin/sh
make -C /Volumes/albert/OpenGL/glfw-3.3.4/Build/src -f /Volumes/albert/OpenGL/glfw-3.3.4/Build/src/CMakeScripts/glfw_postBuildPhase.make$CONFIGURATION OBJDIR=$(basename "$OBJECT_FILE_DIR_normal") all
