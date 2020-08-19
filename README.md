# WebMotors-Challenge

Bem-vindo ao teste pratico de back-end Webmotors.
Reserve 3 horas para realização do teste, após aplicação do teste você tem até 24 horas para
envio do seu projeto.
Testes enviados com o prazo maior do que esse serão desconsiderados.
É obrigatório o uso do visual studio e utilização de um banco de dados relacional local para
execução desse teste.
O teste consiste na criação de um anuncio na Webmotors utilizando uma aplicação WEB em
.NET.
A avaliação consiste em como será feita a arquitetura do seu código, funcionamento e
qualidade geral da aplicação.
Temos 2 pontos de desafio propostos:
1. Manipulação de dados no banco de dados
2. Consumo de API
Para isso é necessário criar a seguinte estrutura no seu banco de dados local:
create database teste_webmotors
go --apenas MSSQL
create table teste_webmotors..tb_AnuncioWebmotors(
ID INT identity not null,
marca varchar (45) not null,
modelo varchar (45) not null,
versao varchar (45) not null,
ano INT not null,
quilometragem INT not null,
observacao text not null
)
Para a consulta de marcas, modelos e versões, deve-se utilizar o seguinte endereço:
http://desafioonline.webmotors.com.br/swagger/ui/index#/OnlineChallenge
O objetivo do teste é chegar em uma tela básica de crud de anúncios, onde
seja possível:
• Incluir
• Atualizar
• Consultar
• Remover 
anúncios da tabela com consumo das informações de marca, modelo e versão
via webservice.
Front-end é opcional para avaliação desse teste, não sendo obrigatório. Apenas uma tela em
HTML já é o necessário.
Após a conclusão do seu projeto submeta em formato .zip no endereço
http://desafioonline.webmotors.com.br/Home/Cadastrar
