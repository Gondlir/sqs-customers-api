# sqs-customers-api
<h1> API that aims the CRUD of a User with persistence in Amazon services like DynamoDB database and services like SQS queue publishing </h1>

  <h3> The project was developed applying concepts such as:</h3>
  
  * Domain Driven Design
  * CQRS
  * SOLID Principles
  * POO
  * Design Patterns 

# With this project I had the pleasure of learning about Amazon technologies such as:
  * Aws DynamoDB
  * Aws SQS
  * Aws SNS
  * Aws S3
  * AWS Secrets Manager
  * AWS Lambda
    
# Also using these technologies in scenarios such as:
* Aws SQS => How to create a queue, create a message, create a message consumer, handle dead-letters and create a queue for it, redirect dead-letters
* Aws SNS => Create topics in SNS, create message consumer and publisher, consume message in multiple apps
* Aws DynamoDB => What are Partition Key and Sort Key, creating tables in DynamoDB, implementing access to DynamoDB, creating transactions, streams and autoscaling
* AWS S3 => File upload using C#, File download and processing using C#, retry implementations
* AWS Secrets Manager => Creating secrets, reading secrets in C#, versioning secrets, handling secret rotation
* AWS Lambda => What is serverless and lambda, creating lambda, concepts of triggers and destinations, debugging lambdas locally, consuming SQS queues using lambda, consuming SNS topics using lambda, triggering lambda with DynamoDB, triggering lambda with S3, converting an API to an AWS Lambda

This project has together other projects that were developed, all of which are part of the same scope.
Are they: 
 * https://github.com/Gondlir/sqs-publisher
 * https://github.com/Gondlir/sqs-consumer
 * https://github.com/Gondlir/sns-publisher
 * https://github.com/Gondlir/aws-lambda
