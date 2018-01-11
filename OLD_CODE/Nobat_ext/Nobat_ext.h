// Nobat_ext.h - Contains declaration of Function class  
#pragma once  

#ifdef Nobat_ext_EXPORTS  
#define Nobat_ext_API __declspec(dllexport)   
#else  
#define Nobat_ext_API __declspec(dllimport)   
#endif  

namespace Nobat_ext
{
	// This class is exported from the Nobat_ext.dll
	
	class Functions
	{
	public:
		__declspec(dllexport) char Serial(const char *axis);
	};
}