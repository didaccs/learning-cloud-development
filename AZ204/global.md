# Global CLI commands

## Login to az
Azure Cli:
```bash
  az login
  az account set --subscription "Demo Account"
```

PowerShell:
```PS
  Connect-AzAccount -SubscriptionName 'Demo Account'
  Set-AzContext -SubscriptionName 'Demo Account'
```

## Resource Group
### Get all resource groups
Azure Cli:
```bash
  az group list --output table
```

### Create new resource group
Azure Cli:
```bash
  az group create \
    --name "rg-az204" \
    --location "northeurope"
```

PowerShell:
```PS
  New-AzResourceGroup -Name "rg-az204" --Location "northeurope"  
```

### Delete resource group
Azure Cli:
```bash
  az group delete -- name "rg-az204" 
```

## Credentials
Powershell:
```PS
  $username = 'admin'
  $password = ConvertTo-SecureString 'password.1234' -ASPlainText -Force
  $WindowsCred = New-Object System.Management.Automation.PSCredential ($username, $password)
```

```PS
  ssh-keygen -t rsa -b 4096
```

## ARM Templates
### Deploy
Powershell:
```PS
  New-AzResourceGroupDeployment `
    -Name testDeployment `
    -ResourceGroupName 'rg-az204' `
    -TemplateFile './template.json' `
    -TemplateParameterFile './parameters.json' 
```