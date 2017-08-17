// MathLibrary.h - Contains declaration of Function class  
#pragma once  

#ifdef MATHLIBRARY_EXPORTS  
#define MATHLIBRARY_API __declspec(dllexport)   
#else  
#define MATHLIBRARY_API __declspec(dllimport)   
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