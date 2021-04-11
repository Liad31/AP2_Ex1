//Entity.h
#pragma once
#include "ManagedObject.h"
#include "../DLLmaybe/timeseries.h"

using namespace System;
namespace Wrapper
{
    public ref class TimeSeries : public ManagedObject<Core::TimeSeries>
    {
    public:

        TimeSeries(String^ csvFile);
        
      
    };
}