# Entidades do Sistema

## User
Representa o usuário da aplicação.

| Campo           | Tipo                | Descrição                            |
|-----------------|---------------------|--------------------------------------|
| id              | int / Guid          | Identificador único do usuário.      |
| name            | string              | Nome completo do usuário.            |
| email           | string              | Endereço de e-mail.                  |
| isAdmin         | bool                | Define se o usuário é administrador. |
| password        | string              | Senha criptografada.                 |
| profileImage    | string (URL)        | Caminho ou link da imagem de perfil. |
| communities     | List<Community>     | Comunidades em que o usuário participa. |

---

## Report
Representa uma denúncia ou relatório feito por um usuário.

| Campo         | Tipo           | Descrição                                    |
|----------------|----------------|----------------------------------------------|
| id             | int / Guid     | Identificador único do relatório.            |
| reporter       | User           | Usuário que enviou o relatório.              |
| description    | string         | Descrição detalhada do ocorrido.             |
| status         | string / enum  | Situação atual do relatório (ex: aberto, resolvido). |
| reportType     | string / enum  | Tipo de denúncia (ambiental, segurança, etc). |
| location       | Location       | Localização associada (CEP, cidade, etc).    |
| attachments    | List<string>?  | Links ou caminhos de anexos (opcional).      |

---

## Location
Define uma localização geográfica.

| Campo         | Tipo         | Descrição                           |
|----------------|--------------|-------------------------------------|
| city           | string       | Cidade.                             |
| road           | string?      | Rua (opcional).                     |
| postalCode     | string?      | Código postal (CEP).                |
| neighborhood   | string?      | Bairro (opcional).                  |
| state          | string       | Estado.                             |
| coords         | string?      | Coordenadas geográficas (opcional). |

---

## Community
Representa uma comunidade de usuários.

| Campo         | Tipo         | Descrição                         |
|----------------|--------------|-----------------------------------|
| id             | int / Guid   | Identificador único da comunidade. |
| title          | string       | Título ou nome da comunidade.     |
| description    | string       | Descrição geral.                  |
| coverImage     | string       | Imagem de capa.                   |

---

## CommunityPost
Representa uma publicação feita em uma comunidade.

| Campo         | Tipo              | Descrição                        |
|----------------|-------------------|----------------------------------|
| id             | int / Guid        | Identificador único do post.     |
| author         | User              | Autor do post.                   |
| communityId    | Community         | Comunidade onde foi postado.     |
| content        | string            | Texto principal do post.         |
| images         | List<string>      | Lista de imagens associadas.     |

---

## EducationContent
Representa um conteúdo educacional da plataforma.

| Campo         | Tipo           | Descrição                               |
|----------------|----------------|-----------------------------------------|
| id             | int / Guid     | Identificador único do conteúdo.        |
| title          | string         | Título do material.                     |
| image          | string         | Imagem de capa.                         |
| author         | User           | Autor do conteúdo.                      |
| contentType    | string / enum  | Tipo (artigo, vídeo, guia, etc).        |
