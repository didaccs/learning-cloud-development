# Concepts

## Azure App Service
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


