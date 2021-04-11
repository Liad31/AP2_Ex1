//Entity.h
#pragma once
#include "ManagedObject.h"
#include "../DLLmaybe/AnomalyDetector.h"
#include "TimeSeries.h"
#include "AnomalyReport.h"
using namespace System;
namespace Wrapper
{
    public  ref class AnomalyDetector : public ManagedObject<Core::TimeSeriesAnomalyDetector>
    {
    public:

        AnomalyDetector(Core::TimeSeriesAnomalyDetector* ad);
        virtual void learnNormal(const Wrapper::TimeSeries ts);
        virtual array<AnomalyReport^>^ detect(const Wrapper::TimeSeries ts);
    };
}
#include "HybridAnomalyDetector.h"
#include "SimpleAnomalyDetector.h"
