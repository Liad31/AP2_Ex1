//ManagedObject.h
#pragma once
using namespace System;
using namespace System::Runtime::InteropServices;
namespace Wrapper {

    template<class T>
    public ref class ManagedObject
    {
    public:
        T* m_Instance;
        ManagedObject(T* instance)
            : m_Instance(instance)
        {
        }
        virtual ~ManagedObject()
        {
            if (m_Instance != nullptr)
            {
                delete m_Instance;
            }
        }
        !ManagedObject()
        {
            if (m_Instance != nullptr)
            {
                delete m_Instance;
            }
        }
        T* GetInstance()
        {
            return m_Instance;
        }

        static const char* string_to_char_array(String^ string)
        {
            const char* str = (const char*)(Marshal::StringToHGlobalAnsi(string)).ToPointer();
            return str;
        }
        /*template <typename T>
        static void array_conversion<T>(array<T>^ data)
        {
            pin_ptr<T> arrayPin = &data[0];
            unsigned int size = data->Length;
        }*/
    };
}