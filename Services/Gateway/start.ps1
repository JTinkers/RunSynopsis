docker rm --force rsgateway
docker-compose -f "docker-compose.yml" -f "obj\Docker\docker-compose.vs.debug.g.yml" -p rsgateway-env build
docker-compose -f "docker-compose.yml" -f "obj\Docker\docker-compose.vs.debug.g.yml" -p rsgateway-env up -d
docker exec -d -i rsgateway sh -c ""dotnet"  --additionalProbingPath /root/.nuget/packages  "/app/bin/Debug/net6.0/RunSynopsis.Server.dll" | tee /dev/console"