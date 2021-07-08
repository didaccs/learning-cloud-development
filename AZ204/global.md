# Global CLI commands

## Login to az
With Azure Cli:
```bash
  az login
  az account set --subscription "Demo Account"
```

## Resource Group
### Get all resource groups
With Azure Cli:
```bash
  az group list --output table
```

### Create new resource group
With Azure Cli:
```bash
  az group create \
    --name "rg-az204" \
    --location "northeu"
```

### Delete resource group
With Azure Cli:
```bash
  az group delete -- name "rg-az204" 
```