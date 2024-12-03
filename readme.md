
## Descri��o

Este projeto � uma aplica��o desenvolvida com ASP.NET Core, Entity Framework, SqlServer e Docker que permite conteineriza��o e execu��o com com apenas um comando.

Esse � um teste para empresa EclipseWorks, onde � feita uma APIRest que geri rela� entre usu�rio, projeto e tarefas

## Pr�-requisitos

Antes de come�ar, certifique-se de que voc� tem os seguintes itens instalados em seu sistema:

- [Docker](https://www.docker.com/get-started) (vers�o 20.10 ou superior)
- [Docker Compose](https://docs.docker.com/compose/install/) (vers�o 1.27 ou superior)

Certifique-se de que o Docker est� em execu��o.
Execute o seguinte comando para construir e iniciar os cont�ineres:
	
	docker-compose up --build

Ap�s a inicializa��o, a aplica��o estar� dispon�vel em um navegador. Voc� pode acess�-la atrav�s do seguinte endere�o:

	http://localhost:8080

Nota: A porta 8080 pode ser alterada no arquivo docker-compose.yml, ent�o, se voc� fizer altera��es, ajuste a URL conforme necess�rio.

Fase 2: Refinamento:

P: O que voc� perguntaria para o *PO* visando o refinamento para futuras implementa��es ou melhorias.
R: Implementar autentica��o e autoriza��o para poder implementar sistemas de hierarquia (roles) mais conciso, assim limitando certas a��es para certos tipos de n�vel hierarquicos de usu�rios.

Implementar valida��o de dados na API para garantir que as regras de neg�cio estejam sendo aplicadas

Fase 3: Final 
P: O que voc� melhoraria no projeto, identificando poss�veis pontos de melhoria, implementa��o de padr�es, vis�o do projeto sobre arquitetura/cloud, etc.
R: Se a vis�o do projeto � escalar, implementaria o padr�o CQRS para melhor escalabilidade horizontal, mesmo adicionando uma camada de dificuldade a mais, seria importante para manter a aplica��o de maneira limpa e efici�nte

Por ja possuir o Padr�o 'Repository' a aplica��o do padr�o CQRS se torna mais simples, por quest�o de desacopla��o de c�digo.

Acredito que hospedar em servi�o de nuvem vai eventualmente acontecer, recomendaria Azure devops por ser mais simples de trabalhar e mais amig�vel para o usu�rio m�dio n�o gastar recursos com tencologias que n�o compreende
Implementa��o de CI/CD ajudar muito a amenizar o problema acima, pois evita de atualizar a pipeline com uma atualiza��o quebrada ap�s completar o pull request, onde economiza o uso de agents que reali��o a atualiza��o do container na hospedagem