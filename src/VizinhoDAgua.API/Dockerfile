# Dockerfile para AWS Lambda (.NET 9)
# Este Dockerfile é para build local. Para deployment real, use: dotnet lambda deploy-function

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copia csproj files e restaura dependências
COPY ["src/VizinhoDAgua.API/VizinhoDAgua.API.csproj", "src/VizinhoDAgua.API/"]
COPY ["src/VizinhoDAgua.Application/VizinhoDAgua.Application.csproj", "src/VizinhoDAgua.Application/"]
COPY ["src/VizinhoDAgua.Domain/VizinhoDAgua.Domain.csproj", "src/VizinhoDAgua.Domain/"]
COPY ["src/VizinhoDAgua.Infrastructure/VizinhoDAgua.Infrastructure.csproj", "src/VizinhoDAgua.Infrastructure/"]
COPY ["VizinhoDAgua.ServiceDefaults/VizinhoDAgua.ServiceDefaults.csproj", "VizinhoDAgua.ServiceDefaults/"]

RUN dotnet restore "src/VizinhoDAgua.API/VizinhoDAgua.API.csproj"

# Copia tudo e publish
COPY . .
WORKDIR "/src/src/VizinhoDAgua.API"
RUN dotnet publish "VizinhoDAgua.API.csproj" \
    -c Release \
    -o /app/publish

# Para produção, use Container Image com Lambda
FROM public.ecr.aws/lambda/dotnet:9
WORKDIR /var/task
COPY --from=build /app/publish .
# For .NET 9 with AddAWSLambdaHosting(LambdaEventSource.HttpApi),
# use the assembly entry point. The Program.cs Main method is the entry point.
# Handler format: AssemblyName::Namespace.Class::Method
CMD ["VizinhoDAgua.API::LambdaEntryPoint::FunctionHandlerAsync"]

