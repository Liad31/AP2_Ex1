#include "TimeSeries.h"
namespace Wrapper
{
	TimeSeries::TimeSeries(String^ csvFile)
		: ManagedObject(new Core::TimeSeries(string_to_char_array(csvFile)))
	{

	}

}