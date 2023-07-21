# sqs-customers-api
<h1> API que tem como objetivo o CRUD de um  de Usuário com persistência nos serviços da Amazon como DynamobDB como banco NOSQL 
  e serviços como publicação em fila SQS </h1>

  <h3> O projeto foi desenvolvido aplicando conceitos como:</h3>
  
  * Domain Driven Design
  * CQRS
  * Princípios SOLID
  * Orientação a Objetos
  * Design Patterns 

# Com esse projeto tive o prazer de aprender sobre as tecnologias da Amazon tais como:
  * Aws DynamoDB
  * Aws SQS
  * Aws SNS
  * Aws S3
  * AWS Secrets Manager
  * AWS Lambda
    
# Também a utilizar essas tecnologias em cenários como: 
* Aws SQS => Como criar uma fila, criar uma mensagem, criar um consumidor de mensagem, lidar com dead-letters e criar uma fila pra isso, redirecionar dead-letters
* Aws SNS => Criar tópicos em SNS, criar um consumidor e publicador de mensagem, consumir a mensagem em multiplos apps
* Aws DynamoDB =>  O que são Partition Key e Sort Key, criando tabelas no DynamoDB, implementando acesso ao DynamoDB, criar transações, streams e autoscaling
* AWS S3 => Upload de arquivos usando C#, Download e processamento de arquivos usando o c#, implementações de retentativas
* AWS Secrets Manager => Criando segredos, lendo segredos em c#, versões de segredos, lidando com rotação de segredos
* AWS Lambda => O que é um serverless e lambda, criação lambda, conceitos de triggers e destinations, debugando lambdas localmente, consumindo filas SQS usando lambda, consumindo tópicos SNS usando lambda, triggering lambda com DynamoDB, triggering lambda com S3, convertendo uma API em uma AWS Lambda

Esse projeto tem em conjunto outros projetos que foram desenvolvidos, todos fazem parte do mesmo escopo. 
São eles: 
 * https://github.com/Gondlir/sqs-publisher
 * https://github.com/Gondlir/sqs-consumer
 * https://github.com/Gondlir/sns-publisher
 * https://github.com/Gondlir/aws-lambda
