#pragma once
#include "../DLLmaybe/AnomalyDetector.h"
#include "ManagedObject.h"
namespace Wrapper {
    public ref class AnomalyReport : public ManagedObject<Core::AnomalyReport>
    {
    public:

        AnomalyReport(std::string description, long timeStep): ManagedObject(new Core::AnomalyReport(description,timeStep)){}
        property String^ description
        {
        public:
            String^ get()
            {
                return gcnew String(m_Instance->description.c_str());
            }
        }
        property long timestep {
            long get() {
                return m_Instance->timeStep;
            }
        }
    };
}