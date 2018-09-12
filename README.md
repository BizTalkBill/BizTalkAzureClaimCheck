# BizTalk Azure Claim Check 

## BizTalk Azure Claim Check Pipeline Component

### Includes:

* Azure Resource Templates for Logic Apps, Storage Accounts, Services Bus, Key Vault and Event Grid

* BizTalk 2016 Implementation with BizTalk project of property schemas and sample pipelines

* BizTalk 2013 R2 Implementation with BizTalk project of property schemas and sample pipelines

## Purpose

With Many people looking to move some or all of their BizTalk processes to Azure Integration (API Management, Logic Apps, Service Bus, Event Grid and Azure Functions), I have developed this BizTalk Pipeline component that implements the Azure Claim Check Pattern. 

There are many ways to move data from Azure to on-premises and back, but the claim check pattern is one of the easiest way when you don't know the message size, the pattern works by placing the data in Azure Blob Storage and sending a Service Bus message with the location and message properties to BizTalk (or Logic Apps, when moving from on-premises to Azure). This pipeline component will do the heavy lifting to pull the data from the Azure Storage Account and create a BizTalk message from it contents, promoting ClientId and MessageTypeId (if present) from the Service Bus message properties

