# Implement IaaS Solutions

## Creating Virtual Machines
### Windows
With Azure Cli:
```bash
  az vm create \
    --resource-group "rg-az204" \
    --name "psdemo-win-cli" \
    --image "win2019datacenter" \
    --admin-username "demoadmin" \
    --admin-password "password1234"
```

### Linux
With Azure Cli:
```bash
  az vm create \
    --resource-group "rg-az204" \
    --name "psdemo-linux-cli" \
    --image "UbuntuLTS" \
    --admin-username "demoadmin" \
    --authentication-type "ssh" \
    --ssh-key-value ~/.ssh/id_rsa.pub
```

### Open ports
With Azure Cli:
```bash
  az vm open-port \
    --resource-group "rg-az204" \
    --name "psdemo-win-cli" \
    --port "3389"
```

### Get public Ip
With Azure Cli:
```bash
  az vm list-ip-addresses \
    --resource-group "rg-az204" \
    --name "psdemo-win-cli" 
```