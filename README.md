BookRoom: Sistema de Empréstimos de Livros 📚

BookRoom é uma solução de gerenciamento de empréstimos de livros, O sistema foi projetado para ser eficiente, escalável e de fácil manutenção. Abaixo estão as principais funcionalidades e tecnologias utilizadas.
Funcionalidades:
Empréstimo de Livros:

    Um usuário pode pegar apenas 1 livro emprestado por vez.

Período de Empréstimo:

    O usuário pode configurar o período do empréstimo, com um limite de até 7 dias.

Cálculo Automático da Data de Retorno:

    A data de retorno do livro é calculada automaticamente com base no número de dias do empréstimo.

Atualização Parcial de Estoque (PATCH):

    A quantidade de livros no estoque pode ser ajustada sem alterar outros dados do livro, como título e autor.

Controle de Empréstimos Ativos:

    O sistema impede que um usuário faça novos empréstimos enquanto já tenha um empréstimo ativo.

Verificação de Disponibilidade de Livros:

    O sistema verifica se o livro está disponível (não marcado como "Indisponível") antes de realizar o empréstimo.

Padrões e Arquitetura:

    Arquitetura Limpa (Clean Architecture): Seguindo os princípios de separação de responsabilidades, garantindo que a lógica de negócio, dados e interface com o usuário estejam desacoplados.
    IUnitOfWork & Padrão Repository: Para abstração de acesso a dados e controle de transações.
    ASP.NET Core & Entity Framework Core: Usados para a construção da API e persistência de dados.
    Swagger/OpenAPI & MediatR: Para documentação da API e processamento de requisições.
    Padrões RESTful & DTOs: Seguindo as melhores práticas de APIs RESTful e usando DTOs para controle de dados expostos.
    Async/await: Para otimização de desempenho.

Tecnologias Usadas:

    .NET 8: Para a construção da API e implementação da lógica de negócios.
    SQL Server (ou outro banco de dados relacional): Para persistência dos dados.
    Swagger/OpenAPI: Para documentação interativa da API.
    MediatR: Para implementação do padrão CQRS e centralização da lógica de processamento das requisições.
