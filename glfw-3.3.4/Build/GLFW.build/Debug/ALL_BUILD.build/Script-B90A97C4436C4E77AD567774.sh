#!/bin/sh
make -C /Volumes/albert/OpenGL/glfw-3.3.4/Build -f /Volumes/albert/OpenGL/glfw-3.3.4/Build/CMakeScripts/ALL_BUILD_cmakeRulesBuildPhase.make$CONFIGURATION OBJDIR=$(basename "$OBJECT_FILE_DIR_normal") all
