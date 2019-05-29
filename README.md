# MCServerManager2

A "cross-platform" manager for Minecraft servers.
Cross platform means?
* Client should be compatible with Windows XP+ and mono \<something\>+
* **DON'T USE WINE**

# Requirements to use
* a Unix (I use Linux, but it *might* work on other Unixes) server with an SSH/SFTP server and the following commands available:
* ``rm``, ``find``, ``screen``, ``grep``, ``realpath``, ``tree``, ``while`` (at least ``while`` in bash, I guess), ``mpstat``, ``test``

**MAKE SURE YOU HAVE ALL OF THESE COMMANDS AVAILABLE WITH THE OPTIONS USED IN THE PROGRAM!!! AND YOU NEED SFTP!!!**

You also need **PuTTY INSTALLED ON THE CLIENT OS**

# How does it organize instances?
* Instances aren't organized with any ``instance.cfg``. They are categorized by ``launch.sh``. Every instance must have a ``launch.sh``, and that is how they are launched.
* ``screen`` is used to separate the processes. If you don't have screen installed *bad stuff will happen*.

# Config file
The config file is a simple JSON document, here is a sample with (hopefully) all of the features used. If something isn't specified, it will use defaults or prompt you.
```json
{
	"Username": "user",
	"Hostname": "1.2.3.4",
	"Port": 22,
	"Password": "some password, remove this to prompt every time",
	"ServerPath": "~/stuff/minecraft_servers",
	"Editor": "gedit",
	"ExpandAllOnStart": true,
	"MountPoint": "/mnt/my_remote_server",
	"RemoteLocation": "/where/does/the/mount/point/refer/to/on/the/server"
}

# Building
On windows, just open visual studio and it should *hopefully* figure things out... If it wants dependencies open the nuget manager and install SSH.NET and Newtonsoft.Json

On *nix, have ``msbuild`` or ``xbuild`` and ``nuget`` setup with mono. Run ``nuget restore`` in the directory of the solution file, then run ``xbuild`` or ``msbuild``.
