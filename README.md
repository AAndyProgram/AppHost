# AppHost
Program for preventing applications closing

Sometimes background programs are dropping down. For preventing this unwanted action, I wrote this app.

How it works:
1. [Download latest release](https://github.com/AAndyProgram/AppHost/releases/latest)
2. Unzip and place this program at any folder you want.
3. Run the program.
4. If it is a first time opening than application list form will be loaded.
5. Add a new one or change existing application  monitoring instance.

Parameters:
- ```Process Name``` - you can find process name of your application at "Windows Task Manager" or "Process Explorer";
- ```Application Path``` - path to monitoring application execution file;
- ```Check Timer``` - interval for checking application still running;
- ```Stop Restart After``` - count of restarts for stop restarting app;
- ```Look Application Name Instead Path``` - If checked than application name (instead application path) will be looking for in processes.

For change parameters click at tray icon and then click "Settings".
