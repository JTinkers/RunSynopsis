docker rm --force rsstorage
docker-compose -f "docker-compose.yml" -f "obj\Docker\docker-compose.vs.debug.g.yml" -p rsstorage-env build
docker-compose -f "docker-compose.yml" -f "obj\Docker\docker-compose.vs.debug.g.yml" -p rsstorage-env up -d
docker exec -d -i rsstorage sh -c ""dotnet"  --additionalProbingPath /root/.nuget/packages  "/app/bin/Debug/net6.0/RunSynopsis.Server.dll" | tee /dev/console" -d