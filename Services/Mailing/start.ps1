docker rm --force rsmailing
docker-compose -f "docker-compose.yml" -f "obj\Docker\docker-compose.vs.debug.g.yml" -p rsmailing-env build
docker-compose -f "docker-compose.yml" -f "obj\Docker\docker-compose.vs.debug.g.yml" -p rsmailing-env up -d
docker exec -d -i rsmailing sh -c ""dotnet"  --additionalProbingPath /root/.nuget/packages  "/app/bin/Debug/net6.0/RunSynopsis.Server.dll" | tee /dev/console" -d