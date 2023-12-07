# BallestLane Application
 
## Docker Compose
```shell
docker compose up
```
That should be it.

## Dockerfile
Alternatively a SQL Server data base can be setup independently then the connection string must be updated in
**src\BallastLane\appsettings.json**

Then Docker can be built and run
```shell
docker build -t ballast .
docker run -dp 127.0.0.1:8080:8080 ballast
```
