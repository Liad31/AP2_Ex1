# CMAKE generated file: DO NOT EDIT!
# Generated by "NMake Makefiles" Generator, CMake Version 3.17

# Delete rule output on recipe failure.
.DELETE_ON_ERROR:


#=============================================================================
# Special targets provided by cmake.

# Disable implicit rules so canonical targets will work.
.SUFFIXES:


.SUFFIXES: .hpux_make_needs_suffix_list


# Command-line flag to silence nested $(MAKE).
$(VERBOSE)MAKESILENT = -s

# Suppress display of executed commands.
$(VERBOSE).SILENT:


# A target that is always out of date.
cmake_force:

.PHONY : cmake_force

#=============================================================================
# Set environment variables for the build.

!IF "$(OS)" == "Windows_NT"
NULL=
!ELSE
NULL=nul
!ENDIF
SHELL = cmd.exe

# The CMake executable.
CMAKE_COMMAND = "C:\Program Files\JetBrains\CLion 2020.2\bin\cmake\win\bin\cmake.exe"

# The command to remove a file.
RM = "C:\Program Files\JetBrains\CLion 2020.2\bin\cmake\win\bin\cmake.exe" -E rm -f

# Escaping for special characters.
EQUALS = =

# The top-level source directory on which CMake was run.
CMAKE_SOURCE_DIR = C:\Users\liad3\source\repos\DLLmaybe

# The top-level build directory on which CMake was run.
CMAKE_BINARY_DIR = C:\Users\liad3\source\repos\DLLmaybe\cmake-build-debug

# Include any dependencies generated for this target.
include DLLmaybe\CMakeFiles\DllMaybe.dir\depend.make

# Include the progress variables for this target.
include DLLmaybe\CMakeFiles\DllMaybe.dir\progress.make

# Include the compile flags for this target's objects.
include DLLmaybe\CMakeFiles\DllMaybe.dir\flags.make

DLLmaybe\CMakeFiles\DllMaybe.dir\Entity.cpp.obj: DLLmaybe\CMakeFiles\DllMaybe.dir\flags.make
DLLmaybe\CMakeFiles\DllMaybe.dir\Entity.cpp.obj: ..\DLLmaybe\Entity.cpp
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green --progress-dir=C:\Users\liad3\source\repos\DLLmaybe\cmake-build-debug\CMakeFiles --progress-num=$(CMAKE_PROGRESS_1) "Building CXX object DLLmaybe/CMakeFiles/DllMaybe.dir/Entity.cpp.obj"
	cd C:\Users\liad3\source\repos\DLLmaybe\cmake-build-debug\DLLmaybe
	C:\PROGRA~2\MICROS~3\2019\COMMUN~1\VC\Tools\MSVC\1428~1.299\bin\Hostx86\x86\cl.exe @<<
 /nologo /TP $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) /FoCMakeFiles\DllMaybe.dir\Entity.cpp.obj /FdCMakeFiles\DllMaybe.dir\ /FS -c C:\Users\liad3\source\repos\DLLmaybe\DLLmaybe\Entity.cpp
<<
	cd C:\Users\liad3\source\repos\DLLmaybe\cmake-build-debug

DLLmaybe\CMakeFiles\DllMaybe.dir\Entity.cpp.i: cmake_force
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green "Preprocessing CXX source to CMakeFiles/DllMaybe.dir/Entity.cpp.i"
	cd C:\Users\liad3\source\repos\DLLmaybe\cmake-build-debug\DLLmaybe
	C:\PROGRA~2\MICROS~3\2019\COMMUN~1\VC\Tools\MSVC\1428~1.299\bin\Hostx86\x86\cl.exe > CMakeFiles\DllMaybe.dir\Entity.cpp.i @<<
 /nologo /TP $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -E C:\Users\liad3\source\repos\DLLmaybe\DLLmaybe\Entity.cpp
<<
	cd C:\Users\liad3\source\repos\DLLmaybe\cmake-build-debug

