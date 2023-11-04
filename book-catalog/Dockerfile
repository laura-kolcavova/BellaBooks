FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /app


COPY ./BellaBooks.BookCatalog.sln ./

COPY ./src/BellaBooks.BookCatalog.Api/BellaBooks.BookCatalog.Api.csproj ./src/BellaBooks.BookCatalog.Api/
COPY ./src/BellaBooks.BookCatalog.Bussiness/BellaBooks.BookCatalog.Bussiness.csproj ././src/BellaBooks.BookCatalog.Bussiness/
COPY ./src/BellaBooks.BookCatalog.Infrastructure/BellaBooks.BookCatalog.Infrastructure.csproj ./src/BellaBooks.BookCatalog.Infrastructure/
COPY ./src/BellaBooks.BookCatalog.Domain/BellaBooks.BookCatalog.Domain.csproj ./src/BellaBooks.BookCatalog.Domain/

# restore dependencies
RUN dotnet restore ./src/BellaBooks.BookCatalog.Api/BellaBooks.BookCatalog.Api.csproj -r linux-x64

# Copy sources and build
COPY ./src ./src/

# build
RUN dotnet publish ./src/BellaBooks.BookCatalog.Api/BellaBooks.BookCatalog.Api.csproj -c Release --no-restore -o out -r linux-x64 --self-contained false /p:PublishSingleFile=true

# Create runtime image
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app

ENV TZ Europe/Prague
EXPOSE 8000
ENV ASPNETCORE_URLS=http://*:8000
# required to enable read only root filesystem
ENV COMPlus_EnableDiagnostics=0

COPY --from=build-env /app/out .
ENTRYPOINT ["./BellaBooks.BookCatalog.Api"]
