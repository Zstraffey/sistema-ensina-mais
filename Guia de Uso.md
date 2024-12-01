# SISTEMA DE ESCOLA - Ensina Mais Turma da Mônica

Desenvolvido por
* ***Miguel Zimmermann Martins Silva***
* ***Yslan de Jesus Santos da Costa***
* ***Leonardo Vilela da Silva***
* ***Matheus de Oliveira***

Projeto realizado como trabalho bimestral e atividade final da matéria de Desenvolvimento de Software, ministrado pelos professores: Pedro Ramires da Silva Amalfi e Reginaldo Donizeti Cândido

## Como utilizar o nosso sistema?

Visando solucionar as dúvidas para a utilização de nosso sistema resolvemos criar esse guia prático e rápido, boa leitura!

## Quais Programas eu preciso ter em minha máquina?

* Microsoft .NET Framework Atualizado
* XAMPP (Com o Banco de Dados iniciado)

Estes são os requisitos necessários para o bom funcionamento do programa, abaixo temos explicações sobre suas configurações, usos e etc.

### Microsoft .NET Framework Atualizado

Este programa é essencial para o sistema funcionar, pois utiliza a plataforma .NET Framework, que foi destrinchada melhor em nosso README, então sem ter este programa instalado em seu computador o sistema não irá iniciar

Você pode fazer o downloando atualizado aqui: [.NET Framework](https://dotnet.microsoft.com/pt-br/download/dotnet-framework "Clique Aqui")

Após instalar basta apenas executar o arquivo

### XAMPP - Instalação

XAMPP é um pacote de serviços com os principais servidores de código aberto do mercado, como o FTP, MySQL, e suporte para PHP e Perl. É um sistema livre que vai trablhar com as bases de dados MYSQL, que aqui foi substituído pelo MariaDB, mas claro há também as outras funcionalidades citadas acima, porém para o nosso sistema a funcionalidade crucial é o MariaDB. O nome XAMPP tem a seguinte explicação para fins didáticos: 

* X  - (para qualquer dos diferentes sistemas operativos).
* A - Apache.
* M - MariaDB.
* P - PHP.
* P - Perl.

Você pode fazer o downloando atualizado aqui: [XAMPP](https://www.apachefriends.org/pt_br/index.html "Clique Aqui")

## XAMPP - Configuração

Após instalar o XAMPP e iniciá-lo pela primeira vez, você deve clicar em start que está em frente ao Apache e o Mysql

![Imagem de Exemplo - 1](Guia%20de%20Uso%20-%20Imagens/imagem1%20-%20exemplo.jpg)

Em seguida você deve clicar em Admin que está na frente de MYSQL.

![Imagem de Exemplo - 2](Guia%20de%20Uso%20-%20Imagens/imagem2%20-%20exemplo.jpg)

Assim irá abrir seu navegador padrão, mesmo que você utilize outros navegadores os passos serão os mesmos. Após abrir seu navegador padrão com essa tela inicial você deve clicar em novo, para criar um novo banco de dados.

![Imagem de Exemplo - 1](Guia%20de%20Uso%20-%20Imagens/imagem3%20-%20exemplo.jpg)

Então abrirá essa seguinte tela, aqui você deve digitar **ensina_mais** como nome do banco de dados, caso você digite errado o sistema não funcionará, pois essa referência ao nome é essencial para o seu bom funcionamento

![Imagem de Exemplo - 1](Guia%20de%20Uso%20-%20Imagens/imagem4%20-%20exemplo.jpg)

Após digitar tudo corretamente, clique em criar

![Imagem de Exemplo - 1](Guia%20de%20Uso%20-%20Imagens/imagem5%20-%20exemplo.jpg)

Portanto, certifique-se que o banco de dados ensina_mais está selecionado, caso não esteja selecionado clique em seu nome no menu a esquerda. Em seguida, clique em importar para subir o nosso código .sql do banco de dados

![Imagem de Exemplo - 1](Guia%20de%20Uso%20-%20Imagens/imagem6%20-%20exemplo.jpg)

Logo você deve clicar em escolher arquivo para assim selecionar nosso banco de dados.

![Imagem de Exemplo - 1](Guia%20de%20Uso%20-%20Imagens/imagem7%20-%20exemplo.jpg)

A seguir abrirá esta nova tela de seleção de arquivo, aqui você deve selecionar e clicar em abrir no arquivo ensina_mais.sql, ele está no seguinte caminho: sistema-ensina-mais-main\Projeto Ensina Mais - Banco De Dados Arquivos.

Resumidamente, ele está dentro da pasta Projeto Ensina Mais - Banco de Dados Arquivos.

![Imagem de Exemplo - 1](Guia%20de%20Uso%20-%20Imagens/imagem8%20-%20exemplo.jpg)

Após isto você deve rolar para baixo e apertar em importar, ou dar o seguinte comando `CNTRL` + `ENTER`

![Imagem de Exemplo - 1](Guia%20de%20Uso%20-%20Imagens/imagem9%20-%20exemplo.jpg)

Pronto! Caso você tenha seguido todos os passos corretamente a última tela deve ser esta abaixo, agora com tudo tudo configurado você já pode iniciar o executável: 

Projeto Ensina Mais.exe - Atalho

Que se encontra na pasta principal, como primeira entrada você deve utilizar o seguinte usuário:

Código de Funcionário: adm
Senha: 123
