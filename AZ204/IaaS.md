# Implement IaaS Solutions

## Creating Virtual Machines
### Windows
Azure Cli:
```bash
  az vm create `
    --resource-group "rg-az204" `
    --name "psdemo-win-cli" `
    --image "win2019datacenter" `
    --admin-username "demoadmin" `
    --admin-password "password1234"
```

Powershell:
```PS
  New-AzVm `
    -ResourceGroupName 'rg-az204' `
    -Name 'psdemo-win-ps' `
    -Image 'win2019datacenter' `
    -Credential $WindowsCred `
    -OpenPorts 3389
```

### Linux
Azure Cli:
```bash
  az vm create `
    --resource-group "rg-az204" `
    --name "psdemo-linux-cli" `
    --image "UbuntuLTS" `
    --admin-username "demoadmin" `
    --authentication-type "ssh" `
    --ssh-key-value ~/.ssh/id_rsa.pub
```

Powershell:
```PS
  # Create a subnet configuration
  $subnetConfig = New-AzVirtualNetworkSubnetConfig `
    -Name "mySubnet" `
    -AddressPrefix 192.168.1.0/24

  # Create a virtual network
  $vnet = New-AzVirtualNetwork `
    -ResourceGroupName "rg-az204" `
    -Location "northeurope" `
    -Name "myVNET" `
    -AddressPrefix 192.168.0.0/16 `
    -Subnet $subnetConfig

  # Create a public IP address and specify a DNS name
  $pip = New-AzPublicIpAddress `
    -ResourceGroupName "rg-az204" `
    -Location "northeurope" `
    -AllocationMethod Static `
    -IdleTimeoutInMinutes 4 `
    -Name "mypublicdns$(Get-Random)"

  # Create an inbound network security group rule for port 22
  $nsgRuleSSH = New-AzNetworkSecurityRuleConfig `
    -Name "myNetworkSecurityGroupRuleSSH"  `
    -Protocol "Tcp" `
    -Direction "Inbound" `
    -Priority 1000 `
    -SourceAddressPrefix * `
    -SourcePortRange * `
    -DestinationAddressPrefix * `
    -DestinationPortRange 22 `
    -Access "Allow"
  
  # Create a network security group
  $nsg = New-AzNetworkSecurityGroup `
    -ResourceGroupName "rg-az204" `
    -Location "northeurope" `
    -Name "myNetworkSecurityGroup" `
    -SecurityRules $nsgRuleSSH

  # Create a virtual network card and associate with public IP address and NSG
  $nic = New-AzNetworkInterface `
    -Name "myNic" `
    -ResourceGroupName "rg-az204" `
    -Location "northeurope" `
    -SubnetId $vnet.Subnets[0].Id `
    -PublicIpAddressId $pip.Id `
    -NetworkSecurityGroupId $nsg.Id

  # Create a virtual machine configuration
  $vmConfig = New-AzVMConfig `
    -VMName "myVM" `
    -VMSize "Standard_a1_v2" | `
  Set-AzVMOperatingSystem `
    -Linux `
    -ComputerName "myVM" `
    -Credential $WindowsCred| `
  Set-AzVMSourceImage `
    -PublisherName "Canonical" `
    -Offer "UbuntuServer" `
    -Skus "18.04-LTS" `
    -Version "latest" | `
  Add-AzVMNetworkInterface `
    -Id $nic.Id

  # Create Virtual Machine
  New-AzVm `
    -ResourceGroupName 'rg-az204' `
    -Location 'northeurope' `
    -VM $vmConfig

  # Get Virtual Machine data
  $VirtualMachine = Get-AzVM -ResourceGroupName "rg-az204" -Name "myVM"

  # Configure the SSH key
  $sshPublicKey = cat ~/.ssh/id_rsa.pub
  Add-AzVMSshPublicKey `
    -VM $VirtualMachine `
    -KeyData $sshPublicKey `
    -Path "/home/userAdmin/.ssh/authorized_keys"
```

## Open ports
Azure Cli:
```bash
  az vm open-port `
    --resource-group "rg-az204" `
    --name "psdemo-win-cli" `
    --port "3389"
```

## Get public Ip
Azure Cli:
```bash
  az vm list-ip-addresses `
    --resource-group "rg-az204" `
    --name "psdemo-win-cli" 
```

Powershell:
```PS
  Get-AzPublicIpAddress `
    -ResourceGroupName 'rg-az204' `
    -Name 'psdemo-win-ps' | Select-Object IpAddress
```