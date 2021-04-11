
#ifndef wrapperDll_EXPORT_H
#define wrapperDll_EXPORT_H

#ifdef wrapperDll_BUILT_AS_STATIC
#  define wrapperDll_EXPORT
#  define WRAPPERDLL_NO_EXPORT
#else
#  ifndef wrapperDll_EXPORT
#    ifdef wrapperDll_EXPORTS
        /* We are building this library */
#      define wrapperDll_EXPORT __declspec(dllexport)
#    else
        /* We are using this library */
#      define wrapperDll_EXPORT __declspec(dllimport)
#    endif
#  endif

#  ifndef WRAPPERDLL_NO_EXPORT
#    define WRAPPERDLL_NO_EXPORT 
#  endif
#endif

#ifndef WRAPPERDLL_DEPRECATED
#  define WRAPPERDLL_DEPRECATED __declspec(deprecated)
#endif

#ifndef WRAPPERDLL_DEPRECATED_EXPORT
#  define WRAPPERDLL_DEPRECATED_EXPORT wrapperDll_EXPORT WRAPPERDLL_DEPRECATED
#endif

#ifndef WRAPPERDLL_DEPRECATED_NO_EXPORT
#  define WRAPPERDLL_DEPRECATED_NO_EXPORT WRAPPERDLL_NO_EXPORT WRAPPERDLL_DEPRECATED
#endif

#if 0 /* DEFINE_NO_DEPRECATED */
#  ifndef WRAPPERDLL_NO_DEPRECATED
#    define WRAPPERDLL_NO_DEPRECATED
#  endif
#endif

#endif /* wrapperDll_EXPORT_H */
