﻿进程创建的线程默认为非后台线程，可以通过设置线程的Isbackground属性指定线程是否为后台。
后台线程不会阻止进行的结束，即当进程结束后会结束所有后台线程，无论后台线程是否运行结束。
后台线程在进程结束后不会退出，在任务管理器里还会驻留。