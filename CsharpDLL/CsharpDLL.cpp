// CsharpDLL.cpp : Defines the exported functions for the DLL.
//

#include "pch.h"
#include "framework.h"
#include "CsharpDLL.h"


// This is an example of an exported variable
CSHARPDLL_API int nCsharpDLL=0;

// This is an example of an exported function.
CSHARPDLL_API int fnCsharpDLL(void)
{
    return 0;
}

// This is the constructor of a class that has been exported.
CCsharpDLL::CCsharpDLL()
{
    return;
}
