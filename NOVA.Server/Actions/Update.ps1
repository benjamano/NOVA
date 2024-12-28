# C# Backend
echo "Building backend..."
dotnet restore ../NOVAServer.csproj
dotnet build --configuration Release ../NOVAServer.csproj
dotnet publish ../NOVAServer.csproj -c Release -o /var/www/backend

dotnet restore ../../nova.data/NOVAData.csproj
dotnet build --configuration Release ../../nova.data/NOVAData.csproj
dotnet publish ../../nova.data/NOVAData.csproj -c Release -o /var/www/backend

# React Frontend
echo "Building frontend..."
cd ../../nova.client
npm install
npm run build
cp -Recurse -Force ./dist /var/www/backend/wwwroot