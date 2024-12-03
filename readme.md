
## Descrição

Este projeto é uma aplicação desenvolvida com ASP.NET Core, Entity Framework, SqlServer e Docker que permite conteinerização e execução com com apenas um comando.

Esse é um teste para empresa EclipseWorks, onde é feita uma APIRest que geri relaç entre usuário, projeto e tarefas

## Pré-requisitos

Antes de começar, certifique-se de que você tem os seguintes itens instalados em seu sistema:

- [Docker](https://www.docker.com/get-started) (versão 20.10 ou superior)
- [Docker Compose](https://docs.docker.com/compose/install/) (versão 1.27 ou superior)

Certifique-se de que o Docker está em execução.
Execute o seguinte comando para construir e iniciar os contêineres:
	
	docker-compose up --build

Após a inicialização, a aplicação estará disponível em um navegador. Você pode acessá-la através do seguinte endereço:

	http://localhost:8080

Nota: A porta 8080 pode ser alterada no arquivo docker-compose.yml, então, se você fizer alterações, ajuste a URL conforme necessário.

Fase 2: Refinamento:

P: O que você perguntaria para o *PO* visando o refinamento para futuras implementações ou melhorias.
R: Implementar autenticação e autorização para poder implementar sistemas de hierarquia (roles) mais conciso, assim limitando certas ações para certos tipos de nível hierarquicos de usuários.

Implementar validação de dados na API para garantir que as regras de negócio estejam sendo aplicadas

Fase 3: Final 
P: O que você melhoraria no projeto, identificando possíveis pontos de melhoria, implementação de padrões, visão do projeto sobre arquitetura/cloud, etc.
R: Se a visão do projeto é escalar, implementaria o padrão CQRS para melhor escalabilidade horizontal, mesmo adicionando uma camada de dificuldade a mais, seria importante para manter a aplicação de maneira limpa e eficiênte

Por ja possuir o Padrão 'Repository' a aplicação do padrão CQRS se torna mais simples, por questão de desacoplação de código.

Acredito que hospedar em serviço de nuvem vai eventualmente acontecer, recomendaria Azure devops por ser mais simples de trabalhar e mais amigável para o usuário médio não gastar recursos com tencologias que não compreende
Implementação de CI/CD ajudar muito a amenizar o problema acima, pois evita de atualizar a pipeline com uma atualização quebrada após completar o pull request, onde economiza o uso de agents que realição a atualização do container na hospedagem