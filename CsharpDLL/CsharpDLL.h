// The following ifdef block is the standard way of creating macros which make exporting
// from a DLL simpler. All files within this DLL are compiled with the CSHARPDLL_EXPORTS
// symbol defined on the command line. This symbol should not be defined on any project
// that uses this DLL. This way any other project whose source files include this file see
// CSHARPDLL_API functions as being imported from a DLL, whereas this DLL sees symbols
// defined with this macro as being exported.
#ifdef CSHARPDLL_EXPORTS
#define CSHARPDLL_API __declspec(dllexport)
#else
#define CSHARPDLL_API __declspec(dllimport)
#endif

// This class is exported from the dll
class CSHARPDLL_API CCsharpDLL {
public:
	CCsharpDLL(void);
	// TODO: add your methods here.
};

extern CSHARPDLL_API int nCsharpDLL;

CSHARPDLL_API int fnCsharpDLL(void);
