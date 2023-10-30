# AWS Shared responsibility model
Responsibility of AWS:
 - Data center security
 - Virtualization infrastructure 
 - Software and hardware infrastructure
 - Networking infrastructure 
 - Global infrastructure, including AWS Availability Zones (AZ), Regions, and Edge locations

Responsibility of customers:
 - Patching and configuring operating systems running on EC2 instances
 - Setting up security groups
 - Administering user accounts and permissions

# AWS Well-Architected Framework

## Operational Excellence Pillar
Principles are documentation, frequent and small changes, operations as code, refining procedures quickly and anticipating system failure.

## Security Pillar

## Reliability Pillar

## Performance Efficiency Pillar
Supports computing resources to mantain and meet business requirements as technologies change over time.
Principles are going global, implementing serverless technologies, experimenting development and mechanical sympathy.

## Cost Optimization Pillar
 - Appropriate provisioning: creating and maintaining the underlying AWS resources to support business needs.

## Sustainability Pillar

# Services

CodePipeline: visualize, automate and model software releases.

Augmented AI (A2I): build workflows fo review predictions made by machine learning

Sage Maker: Fully managed services that allow build, train and deploy ML models

Lex: build conversational interfaces using voice and text
 
Rekognition: Video and image analysis

Simple Storage Service (S3): Stre unlimited objects up to 5 TBs organized in buckets
   - S3 Standard: frequently accessed data across 3 AZs
   - S3 Standard-IA: lower cost than Standard and higher retrieval cost
   - S3 One Zone-IA: more affordable than Standard with only one AZ
   - S3 Intelligent Tiering: changing or unknown frequency access, after monitoring moves objects between an Standard tier and Standard-IA tier
   - S3 Glacier: low cost storage option, retrieved between minutes to hours
   - S3 Glacier Deep archive: lowest cost storage option, retrieved up to 12 hours

Virtual Private Gateway (VPG): Secure connection between on-premises data center to virtual private cloud (VPC) on AWS using an virtual private network (VPN)

Storage Gateway: connects on-premises systems to your AWS infrastructure

Direct Connect: dedicated high speed fiber optic connection between data center to AWS

Internet gateway: allow internet access to a VPC

Relational Database Service (RDS): web service to manage, scale and set up relational database instances

Artifact: On-demand access to AWS Compliance reports and agreements made with AWS

AWS Organizations: manage multiple AWS accounts

AWS Identity and Access Management (IAM): create users and allow access to resources

DynamoDB: is an efficient and flexible solution for using a NoSQL database engine 

ElastiCache: is a web service that allows you to configure and manage cache application environments

Amazon Simple Notification Service (SNS): is a tool that allows you to set up and configure SNS mail services using a publisher and subscriber that leverages mobile notification services.

AWS Trusted Advisor: can monitor Amazon Elastic Block Store (EBS) volumes, snapshots, provisioned input/output operations per second (IOPS), and even magnetic volumes. It can also monitor Amazon Elastic Compute Cloud (EC2) components, Elastic IP addresses, and Reserved Instance limits. This tool helps implement best practices within your AWS EC2 environment by advising on reducing costs, increasing system performance, and reducing security risks.

Elastic load balancer (ELB)
 

## Elastic Compute Cloud EC2
 - Dynamic scaling: auto scaling feature for adding or substracting EC2 instances based on changes in demand


# Policies
- Predefined security policy: determine which protocols and ciphers are used when negotiations between ELB and client
- Geolocation policy: based on geographic location for moving traffic
- Inline policy: control and maintain a strict correlation between the principal entity and the policy itself
- Bucket policy: managing groups of users within the Amazon Simple Storage Service (S3)
- Identity and Access Management (IAM) user policy: managing and administering only AWS user access to the AWS infrastructure.
