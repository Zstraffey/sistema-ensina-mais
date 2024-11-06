# SISTEMA DE ESCOLA - Ensina Mais Turma da Mônica

Desenvolvido por
* ***Miguel Zimmermann Martins Silva***
* ***Yslan de Jesus Santos da Costa***
* ***Leonardo Vilela da Silva***
* ***Matheus de Oliveira***

Projeto realizado como trabalho bimestral e atividade final da matéria de Desenvolvimento de Software, ministrado pelos professores: Pedro Ramires da Silva Amalfi e Reginaldo Donizeti Cândido

## SISTEMA DE ESCOLA

## PROBLEMA

Os integrantes desse grupo verificaram uma defasagem no sistema já existente da escola, por se tratar de uma franquia, a franqueadora não se mobilizava de forma efetiva, com suas outras escolas e administração interna.

## JUSTIFICATIVA

Sendo assim o novo sistema proposto, tem como meta melhorar a eficácia, rapidez, e gestão de recursos da escola, partindo desde a parte do cliente, até o segmento de funcionários. 

## INTRODUÇÃO

Não é de hoje que muitas plataformas físicas buscam por trazer o físico para o digital, como melhor forma de administrar os recursos, visando uma gestão fácil e prática. Assim o nosso sistema vai se tratar de uma administração clássica, com CRUD que são as quatro operações básicas de qualquer aplicação (CREATE, READ, UPDATE, DELETE), trazendo para o português, (CRIAR, LER, ATUALIZAR e REMOVER), sendo isso em diversos âmbitos como na questão de funcionários ou clientes.

## LINGUAGEM

Para este projeto foi proposto a utilização da linguagem C#, uma linguagem de programação, multiparadigma (que são linguagens que aceitam diversos paradigmas de programação, paradigmas de programação são por exemplo se ela é voltada a eventos ou se é voltada para objetos, ou, voltada para modelos lógicos ou funcionais), de tipagem forte (não realizam conversões automaticamente, por exemplo não concatena um tipo de dado textual com um valor inteiro), desenvolvida pela Microsoft como parte da plataforma .NET, que é uma plataforma de desenvolvimento e execução para sistemas e aplicações, podendo ser executada em sistemas que também comportem o .NET FRAMEWORK. Esta linguagem comportará perfeitamente nosso sistema pois traz desde recursos básicos, até recursos mais avançados como herança, orientação a objetos, classes.

## Requisitos Funcionais :hammer:

Os requisitos funcionais representam o que o software faz, sendo desde tarefas a serviços. Sendo basicamente um conjunto de entradas do usuário, seu comportamento dentro do sistema e as saídas, respostas que o software dará ao utilizador.

> CRUD de Funcionários

Criar, Ler, Alterar e Remover dados de funcionários, com todas essas ações estando dentro da Lei Geral de Proteção de Dados Pessoais (LGPD) que vai tratar do tratamento de dados pessoais de pessoas naturais, marcando quando esses dados podem ser colhidos, como devem ser armazenados e decretando mecanismo para proteger os titulares dos dados.

> CRUD de Alunos

Criar, Ler, Alterar e Remover dados de alunos, por se tratar de um sistema de franqueadora não é necessário a guarda permanente que um tipo de guarda de dados de crianças ou adolescentes, ou a documentos que devem ser preservados por tempo indeterminado.

> CRUD de Produtos

Criar, Ler, Alterar e Remover dados de produtos, na qual a matriz local da franqueadora distribui.

> CRUD de Cursos

Criar, Ler, Alterar e Remover dados dos cursos presente na matriz local.

> CRUD de Cargos

Criar, Ler, Alterar e Remover dados de Cargos da matriz local.

> Nível de Usuário: Professor

 O professor tem acesso a as aulas para pode então realizar seu CRUD

> Nível de Usuário: Administrador

O administrador tem acesso a todos as partes constituintes do sistema, podendo realizar todas as funções lá presentes. Com este nível de usuário podendo ser utilizado também pela gestão da escola.

> Nível de Usuário: Secretária (Recepção)

A secretária da escola tem acesso ao CRUD de alunos e produtos.

> Separação de acesso aos sistemas com base no nível de usuário

Através de uma resposta do banco de dados, nosso sistema irá encaminhar o usuário para sua determinada área após realizar o login

## Requisitos Não Funcionais :black_nib:

Requisitos não funcionais são os requisitos que estarão ligados com o uso da aplicação, sendo em termos de segurança, facilidades, manuntenção e tecnologias envolvidas. Estes requisitos dizem respeito a como as funcionalidades serão entregues ao usuário do software.

> Otimização e compatilibidade com dispositivos de baixo hardware.

Mínimos:

SO: Windows 10

Processador: 1 GHz

Memória Ram: 1 GB

Armazenamento: 200MB

Acesso a Internet

## História de Usuário :mega:

### Como Administrador:

Posso Cadastrar, Visualizar, Alterar, Excluir Funcionários
> Para adicionar empregados no sistema, realizar consultas aos dados, editar os dados caso surja necessidade, e remover empregados que já não fazem mais parte da matriz local

Posso Cadastrar, Visualizar, Alterar, Excluir Alunos		 
> Para adicionar alunos no sistema, realizar consultas aos dados, editar os dados caso surja necessidade, e remover alunos que já não fazem mais parte da matriz local

Posso Cadastrar, Visualizar, Alterar, Excluir Produtos Comercializáveis
> Para adicionar produtos no sistema, realizar consultas aos dados, editar os dados caso surja necessidade, e remover produtos que já não fazem mais parte da matriz local

Posso Cadastrar, Visualizar, Alterar, Excluir Cursos
> Para adicionar os cursos da matriz local, visualizar os cursos que foram cadastrados para analisar se as informações estão corretas, igualmente podendo editar e excluir cursos, caso haja necessidade

Posso Cadastrar, Visualizar, Alterar, Excluir Cargos
> Para adicionar os cargos da matriz local, visualizar os cargos que foram cadastrados para analisar se as informações estão corretas, igualmente podendo editar e excluir cargos, caso haja necessidade

Posso Cadastrar, Visualizar, Alterar, Excluir Aulas
> Para atualizar as aulas dos professores caso haja necessidade, também podendo visualizar as aulas que foram sendo adicionadas no sistema e por fim alterando ou excluindo as aulas de acordo com as demandas

### Como Professor: 

Posso Cadastrar, Visualizar, Alterar, Excluir Aulas
> Para adicionar as aulas que lecionei, além disso posso visualizá-las em busca de possíveis erros, consequentemente podendo alterá-las caso necessário, ou excluí-las

### Como Secretaria: 

Posso Cadastrar, Visualizar, Alterar, Excluir Produtos Comercializáveis
> Para adicionar produtos no sistema, realizar consultas aos dados, editar os dados caso surja necessidade, e remover produtos que já não fazem mais parte da matriz local

Posso Cadastrar, Visualizar, Alterar, Excluir Alunos		 
> Para adicionar alunos no sistema, realizar consultas aos dados, editar os dados caso surja necessidade, e remover alunos que já não fazem mais parte da matriz local

