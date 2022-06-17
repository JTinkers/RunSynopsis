docker rm --force rscontent
docker-compose -f "docker-compose.yml" -f "obj\Docker\docker-compose.vs.debug.g.yml" -p rscontent-env build
docker-compose -f "docker-compose.yml" -f "obj\Docker\docker-compose.vs.debug.g.yml" -p rscontent-env up -d
docker exec -d -i rscontent sh -c ""dotnet"  --additionalProbingPath /root/.nuget/packages  "/app/bin/Debug/net6.0/RunSynopsis.Server.dll" | tee /dev/console"