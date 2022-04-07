#include<map>
#include<string>
#include<iostream>
#include<Windows.h>
#include<stdlib.h>
#include<thread>
#include<processthreadsapi.h>
#include<list>
#include<sstream>

using namespace std;

const int SUCCESS=0;
const int ARGS_ERROR=-1;
const int FAIL_PASS_TEST = -2;

void memoryTest();
void cpuTest();

map<string, string> args;

int main(int num,char* arg[]) {
	for (int i = 1; i < num; i += 2) {
		if (arg[i][0] == '-' && i + 1 < num) {
			args[&arg[i][1]] = arg[i + 1];
		}
		else {
			cout << "参数错误" << endl;
			return ARGS_ERROR;
		}
	}
	if (args["operator"] == "memoyTest") {
		memoryTest();
	}
	else if (args["operator"] == "cpuTest") {
		cpuTest();
	}
	else {
		cout << "未知的operator " << args["operator"] << endl;
		return ARGS_ERROR;
	}
	return SUCCESS;
}

void memoryTest() {
	DWORDLONG reservedMemory = _atoi64(args["reservedMemory"].c_str());
	long long memoryPerThread = _atoi64(args["memoryPerThread"].c_str());
	DWORD sleepTime = atoi(args["sleepTime"].c_str());
	DWORD totalTime = atoi(args["totalTime"].c_str());
	if (memoryPerThread == 0 || totalTime == 0)exit(ARGS_ERROR);
	MEMORYSTATUSEX statex;
	statex.dwLength = sizeof(statex);
	GlobalMemoryStatusEx(&statex);

	list<thread> threads;
	bool runing = true;
	while (statex.ullAvailPhys > reservedMemory) {
		GlobalMemoryStatusEx(&statex);
		printf("剩余物理内存 %I64d\n",statex.ullAvailPhys);
		threads.push_back(thread([&memoryPerThread, &sleepTime,&runing]() {
			stringstream ss;
			while (true) {
				char* p = (char*)malloc(memoryPerThread);
				if (p == nullptr) { 
					ss << "线程: " << this_thread::get_id() << " 申请内存失败" << endl;
					cout << ss.str(); ss.clear();
					exit(FAIL_PASS_TEST); 
				}
				ss << "线程: " << this_thread::get_id() << " 成功申请内存" << memoryPerThread << endl;
				cout << ss.str(); ss.str("");
				for (int i = 0; i < memoryPerThread; ++i) {
					p[i] = (char)i;
				}
				ss << "线程: " << this_thread::get_id() << " sleep开始"<< endl;
				cout << ss.str(); ss.str("");
				Sleep(sleepTime);
				ss << "线程: " << this_thread::get_id() << " sleep结束" << endl;
				cout << ss.str(); ss.str("");
				for (int i = 0; i < memoryPerThread; ++i) {
					if (p[i] != (char)i) {
						ss << "线程: " << this_thread::get_id() << " 校验失败" << endl;
						cout << ss.str(); ss.str("");
						exit(FAIL_PASS_TEST);
					}
				}
				free(p);
				ss << "线程: " << this_thread::get_id() << " 释放内存" << endl;
				cout << ss.str(); ss.str("");
				if (!runing)return;
			}
			}));
		Sleep(1000);
	}
	Sleep(totalTime);
	runing = false;
	for (auto& t :threads) {
		t.join();
	}
	cout << "内存测试成功" << endl;
}

void cpuTest() {
	DWORD totalTime = atoi(args["totalTime"].c_str());
	if (totalTime == 0)exit(ARGS_ERROR);
	list<HANDLE> threads;
	auto cpuTestThread = [](void* args) ->DWORD{
		while (true) {
			sqrt(rand());
		}
		return 0;
	};
	if(args["thread"] == "auto") {
		SYSTEM_INFO systemInfo;
		GetSystemInfo(&systemInfo);
		for (DWORD i = 0; i < systemInfo.dwNumberOfProcessors; ++i) {
			HANDLE handle = CreateThread(nullptr, 0, cpuTestThread, nullptr, 0, nullptr);
			if (handle == 0)exit(FAIL_PASS_TEST);
			SetThreadAffinityMask(handle, static_cast<DWORD_PTR>(1) << i);
			threads.push_back(handle);
		}
	}
	cout << "测试中... " << endl;
	Sleep(totalTime);
	for (auto thread : threads) {
		TerminateThread(thread, 0);
	}
	exit(SUCCESS);
}