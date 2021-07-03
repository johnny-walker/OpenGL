#!/bin/sh
make -C /Volumes/albert/OpenGL/glfw-3.3.4/Build -f /Volumes/albert/OpenGL/glfw-3.3.4/Build/CMakeScripts/ZERO_CHECK_cmakeRulesBuildPhase.make$CONFIGURATION OBJDIR=$(basename "$OBJECT_FILE_DIR_normal") all
