# Implement PaaS Solutions

## Azure App Service

### List accepted runtimes
```bash
  az webapp list-runtimes --linux
```

### List outbound IP addresses
```bash
  az webapp show \
    --resource-group <group_name> \
    --name <app_name> \ 
    --query outboundIpAddresses \
    --output tsv
```
To show all outbound IP addresses regardless the pricing tier change outboundIpAddresses for possibleOutboundIpAddresses.

### Create Web App
```bash
  az webapp up --location <myLocation> --name <myAppName> --html
```
Where location is the region to deploy
This command create a default resource group and default app service plan the create the app and deploy the files from the current directory; to redeploy the app use the same command.

### Stream Web App logs
```bash
  az webapp log tail --name appname --resource-group myResourceGroup
```

### Create Block blob storage
```bash
  az storage account create --resource-group myResourceGroup --name <myStorageAcct> --location <myLocation> --kind BlockBlobStorage  -sku Premium_LRS
```

