#include<map>
#include<string>
#include<iostream>
#include<Windows.h>
#include<stdlib.h>
#include<thread>
#include<list>
#include<sstream>

using namespace std;

const int SUCCESS=0;
const int ARGS_ERROR=-1;
const int FAIL_PASS_TEST = -2;

void memoryTest();

map<string, string> args;

int main(int num,char* arg[]) {
	for (int i = 1; i < num; i += 2) {
		if (arg[i][0] == '-' && i + 1 < num) {
			args[&arg[i][1]] = arg[i + 1];
		}
		else {
			cout << "��������" << endl;
			return ARGS_ERROR;
		}
	}
	if (args["operator"] == "memoyTest") {
		memoryTest();
	}
	else {
		cout << "δ֪��operator " << args["operator"] << endl;
		return ARGS_ERROR;
	}
	return SUCCESS;
}

void memoryTest() {
	long long reservedMemory = _atoi64(args["reservedMemory"].c_str());
	long long memoryPerThread = _atoi64(args["memoryPerThread"].c_str());
	long long sleepTime = _atoi64(args["sleepTime"].c_str());
	long long totalTime = _atoi64(args["totalTime"].c_str());
	if (memoryPerThread == 0 || totalTime == 0)exit(ARGS_ERROR);
	MEMORYSTATUSEX statex;
	statex.dwLength = sizeof(statex);
	GlobalMemoryStatusEx(&statex);

	list<thread> threads;
	bool runing = true;
	while (statex.ullAvailPhys > reservedMemory) {
		GlobalMemoryStatusEx(&statex);
		printf("ʣ�������ڴ� %I64d\n",statex.ullAvailPhys);
		threads.push_back(thread([&memoryPerThread, &sleepTime,&runing]() {
			stringstream ss;
			while (true) {
				char* p = (char*)malloc(memoryPerThread);
				if (p == nullptr) { 
					ss << "�߳�: " << this_thread::get_id() << " �����ڴ�ʧ��" << endl;
					cout << ss.str(); ss.clear();
					exit(FAIL_PASS_TEST); 
				}
				ss << "�߳�: " << this_thread::get_id() << " �ɹ������ڴ�" << memoryPerThread << endl;
				cout << ss.str(); ss.str("");
				for (int i = 0; i < memoryPerThread; ++i) {
					p[i] = (char)i;
				}
				ss << "�߳�: " << this_thread::get_id() << " sleep��ʼ"<< endl;
				cout << ss.str(); ss.str("");
				Sleep(sleepTime);
				ss << "�߳�: " << this_thread::get_id() << " sleep����" << endl;
				cout << ss.str(); ss.str("");
				for (int i = 0; i < memoryPerThread; ++i) {
					if (p[i] != (char)i) {
						ss << "�߳�: " << this_thread::get_id() << " У��ʧ��" << endl;
						cout << ss.str(); ss.str("");
						exit(FAIL_PASS_TEST);
					}
				}
				free(p);
				ss << "�߳�: " << this_thread::get_id() << " �ͷ��ڴ�" << endl;
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
	cout << "�ڴ���Գɹ�" << endl;
}