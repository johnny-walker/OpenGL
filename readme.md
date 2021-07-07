# OpenGL Tutorial
* reference: https://learnopengl.com/Introduction

## setup developing environment (OS dependent)

* this GitHub is based on MacOS
##### [GLAD]: (https://glad.dav1d.de/)
##### [GLFW]: (https://www.glfw.org/download.html)
##### [GLM]:  (https://github.com/g-truc/glm)

* http://www.tastones.com/zh-tw/stackoverflow/opengl/getting-started-with-opengl/setup_modern_opengl_4.1_on_macos_xcode_glfw_and_glew/

### setup GLFW
* install GLFW by brew (brew install glfw), or alternative, download source code and build yourself
* build GLFW, this will genearte necessary files to "/usr/local/include",  "/usr/local/lib" 
* (after building GLFW, make sure there are 2 glfw3xxx.h and 3 libglfwxxx.dylib)

### setup GLAD/GLM
* download and copy GLAD/GLM header folders to '/usr/local/inlcude' 

### when create new openGL project by XCode, should do following: 
* add header search path (usr/local/include) and library search path (/usr/local/lib)
* pull from Finder (reference) "./glad/src/glad.c" to xcode project
* pull from Finder (reference) "./glfw/lib/libglfw.3.dylib" to xcode project