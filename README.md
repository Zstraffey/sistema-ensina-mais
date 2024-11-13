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

Requisitos não funcionais são os requisitos que estarão ligados com o uso da aplicação, sendo em termos de segurança, facilidades, manutenção e tecnologias envolvidas. Estes requisitos dizem respeito a como as funcionalidades serão entregues ao usuário do software.

> Otimização e compatibilidade com dispositivos de baixo hardware.

Mínimos:

SO: Windows 10

Processador: 1 GHz

Memória Ram: 1 GB

Armazenamento: 200MB

Acesso à Internet

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


## Descrição do banco de dados em modelo Físico

### 1. **Tabelas de Entidade Principal**
   Essas tabelas representam as entidades principais da aplicação, como `Usuario`, `Aluno`, `Responsavel`, `Matricula`, etc. Vou abordar como os tipos de dados estão configurados para cada uma.

   #### **Tabela: `Usuario`**
   - **Campos principais**: `userId`, `codFunc`, `senha`, `nome`, `email`, `cpf`, `rg`, etc.
   - **Tipos de dados**:
     - **`INT` (Auto-increment)**: Para o `userId`, que é uma chave primária, usamos o tipo `INT` com a opção `AUTO_INCREMENT`. Isso garante que o sistema gerará automaticamente um identificador único para cada usuário.
     - **`VARCHAR`**: O tipo `VARCHAR` é utilizado para campos de texto como `codFunc`, `nome`, `senha`, `email`, etc. Esse tipo é ideal para armazenar texto com comprimento variável. Por exemplo, `nome` é limitado a 50 caracteres, enquanto `email` pode ter até 100 caracteres.
     - **`DATE`**: Usado para a data de nascimento (`data_nasc`). Este tipo de dado armazena uma data no formato 'YYYY-MM-DD'.
     - **`FLOAT`**: Usado para valores numéricos que podem ter casas decimais, como o campo `pagamento` (provavelmente referente ao salário do usuário ou comissão).
     - **`TEXT`**: Para campos de maior volume de texto, como `pfp`, que pode armazenar uma URL ou descrição da foto do perfil.

   A tabela `Usuario` contém informações essenciais sobre os usuários da plataforma, incluindo identificação, permissões e dados pessoais. O uso de `VARCHAR` e `TEXT` permite flexibilidade no armazenamento de informações textuais, enquanto `DATE` e `FLOAT` são apropriados para tipos de dados mais específicos.

   #### **Tabela: `Aluno`**
   - **Campos principais**: `alunoId`, `nome`, `data_nasc`, `rg`, `data_mat`, etc.
   - **Tipos de dados**:
     - **`INT` (Auto-increment)**: Assim como na tabela `Usuario`, o `alunoId` é uma chave primária com `AUTO_INCREMENT`.
     - **`VARCHAR`**: Para armazenar informações textuais como o `nome` do aluno e o `rg`.
     - **`DATE`**: Para armazenar datas de nascimento (`data_nasc`) e matrícula (`data_mat`).

   A tabela `Aluno` armazena dados sobre os estudantes. O uso de `DATE` para datas e `VARCHAR` para dados textuais segue a mesma lógica da tabela `Usuario`.

### 2. **Relacionamentos Entre as Tabelas**
   As tabelas de relacionamento são usadas para vincular dados de diferentes tabelas. Elas geralmente utilizam chaves estrangeiras (`FOREIGN KEY`), que garantem a integridade referencial entre as tabelas.

   #### **Tabela: `matUsuario`**
   - **Campos principais**: `fk_Usuario_userId`, `fk_Matricula_matId`
   - **Tipos de dados**:
     - **`INT`**: A tabela `matUsuario` conecta a tabela `Usuario` com a tabela `Matricula`. Ambas as chaves estrangeiras (`fk_Usuario_userId` e `fk_Matricula_matId`) são do tipo `INT` e se referem a chaves primárias em outras tabelas.
   
  A tabela `matUsuario` serve para registrar a relação entre um usuário e uma matrícula. Ela utiliza o tipo `INT` para as chaves estrangeiras, que são associadas a identificadores exclusivos de outras tabelas (no caso, `Usuario` e `Matricula`).

   #### **Tabela: `respAluno`**
   - **Campos principais**: `fk_Aluno_alunoId`, `fk_Responsavel_respId`
   - **Tipos de dados**:
     - **`INT`**: As chaves estrangeiras `fk_Aluno_alunoId` e `fk_Responsavel_respId` são do tipo `INT`, referenciando respectivamente as tabelas `Aluno` e `Responsavel`.
   
  A tabela `respAluno` estabelece um relacionamento entre alunos e seus responsáveis. Ao usar `INT` para as chaves estrangeiras, o banco de dados mantém a integridade dos dados e permite que um aluno possa ter um ou mais responsáveis cadastrados.

   #### **Tabela: `cadastraProduto`**
   - **Campos principais**: `fk_Usuario_userId`, `fk_Produtos_prodId`
   - **Tipos de dados**:
     - **`INT`**: A tabela `cadastraProduto` usa chaves estrangeiras `fk_Usuario_userId` e `fk_Produtos_prodId` para associar usuários a produtos cadastrados.
   
  A tabela `cadastraProduto` relaciona usuários (provavelmente administradores ou vendedores) a produtos que foram registrados na plataforma. O uso de `INT` para as chaves estrangeiras segue o padrão de criação de vínculos entre tabelas.

### 3. **Aulas e Matrículas**
   As tabelas `Aulas` e `Matricula` têm um papel central no gerenciamento de cursos e aulas, e os tipos de dados são usados de forma a refletir o conteúdo dessas atividades.

   #### **Tabela: `Aulas`**
   - **Campos principais**: `aulaId`, `data_aula`, `horario`, `curso`, `tema`, `prof1`, `prof2`
   - **Tipos de dados**:
     - **`INT`**: Para a chave primária `aulaId`, que é auto-incrementada.
     - **`DATE` e `TIME`**: Usados para armazenar a data da aula (`data_aula`) e o horário (`horario`), respectivamente.
     - **`VARCHAR`**: Para armazenar o nome do curso e o tema da aula, ambos como textos curtos.
   
  As aulas têm datas e horários definidos, portanto, `DATE` e `TIME` são os tipos de dados ideais para essas informações. `VARCHAR` é adequado para armazenar o nome do curso e o tema, que podem variar em tamanho.

### 4. **Definição de Relacionamentos e Integridade Referencial**
   O uso de **chaves estrangeiras** (`FOREIGN KEY`) nas tabelas, como `FK_cadastraUsuario_1`, `FK_respAluno_1`, entre outras, assegura que as tabelas estejam interligadas de forma consistente.

   - **Restrição de Exclusão (`ON DELETE RESTRICT`)**: Impede a exclusão de um registro em uma tabela se houver dados dependentes nas tabelas relacionadas. Exemplo: um aluno não pode ser excluído se houver uma matrícula associada a ele.
   - **Exclusão em Cascata (`ON DELETE CASCADE`)**: Exclui automaticamente os registros dependentes quando o registro principal é excluído. Exemplo: quando um usuário é removido, todas as suas relações em `cadastraUsuario` também serão excluídas.
   - **Definir como Nulo (`ON DELETE SET NULL`)**: Quando a entidade relacionada é excluída, o campo correspondente na tabela de relacionamento é configurado para `NULL`. Exemplo: se uma matrícula for removida, o campo `fk_Matricula_matId` na tabela `matUsuario` é definido como `NULL`.
