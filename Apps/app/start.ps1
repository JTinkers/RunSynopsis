docker rm --force rsapp
docker-compose -p rsapp-env build
docker-compose -p rsapp-env up -d