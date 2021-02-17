rm -rf  /home/runner/dotnet
mkdir -p  /home/runner/dotnet
cd /home/runner/dotnet

wget https://download.visualstudio.microsoft.com/download/pr/820db713-c9a5-466e-b72a-16f2f5ed00e2/628aa2a75f6aa270e77f4a83b3742fb8/dotnet-sdk-5.0.100-linux-x64.tar.gz
tar -zxf dotnet-sdk-5.0.100-linux-x64.tar.gz

export DOTNET_ROOT=/home/runner/dotnet
export PATH=$PATH:/home/runner/dotnet


dotnet

bash