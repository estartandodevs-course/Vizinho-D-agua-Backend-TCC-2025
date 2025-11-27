# 🌊 Vizinho D'Água API

API do projeto **Vizinho D'Água**, voltada para gestão de denúncias, conteúdos educacionais e alertas relacionados a problemas de abastecimento de água.

O projeto segue o padrão **Clean Architecture** com **DDD + CQRS**, separando claramente domínio, aplicação e infraestrutura.

---

## 🚀 Principais Features

- **📣 Gestão de Alertas**
  - Criação automática de alertas a partir de denúncias agrupadas por localidade.
  - Preenchimento automático de endereço via CEP (Integração com ViaCEP).
  - Controle de status: Em verificação, Verificado, Descartado, Oficial.


- **📝 Gestão de Denúncias**
  - Criar, editar e consultar denúncias.
  - Encaminhamento automático para órgãos competentes após processamento.
  - Agrupamento por localidade para gerar alertas.


- **📚 Conteúdos Educacionais**
  - CRUD de conteúdos educativos com diferentes categorias.
  - Acesso direto do menu principal.


- **🔔 Notificações**
  - Disparo automático com base no status de alertas ou informes oficiais.
  - Usuários recebem notificações filtradas por localidade.


- **🛠 Integrações Externas**
  - ViaCEP para busca de endereço a partir do CEP.


- **📄 Documentação Interativa**
  - Swagger disponível para teste de todos os endpoints.
  - Acessível em `http://localhost:5000/swagger` quando rodando localmente.

---

## 💻 Tecnologias Utilizadas

- **.NET 9** com C#
- **Entity Framework Core** para ORM e migrações
- **MySQL** como banco de dados
- **MediatR** para CQRS
- **AutoMapper** para mapeamento de DTOs
- **FluentValidation** para validação de requisições
- **HttpClient** para integração com APIs externas
- **Swagger / Swashbuckle** para documentação interativa

---

## ⚙️ Rodando a API Localmente

1. Clone o repositório:
   ```bash
    git clone https://github.com/estartandodevs-course/Vizinho-D-agua-Backend-TCC-2025
    cd Vizinho-D-agua-Backend-TCC-2025
   ```
2. Configure a connection string no appsettings.json da API:
   ```json
    "ConnectionStrings": {
      "DefaultConnection": "Server=<host>;Port=<porta>;Database=<nome>;User Id=<usuario>;Password=<senha>;SslMode=Preferred;"
    }
   ```
3. Instale as dependências:
   ```bash
    dotnet restore
   ```
4. Execute as migrações para criar o banco de dados:
   ```bash
    dotnet ef database update --startup-project ./src/VizinhoDAgua.API
   ```
5. Rode a API:
   ```bash
    dotnet run --project ./src/VizinhoDAgua.API
   ```
6. Acesse a documentação Swagger:
   ```bash
    http://localhost:5000/swagger
   ```

## 📂 Estrutura de Pastas
```
src/
├─ VizinhoDAgua.API/             -> Projeto principal da API
├─ VizinhoDAgua.Application/     -> Lógica de negócio, Commands e Queries (Use Cases)
├─ VizinhoDAgua.Domain/          -> Entidades, Value Objects e DTOs
├─ VizinhoDAgua.Infrastructure/  -> Repositórios, Contexto EF Core e Services externos

```
