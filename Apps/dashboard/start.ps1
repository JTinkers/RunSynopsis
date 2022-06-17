docker rm --force rsdashboard
docker-compose -p rsdashboard-env build
docker-compose -p rsdashboard-env up -d