
#include "../include/main.h"

int main()
{
	printf("Hello C Project.\n");

#ifdef __linux__
	printf("Linux Env.\n");
#endif

#ifdef _WIN32
	getchar();
#endif
	return 0;
}
