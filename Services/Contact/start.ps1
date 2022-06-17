docker rm --force rscontact
docker-compose -f ".\docker-compose.yml" -f ".\obj\Docker\docker-compose.vs.debug.g.yml" -p rscontact-env build
docker-compose -f ".\docker-compose.yml" -f ".\obj\Docker\docker-compose.vs.debug.g.yml" -p rscontact-env up -d
docker exec -d -i rscontact sh -c ""dotnet"  --additionalProbingPath /root/.nuget/packages  "/app/bin/Debug/net6.0/RunSynopsis.Server.dll" | tee /dev/console"