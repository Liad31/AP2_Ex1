
#add_definitions(-DEXAMPLEUNMANAGEDDLL_EXPORTS)
SET(LIB_SOURCE
        Entity.h ManagedObject.h Wrapper.cpp Wrapper.h Entity.cpp
        )
include (GenerateExportHeader)

add_library(wrapperDll SHARED ${LIB_SOURCE})
GENERATE_EXPORT_HEADER (wrapperDll
        BASE_NAME wrapperDll
        EXPORT_MACRO_NAME wrapperDll_EXPORT
        EXPORT_FILE_NAME wrapperDll_Export.h
        STATIC_DEFINE wrapperDll_BUILT_AS_STATIC
        )

