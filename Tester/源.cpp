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
			cout << "��������" << endl;
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
		cout << "δ֪��operator " << args["operator"] << endl;
		Usage();
		return ARGS_ERROR;
	}
	return SUCCESS;
}

void Usage()
{
	printf("x86�Զ�������� �����в���ʵ������\n"
		"�˹���Ĭ���������Զ������׼�һͬ���У���Ӧ���ֶ�����\n"
		"=================\n\n"
		"�Լ����Ӳ������һϵ��ѹ������\n"
		"Tester -operator [opn] <-output> args\n\n"
		"-operator\tָ�����Զ���\n"
		"-output\t�򿪻���\n"
		"\t��ǰ��ѡ����cpuTest, memoryTest\n"
		"\t cpuTest: �Լ�������봦����ִ��ѹ������\n"
		"\t memoryTest���Լ�����ڴ�ִ��ѹ�����ԡ����棺�˲��Զ���32λ�����\n"
		"\t  ������Ч�������Խ��ж����ͬʱ���м�������ڴ�ṹ��������\n"
		"args\t���Զ�������Ҫ�Ĳ���\n"
		"\tcpuTest:\n"
		"\t -totalTime\tָ��ִ�в��Ե���ʱ��\n"
		"\t -thread\tָ��ִ�в��Ե��߳�����ָ��Ϊ auto ���Զ�����\n"
		"\tmemoryTest:\n"
		"\t -reservedMemory\t�ڴ���Ե���Ԥ���ڴ�\n"
		"\t -memoryPerThread\t���߳�������ڴ棬��λΪ�ֽ�\n"
		"\t -sleepTime\t���̱߳�����ʱ�䣬������ʱ�佫�ͷ��ڴ档�������õ���totalTime\n"
		"\t -totalTime\tָ��ִ�в��Ե���ʱ��\n"
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
			printf("ʣ�������ڴ� %I64d\n", statex.ullAvailPhys);
		}
		threads.push_back(thread([&memoryPerThread, &sleepTime,&runing]() {
			stringstream ss;
			while (true) {
				char* p = (char*)malloc(memoryPerThread);
				if (p == nullptr) { 
					if (isPrintf) 
					{
						ss << "�߳�: " << this_thread::get_id() << " �����ڴ�ʧ��" << endl;
						cout << ss.str(); 
						ss.clear();
					}
					exit(FAIL_PASS_TEST); 
				}
				if (isPrintf)
				{
					ss << "�߳�: " << this_thread::get_id() << " �ɹ������ڴ�" << memoryPerThread << endl;
					cout << ss.str();
					ss.clear();
				}
				for (int i = 0; i < memoryPerThread; ++i) {
					p[i] = (char)i;
				}
				if (isPrintf)
				{
					ss << "�߳�: " << this_thread::get_id() << " sleep��ʼ" << endl;
					cout << ss.str(); 
					ss.clear();
				}
				Sleep(sleepTime);
				if (isPrintf)
				{
					ss << "�߳�: " << this_thread::get_id() << " sleep����" << endl;
					cout << ss.str();
					ss.clear();
				}
				for (int i = 0; i < memoryPerThread; ++i) {
					if (p[i] != (char)i) {
						if (isPrintf)
						{
							ss << "�߳�: " << this_thread::get_id() << " У��ʧ��" << endl;
							cout << ss.str(); 
							ss.clear();
						}
						exit(FAIL_PASS_TEST);
					}
				}
				free(p);
				if (isPrintf)
				{
					ss << "�߳�: " << this_thread::get_id() << " �ͷ��ڴ�" << endl;
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
	cout << "�ڴ���Գɹ�" << endl;
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
	cout << "������... " << endl;
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