# Concepts

## Azure App Service
 - Scale up/down -> increase or decrease resources of the instances (ram, cpu...)
 - Scale in/out -> increase or decrease the number of the instances
 - Built in authentication: integrate identity providers (Microsoft, Facebook, Google or Twitter) to sign-in, manage token and handle unauthorized requests
 - An Autoscale condition contains some autoscale rules
 - An autoscale rules executes one autoscale action
 - Combining autoscale rules in scale out action will be executed if any of the scale-out rules are met, but rules in scale in  action will be executed if all of the scale-in rules are met (to split the actions use different conditions)

 ### Pricing Tiers
  - Shared Compute (Free and Shared): shared resources and can't scale out -> use only for development or testing
  - Dedicated compute (Basic, Standard, Premium(s)): runs on dedicated VMs, higher tier more VM to scale out
  - Isolated: runs on dedicated VMs on dedicated Virtual Network, maxim scale out capabilities
  - Consumption: only for function apps, scales depending on workload



