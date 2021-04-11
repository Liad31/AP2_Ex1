#include "AnomalyDetector.h"
#include "../DLLmaybe/SimpleAnomalyDetector.h"
#include "../DLLmaybe/AnomalyDetector.h"
namespace Wrapper {
    AnomalyDetector::AnomalyDetector(Core::TimeSeriesAnomalyDetector* ad) : ManagedObject(ad)  {
        
    }
    void AnomalyDetector::learnNormal(const Wrapper::TimeSeries ts) {
        auto innerTs = ts.m_Instance;
        m_Instance->learnNormal(*innerTs);
    }
    array<AnomalyReport^>^ AnomalyDetector::detect(const Wrapper::TimeSeries ts) {
        auto innerTs = ts.m_Instance;
        auto res = m_Instance->detect(*innerTs);
        array<AnomalyReport^>^ resArray = gcnew array<AnomalyReport^>(res.size());
        for (int i = 0; i < res.size(); ++i) {
            resArray[i] = gcnew AnomalyReport(res[i].description,res[i].timeStep);
        }
        return resArray;

    }
}