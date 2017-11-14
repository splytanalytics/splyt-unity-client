#!/bin/bash

wget -nc https://dist.nuget.org/win-x86-commandline/latest/nuget.exe
chmod +x nuget.exe
./nuget.exe install vendor/packages.config -o vendor/

cp vendor/RestSharp-Unity-NET-2.0.105.1/lib/net20/RestSharp.dll Assets/Plugin/
cp vendor/Unity.Newtonsoft.Json.7.0.0.0/lib/net35-Client/Unity.Newtonsoft.Json.dll Assets/Plugin/
rm Assets/ThirdParty/KnetikCloud/Client/Configuration.cs
