FROM alpine:latest

WORKDIR /app

COPY bin/Debug/net6.0 /app

RUN apk add aspnetcore6-runtime

EXPOSE 5003

CMD ["dotnet", "VLSMAPI.dll"] 