DLLmaybe\CMakeFiles\DllMaybe.dir\Entity.cpp.s: cmake_force
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green "Compiling CXX source to assembly CMakeFiles/DllMaybe.dir/Entity.cpp.s"
	cd C:\Users\liad3\source\repos\DLLmaybe\cmake-build-debug\DLLmaybe
	C:\PROGRA~2\MICROS~3\2019\COMMUN~1\VC\Tools\MSVC\1428~1.299\bin\Hostx86\x86\cl.exe @<<
 /nologo /TP $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) /FoNUL /FAs /FaCMakeFiles\DllMaybe.dir\Entity.cpp.s /c C:\Users\liad3\source\repos\DLLmaybe\DLLmaybe\Entity.cpp
<<
	cd C:\Users\liad3\source\repos\DLLmaybe\cmake-build-debug

# Object files for target DllMaybe
DllMaybe_OBJECTS = \
"CMakeFiles\DllMaybe.dir\Entity.cpp.obj"

# External object files for target DllMaybe
DllMaybe_EXTERNAL_OBJECTS =

bin\DllMaybe.dll: DLLmaybe\CMakeFiles\DllMaybe.dir\Entity.cpp.obj
bin\DllMaybe.dll: DLLmaybe\CMakeFiles\DllMaybe.dir\build.make
bin\DllMaybe.dll: DLLmaybe\CMakeFiles\DllMaybe.dir\objects1.rsp
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green --bold --progress-dir=C:\Users\liad3\source\repos\DLLmaybe\cmake-build-debug\CMakeFiles --progress-num=$(CMAKE_PROGRESS_2) "Linking CXX shared library ..\bin\DllMaybe.dll"
	cd C:\Users\liad3\source\repos\DLLmaybe\cmake-build-debug\DLLmaybe
	"C:\Program Files\JetBrains\CLion 2020.2\bin\cmake\win\bin\cmake.exe" -E vs_link_dll --intdir=CMakeFiles\DllMaybe.dir --rc=C:\PROGRA~2\WI3CF2~1\10\bin\100183~1.0\x86\rc.exe --mt=C:\PROGRA~2\WI3CF2~1\10\bin\100183~1.0\x86\mt.exe --manifests  -- C:\PROGRA~2\MICROS~3\2019\COMMUN~1\VC\Tools\MSVC\1428~1.299\bin\Hostx86\x86\link.exe /nologo @CMakeFiles\DllMaybe.dir\objects1.rsp @<<
 /out:..\bin\DllMaybe.dll /implib:..\bin\DllMaybe.lib /pdb:C:\Users\liad3\source\repos\DLLmaybe\cmake-build-debug\bin\DllMaybe.pdb /dll /version:0.0 /machine:X86 /debug /INCREMENTAL  kernel32.lib user32.lib gdi32.lib winspool.lib shell32.lib ole32.lib oleaut32.lib uuid.lib comdlg32.lib advapi32.lib  
<<
	cd C:\Users\liad3\source\repos\DLLmaybe\cmake-build-debug

# Rule to build all files generated by this target.
DLLmaybe\CMakeFiles\DllMaybe.dir\build: bin\DllMaybe.dll

.PHONY : DLLmaybe\CMakeFiles\DllMaybe.dir\build

DLLmaybe\CMakeFiles\DllMaybe.dir\clean:
	cd C:\Users\liad3\source\repos\DLLmaybe\cmake-build-debug\DLLmaybe
	$(CMAKE_COMMAND) -P CMakeFiles\DllMaybe.dir\cmake_clean.cmake
	cd C:\Users\liad3\source\repos\DLLmaybe\cmake-build-debug
.PHONY : DLLmaybe\CMakeFiles\DllMaybe.dir\clean

DLLmaybe\CMakeFiles\DllMaybe.dir\depend:
	$(CMAKE_COMMAND) -E cmake_depends "NMake Makefiles" C:\Users\liad3\source\repos\DLLmaybe C:\Users\liad3\source\repos\DLLmaybe\DLLmaybe C:\Users\liad3\source\repos\DLLmaybe\cmake-build-debug C:\Users\liad3\source\repos\DLLmaybe\cmake-build-debug\DLLmaybe C:\Users\liad3\source\repos\DLLmaybe\cmake-build-debug\DLLmaybe\CMakeFiles\DllMaybe.dir\DependInfo.cmake --color=$(COLOR)
.PHONY : DLLmaybe\CMakeFiles\DllMaybe.dir\depend

