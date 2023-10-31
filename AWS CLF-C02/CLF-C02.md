# AWS Shared responsibility model
|Responsibility of AWS|Responsibility of customers|
|-|-|
|Data center security| Patching and configuring operating systems running on EC2 instances|
|Virtualization infrastructure | Setting up security groups|
|Software and hardware infrastructure| Administering user accounts and permissions |
|Networking infrastructure |
|Global infrastructure, including AWS Availability Zones (AZ), Regions, and Edge locations|

# AWS Well-Architected Framework

## Operational Excellence Pillar
Support development and run workloads effectively, gain insight into their operation, and continuously improve supporting processes and procedures to delivery business value

**Principles**
- Perform operations as code
- Make frequent, small, reversible changes
- Refine operations procedures frequently
- Anticipate failure
- Learn from all operational failures

## Security Pillar
The ability to protect data, systems, and assets to take advantage of cloud technologies to improve your security.

**Principles**
- Implement a strong identity foundation
- Enable traceability
- Apply security at all layers
- Automate security best practices
- Protect data in transit and at rest
- Keep people away from data
- Prepare for security events

## Reliability Pillar
Encompasses the ability of a workload to perform its intended function correctly and consistently when it’s expected to. This includes the ability to operate and test the workload through its total lifecycle.

**Principles**
- Automatically recover from failure
- Test recovery procedures
- Scale horizontally to increase aggregate workload availability
- Stop guessing capacity
- Manage change in automation

## Performance Efficiency Pillar
Ability to use computing resources efficiently to meet system requirements, and to maintain that efficiency as demand changes and technologies evolve.

**Principles**
- Democratize advanced technologies
- Go global in minutes
- Use serverless architectures
- Experiment more often
- Consider mechanical sympathy

## Cost Optimization Pillar
Ability to run systems to deliver business value at the lowest price point.

**Principles**
- Implement cloud financial management
- Adopt a consumption model
- Measure overall efficiency
- Stop spending money on undifferentiated heavy lifting
- Analyze and attribute expenditure

## Sustainability Pillar
Addresses the long-term environmental, economic, and societal impact of your business activities.

**Principles**
- Understand your impact
- Establish sustainability goals
- Maximize utilization
- Anticipate and adopt new, more efficient hardware and software offerings
- Use managed services
- Reduce the downstream impact of your cloud workloa

# Services

## Computation Services
- **Elastic Compute Cloud (EC2)**: virtual or dedicated physical servers
   - Dynamic scaling: auto scaling feature for adding or subtracting EC2 instances based on changes in demand
- **Elastic Container Registry (ECR)**: container registry for easy storage, management, and deployment of your container images
- **EC2 Container Service (ECS)**: container orchestration service that enables you to run, scale, and secure Docker applications on Amazon EC2 and AWS Fargate
- **AWS Fargate**: serverless compute engine for containers that works both with ECS and EKS (Amazon Elastic Kubernetes Service) that automatically provision and manage servers
- **AWS Lambda**: serverless compute service that enables you to run your code on the AWS platform 
- **AWS Elastic Beanstack**: handles provisioning, load balancing, auto-scaling, app health monitoring and deployment for web applications

## Databases
- **Amazon DynamoDB**: managed NoSQL database that supports both key-value and document store
- **Amazon ElastiCache**: managed Redis and Memcached
- **Amazon Aurora**: MySQL and PostgreSQL-compatible relational database
- **Amazon RDS** (Relational Database Service): web service that manages relational databases that takes care of hardware provisioning, database setup, patching, and backups. Supports Amazon Aurora, PostgreSQL, MySQL, Microsoft SQL Server, Oracle Database, and MariaDB.

## Analytics & IA
- **Amazon Kinesis**: analyze real-time data streams with low-latency
- **Amazon Redshift**: data warehouse and run standard SQL queries 
- **Amazon Athena**: serverless solution to analyze large datasets in Amazon S3 using standard SQL
- **AWS Glue**: discover and extract data from multiple sources, prepare this data for use, and organize it into databases, data warehouses, and data lakes for further analysis
- **Augmented AI (A2I)**: build workflows fo review predictions made by machine learning
- **Sage Maker**: Fully managed services that allow build, train and deploy ML models
- **Lex**: build conversational interfaces using voice and text
 - **Rekognition**: Video and image analysis

