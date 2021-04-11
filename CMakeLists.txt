cmake_minimum_required(VERSION 2.8.9)

project("dllTest")

include(CSharpUtilities)

##############################################################
# Output paths
##############################################################
SET(CMAKE_RUNTIME_OUTPUT_DIRECTORY "${CMAKE_BINARY_DIR}/bin")
SET(CMAKE_ARCHIVE_OUTPUT_DIRECTORY "${CMAKE_BINARY_DIR}/bin")
SET(CMAKE_LIBRARY_OUTPUT_DIRECTORY "${CMAKE_BINARY_DIR}/bin")


add_subdirectory(DLLmaybe)
add_subdirectory(Wrapper)

# C# Project MumboJumbo Hack
#SET(CSHARP_PROJECT "CsharpTest")
#SET(CSHARP_PROJECT_DIRECTORY "${CMAKE_CURRENT_SOURCE_DIR}/CsharpTest")
#MESSAGE( STATUS "Copying in C# Project: " ${CSHARP_PROJECT} )
#MESSAGE( STATUS "from directory: " ${CSHARP_PROJECT_DIRECTORY} )
#
#FILE(TO_NATIVE_PATH "${CSHARP_PROJECT_DIRECTORY}" DOS_STYLE_SOURCE_DIR)
#
#include_external_msproject(
#        ${CSHARP_PROJECT} ${CSHARP_PROJECT}.csproj
#        TYPE FAE04EC0-301F-11D3-BF4B-00C04F79EFBC  NativeEntity)
#
#CONFIGURE_FILE(${CSHARP_PROJECT_DIRECTORY}/${CSHARP_PROJECT}.csproj.template ${CSHARP_PROJECT}.csproj)
