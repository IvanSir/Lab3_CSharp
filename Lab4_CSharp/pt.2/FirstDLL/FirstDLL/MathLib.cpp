#include "pch.h"
#include "MathLib.h"

int Sum(int a, int b)
{
	return a + b;
}


int Subtract(int a, int b)
{
	return a - b;
}

int Multi(int a, int b)
{
	return a * b;
}


float Div(int a, int b)
{
	if (b != 0)
		return (float)a / (float)b;
	else
		return 0;
}

int Power(int a, int b) 
{
	int rez = 1;
	for (int i = 0; i < b; i++) 
	{
		rez *= a;
	}

	return rez;
}

int Low(float a)
{
	return (int)a;
}