## Networking and Content Delivery Services
- **Amazon Route 53**: advanced, highly available, and scalable DNS Service with routing types like GeoDNS, Geoproximity, and Latency Based Routing
- **Amazon CloudFront**: content delivery network (CDN) that caches your content and APIs on globally scaled edge locations
- **Amazon API Gateway**: create, publish, monitor, and secure RESTful and WebSocket APIs
- **AWS Elastic Load Balancing**: distributes incoming application traffic across multiple servers, containers, or Lambda functions
- **ElastiCache**: is a web service that allows you to configure and manage cache application environments
- **Amazon VPC (Virtual Private Cloud)**: create logically isolated virtual networks inside AWS
- **Virtual Private Gateway (VPG)**: Secure connection between on-premises data center to virtual private cloud (VPC) on AWS using an virtual private network (VPN)
- **Direct Connect**: dedicated high speed fiber optic connection between data center to AWS
- **Internet gateway**: allow internet access to a VPC
- **Storage Gateway**: connects on-premises systems to your AWS infrastructure

## Integration Services
- **Amazon MQ**: message broker service to run ActiveMQ and RabbitMQ
- **Amazon SQS (Simple Queue Service)**: send, store, and receive messages between microservices and serverless applications
- **Amazon SNS (Simple Notification Service)**: pub/sub fanout messaging to many subscribers, including Amazon SQS, AWS Lambda functions, HTTPS endpoints, and Amazon Kinesis Data . It can also send messages to users via email, mobile push notifications, and SMS.
- **Amazon SES (Simple Email Service)**: email service that supports mass email communication, marketing, and transactional emails at scale
- **AWS Secrets Manager**: protects the secrets needed to access various APIs and resources

## Management & Governance
- **AWS CloudFormation**: describe your desired resources and their dependencies with a code template as a single stack
- **AWS CloudWatch**: provides a unified view of AWS resources and services of your application. It’s helpful to optimize resources, detect abnormal behavior, set different alarms, monitor application health, and troubleshoot issues by viewing logs and various metrics.
- **CodePipeline**: visualize, automate and model software releases.
- **Artifact**: On-demand access to AWS Compliance reports and agreements made with AWS
- **AWS Organizations**: manage multiple AWS accounts
- **AWS Identity and Access Management (IAM)**: create users and allow access to resources

## Data Storage
- **Amazon S3 (Simple Storage Service)**: generic object storage service designed for incredible durability, high scalability, availability, security, and performance. Objects up to 5 TBs organized in buckets.
   - S3 Standard: frequently accessed data across 3 AZs
   - S3 Standard-IA: lower cost than Standard and higher retrieval cost
   - S3 One Zone-IA: more affordable than Standard with only one AZ
   - S3 Intelligent Tiering: changing or unknown frequency access, after monitoring moves objects between an Standard tier and Standard-IA tier
   - S3 Glacier: low cost storage option, retrieved between minutes to hours
   - S3 Glacier Deep archive: lowest cost storage option, retrieved up to 12 hours
- **Amazon EBS (Elastic Block Storage)**: long-term high-performance block storage for EC2 instances
- **Amazon EFS (Elastic File System)**: fully managed scalable elastic NFS. It grows and shrinks automatically
- **AWS Trusted Advisor**: can monitor Amazon Elastic Block Store (EBS) volumes, snapshots, provisioned input/output operations per second (IOPS), and even magnetic volumes. It can also monitor Amazon Elastic Compute Cloud (EC2) components, Elastic IP addresses, and Reserved Instance limits. This tool helps implement best practices within your AWS EC2 environment by advising on reducing costs, increasing system performance, and reducing security risks.

# Policies
- Predefined security policy: determine which protocols and ciphers are used when negotiations between ELB and client
- Geolocation policy: based on geographic location for moving traffic
- Inline policy: control and maintain a strict correlation between the principal entity and the policy itself
- Bucket policy: managing groups of users within the Amazon Simple Storage Service (S3)
- Identity and Access Management (IAM) user policy: managing and administering only AWS user access to the AWS infrastructure.
