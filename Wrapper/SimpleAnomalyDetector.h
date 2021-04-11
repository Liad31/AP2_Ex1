#pragma once
//Entity.h
#pragma once
#include "AnomalyDetector.h"
#include "../DLLmaybe/SimpleAnomalyDetector.h"
#include "../DLLmaybe/AnomalyDetector.h"
using namespace System;
namespace Wrapper
{
    public  ref class SimpleAnomalyDetector : AnomalyDetector
    {
    public:

        SimpleAnomalyDetector() : AnomalyDetector(new Core::SimpleAnomalyDetector()) {

        }
    };
}