# CMakeList.txt: 顶层 CMake 项目文件，在此处执行全局配置
# 并包含子项目。
#
cmake_minimum_required (VERSION 3.5.1)

include_directories(include)

file(GLOB src_source "src/*.cpp")

add_executable (CppProj ${src_source})
