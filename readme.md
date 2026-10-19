# 📄 Sistema de Gestão de Notas Fiscais

Aplicação Full-Stack para cadastro, listagem, filtragem, ordenação e limpeza de notas fiscais, desenvolvida com backend em **C# .NET 8** e frontend reativo em **Vue.js 3**.

---

## 🛠️ Tecnologias Utilizadas

- **Backend:** C# .NET 8 (Web API)
  - Clean Architecture (Controller, Service, DTO)
  - Mapeamento em memória thread-safe com `ConcurrentBag<T>`
  - Configuração de CORS para integração com o Frontend
  - Testes unitários automatizados com **xUnit**
- **Frontend:** Vue.js 3 (Options API via CDN)
  - Interface reativa sem dependência de build (Single-File HTML)
  - Validações em tempo real e formatação de moeda/data
  - Comunicação assíncrona com a API via `Fetch API`
- **Ambiente de Desenvolvimento:** GitHub Codespaces & CLI .NET

---

## 🚀 Como Executar o Projeto Localmente

### Pré-requisitos
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) instalado.

### 1. Executar a API (Backend)
1. Navegue até a pasta da API:
   ```cmd
   cd NotasApi