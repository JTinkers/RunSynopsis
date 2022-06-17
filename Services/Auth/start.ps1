docker rm --force rsauth
docker-compose -f ".\docker-compose.yml" -f ".\obj\Docker\docker-compose.vs.debug.g.yml" -p rsauth-env build
docker-compose -f ".\docker-compose.yml" -f ".\obj\Docker\docker-compose.vs.debug.g.yml" -p rsauth-env up -d
docker exec -d -i rsauth sh -c ""dotnet"  --additionalProbingPath /root/.nuget/packages  "/app/bin/Debug/net6.0/RunSynopsis.Server.dll" | tee /dev/console"