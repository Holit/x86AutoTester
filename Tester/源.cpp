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
void Usage();
void memoryTest();
void cpuTest();

map<string, string> args;

bool isPrintf = false;
int main(int num,char* arg[]) {
	for (int i = 1; i < num; i += 2) {
		if (arg[i][0] == '-' && i + 1 < num) {
			args[&arg[i][1]] = arg[i + 1];
		}
		else {
			cout << "参数错误" << endl;
			Usage();
			return ARGS_ERROR;
		}
	}
	if (args["output"] == "true")
	{
		isPrintf = true;
	}
	if (args["operator"] == "memoryTest") {
		memoryTest();
	}
	else if (args["operator"] == "cpuTest") {
		cpuTest();
	}
	else {
		cout << "未知的operator " << args["operator"] << endl;
		Usage();
		return ARGS_ERROR;
	}
	return SUCCESS;
}

void Usage()
{
	printf("x86自动测试软件 命令行测试实例工具\n"
		"此工具默认配置与自动测试套件一同运行，不应该手动运行\n"
		"=================\n\n"
		"对计算机硬件进行一系列压力测试\n"
		"Tester -operator [opn] <-output> args\n\n"
		"-operator\t指定测试对象\n"
		"-output\t打开回显\n"
		"\t当前可选对象：cpuTest, memoryTest\n"
		"\t cpuTest: 对计算机中央处理器执行压力测试\n"
		"\t memoryTest：对计算机内存执行压力测试。警告：此测试对于32位计算机\n"
		"\t  可能无效。您可以进行多程序同时运行检查整个内存结构和完整性\n"
		"args\t测试对象所需要的参数\n"
		"\tcpuTest:\n"
		"\t -totalTime\t指定执行测试的总时长\n"
		"\t -thread\t指定执行测试的线程数，指定为 auto 可自动分配\n"
		"\tmemoryTest:\n"
		"\t -reservedMemory\t内存测试的总预留内存\n"
		"\t -memoryPerThread\t各线程申请的内存，单位为字节\n"
		"\t -sleepTime\t各线程保留的时间，超过此时间将释放内存。建议设置等于totalTime\n"
		"\t -totalTime\t指定执行测试的总时长\n"
	);
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
		if (isPrintf)
		{
			printf("剩余物理内存 %I64d\n", statex.ullAvailPhys);
		}
		threads.push_back(thread([&memoryPerThread, &sleepTime,&runing]() {
			stringstream ss;
			while (true) {
				char* p = (char*)malloc(memoryPerThread);
				if (p == nullptr) { 
					if (isPrintf) 
					{
						ss << "线程: " << this_thread::get_id() << " 申请内存失败" << endl;
						cout << ss.str(); 
						ss.clear();
					}
					exit(FAIL_PASS_TEST); 
				}
				if (isPrintf)
				{
					ss << "线程: " << this_thread::get_id() << " 成功申请内存" << memoryPerThread << endl;
					cout << ss.str();
					ss.clear();
				}
				for (int i = 0; i < memoryPerThread; ++i) {
					p[i] = (char)i;
				}
				if (isPrintf)
				{
					ss << "线程: " << this_thread::get_id() << " sleep开始" << endl;
					cout << ss.str(); 
					ss.clear();
				}
				Sleep(sleepTime);
				if (isPrintf)
				{
					ss << "线程: " << this_thread::get_id() << " sleep结束" << endl;
					cout << ss.str();
					ss.clear();
				}
				for (int i = 0; i < memoryPerThread; ++i) {
					if (p[i] != (char)i) {
						if (isPrintf)
						{
							ss << "线程: " << this_thread::get_id() << " 校验失败" << endl;
							cout << ss.str(); 
							ss.clear();
						}
						exit(FAIL_PASS_TEST);
					}
				}
				free(p);
				if (isPrintf)
				{
					ss << "线程: " << this_thread::get_id() << " 释放内存" << endl;
					cout << ss.str(); 
					ss.clear();
				}
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
	HANDLE* threads;
	int threadCount = 0;
	bool isExit = false;
	auto cpuTestThread = [](void* args) ->DWORD{
		while (!*(bool*)args) {
			sqrt(rand());
		}
		return 0;
	};
	if(args["thread"] == "auto") {
		SYSTEM_INFO systemInfo;
		GetSystemInfo(&systemInfo);
		threads = new HANDLE[threadCount = systemInfo.dwNumberOfProcessors];
		for (DWORD i = 0; i < systemInfo.dwNumberOfProcessors; ++i) {
			HANDLE handle = CreateThread(nullptr, 0, cpuTestThread, &isExit, 0, nullptr);
			if (handle == 0)exit(FAIL_PASS_TEST);
			SetThreadAffinityMask(handle, static_cast<DWORD_PTR>(1) << i);
			threads[i]=handle;
		}
	}
	else {
		threadCount= atoi(args["thread"].c_str());
		if (threadCount == 0)exit(ARGS_ERROR);
		threads = new HANDLE[threadCount];
		for (DWORD i = 0; i < threadCount; ++i) {
			HANDLE handle = CreateThread(nullptr, 0, cpuTestThread, &isExit, 0, nullptr);
			if (handle == 0)exit(FAIL_PASS_TEST);
			threads[i] = handle;
		}
	}
	cout << "测试中... " << endl;
	Sleep(totalTime);
	isExit = true;
	DWORD dwWaitResult = WaitForMultipleObjects(
		threadCount,
		threads,
		TRUE,
		INFINITE);
	switch (dwWaitResult)
	{
	case WAIT_OBJECT_0:
		exit(SUCCESS);
	default:
		exit(FAIL_PASS_TEST);
	}
	exit(SUCCESS);
}