#pragma once
//Entity.h
#include "AnomalyDetector.h"
#include "../DLLmaybe/HybridAnomalyDetector.h"
#include "../DLLmaybe/AnomalyDetector.h"
using namespace System;
namespace Wrapper
{
    public  ref class HybridAnomalyDetector : AnomalyDetector
    {
    public:

        HybridAnomalyDetector() : AnomalyDetector(new Core::SimpleAnomalyDetector()) {

        }
    };
}