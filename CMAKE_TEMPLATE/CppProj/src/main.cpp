
#include "../include/main.h"

using namespace std;

int main()
{
	cout << "Hello C++ Project." << endl;

#ifdef __linux__
	cout << "Linux Env." << endl;
#endif

#ifdef _WIN32
	cin.get();
#endif
	return 0;
}
