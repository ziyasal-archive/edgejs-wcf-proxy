# edgejs-wcf-proxy
A simple **nodejs** proxy script to call **Wcf** methods using **tcp** and basic **http** binding

Works with nodejs  0.8.x or later (tested with v0.10.33 x64)
##To Use on Linux##
Install **mono**
```sh
sudo apt-key adv --keyserver keyserver.ubuntu.com --recv-keys 3FA7E0328081BFF6A14DA29AA6A19B38D3D831EF
echo "deb http://download.mono-project.com/repo/debian wheezy main" | sudo tee /etc/apt/sources.list.d/mono-xamarin.list
sudo apt-get update
sudo apt-get install  mono-devel
sudo apt-get install  mono-complete
```
