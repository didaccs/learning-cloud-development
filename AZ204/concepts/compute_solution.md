# Compute Solutions Concepts
 
## Azure App Service
Is a service to hosting applications based on http (Web App, Api App, Mobile App, Functions or Logic Apps). The resources assigned to run those applications are defined by the App Plan (RAM, CPU, storage...).

### Scalling
 - Scale up/down -> increase or decrease resources of the instances (ram, cpu...)
 - Scale in/out -> increase or decrease the number of the instances
 - Built in authentication: integrate identity providers (Microsoft, Facebook, Google or Twitter) to sign-in, manage token and handle unauthorized requests
 - An Autoscale condition contains some autoscale rules
 - An autoscale rules executes one autoscale action
 - When combining autoscale rules the scale out action will be executed if any of the scale-out rules are met, but the scale in  action will be executed if all of the scale-in rules are met (to split the actions use different conditions)

 ### Pricing Tiers
  - Shared Compute (Free and Shared): shared resources and can't scale out -> use only for development or testing
  - Dedicated compute (Basic, Standard, Premium(s)): runs on dedicated VMs, higher tier more VM to scale out (Basic has only manual scaling)
  - Isolated: runs on dedicated VMs on dedicated Virtual Network, maxim scale out capabilities
  - Consumption: only for function apps, scales depending on workload

### Staging
 - Deployment slots only available on Standard, Premium or Isolated plan. And Standard has a maximum of 5 slots.
 - To redirect users to Non Production slot add the header "x-ms-routing-name=staging"
 - To redirect users to Production slot add the header "x-ms-routing-name=self"

## Azure Functions

### Hosting Options
 - Consumption plan: default plan, scales automatically and pay for compute resources, automatic scalling and wake up. Limited to 1.5Gb of memory and 1 CPU.
 - Premium plan: automatic scalling and reduce delay on wake up, can connect to virtual network
 - App Service plan: use the resources of the App Service, durable functions can't be used. (always on can mantain azure function active instead activate on an http request)
 - App Service Environment (ASE): fully isolated environment
 - Kubernetes: fully isolated environment working on kubernetes

### Bindings
 - In/out bindings are optional and can have more than one of each
 - In .net and Java the types of the bindings is defined in the data type and attributes and can't be created on the portal
 - For languages dinamically typed use the dataType on function.json file to define the type of the parameter such as stream, string or binary
 - The binding direction options are in, out or inout (only for advanced editor), triggers allways have in direction

## Durable functions

### Application patterns:
 - Function chaining: a sequence of functions executes in a specific order
 - Fan-out/fan-in: execute multiple functions in parallel and then wait for all functions to finish
 - Async HTTP APIs: coordinating the state of long-running operations with external clients
 - Monitor: polling until specific conditions are met (recurring process in a workflow)
 - Human interaction: involve some kind of human interaction

 ### Function types
  - Orchestrator: describe how actions are executed and the order in which actions are executed
  - Activity: basic unit of work in a durable function orchestration
  - Entity (aka durable entities): reading and updating small pieces of state to manage state explicitly
  - Client: Using an orchestrator client or entity client deliver the message to the the task hub that starts the orchestrator or entity functions.

### Task hub
 - Logical container for durable storage resources
 - Orchestrator, activity, and entity functions can only directly interact with each other when they belong to the same task hub
 - Resources used in the task hub: control queues, work-item queue, history table, instances table, storage container for blobs and large message payloads