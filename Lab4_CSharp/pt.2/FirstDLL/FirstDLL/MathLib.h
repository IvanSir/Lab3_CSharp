#pragma once

#ifdef MATHLIBRARY_EXPORTS
#define MATHLIBRARY_API __declspec(dllexport)
#else
#define MATHLIBRARY_API __declspec(dllimport)
#endif

extern "C" MATHLIBRARY_API int Sum(int a, int b);

extern "C" MATHLIBRARY_API int Sub(int a, int b);

extern "C" MATHLIBRARY_API int Multi(int a, int b);

extern "C" MATHLIBRARY_API float Div(int a, int b);

extern "C" MATHLIBRARY_API int Power(int a, int b);

extern "C" MATHLIBRARY_API int Low(float a);

