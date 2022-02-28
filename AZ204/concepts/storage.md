# Storage

## Blob Storage

### Account Types
 - Standard:  Standard storage account type for blobs, file shares, queues, and tables. (not accept NFS file shares)
 - Premium block blobs: for high transactions rates, or to use smaller objects or for  low storage latency.
 - Premium page blobs
 - Premium file share: for azure files (accept NFS file shares)

### Tiers for block blob
Access tier can be set during or after upload:
 - Hot: expensive to store but cheap to access (default option on new storage accounts)
 - Cool: expensive to access but cheap to store (recommend to store data at least 30 days infrequently accessed)
 - Archive: most expensive to access but most cheap to store (recommend to store data at least 180 days infrequently accessed and set at block level). To rehydrate is possible copy to an online tier (hot or cool) in the same storage or change tier and can be done with standard priority (up to 15 hours) or high priority (under 1 hour for under 10 gb) with the header "x-ms-rehydrate-priority".

### Blob types
 - Block blobs: text and binary data, up to about 4.7 TB (for high transaction rates and fast access time)
 - Append blobs: block blobs optimized for append operations (ex: logging from VM)
 - Page blobs: random access files up to 8 TB (ex: VHD  served as disks for VM)

### Security
 - automatically encrypted  using Storage Service Encryption (SSE) (similar to BitLocker for windows)
 - Azure Active Directory (Azure AD) and Role-Based Access Control (RBAC) are supported
 - data secured in transit by using Client-Side Encryption, HTTPS, or SMB 3.0
 - OS and data disks can be encrypted using Azure Disk Encryption
 - possibility to delegate access using shared access signature
 - Microsoft can manage the encryption key or manage with own keys saving on key Vault:
    - customer managed key: encrypt data in the storage account (only for blob storage or azure files)
    - customer provided key: pass the key on the requests to the blob storage (only for blob storage)

### Redundancy
Redundancy in the primary region:
 - Locally redundant storage (LRS): synchronously copies three times within a single physical location (least expensive)
 - Zone-redundant storage (ZRS): synchronously copies in three Azure availability zones in the primary region

Redundancy in the secondary region:
 - Geo-redundant storage (GRS): synchronously LRS in the first region and asynchronously LRS in the secondary region
 - Geo-zone-redundant storage (GZRS): synchronously ZRS in the first region and asynchronously ZRS in the secondary region

 ### LifeCycle Management
 - Transition blobs to a cooler storage tier (hot to cool, hot to archive, or cool to archive)
 - Delete blobs at the end of their lifecycles
 - Define rules to be run once per day at the storage account level
 - Apply rules to containers or a subset of blobs (using prefixes as filters)

 When define some actions on the same blob applies the least expensive:
  - tierToCool: for blockBlob
  - enableAutoTierToHotFromCool: for blockBlob (not supported ofr snapshots and versions)
  - tierToArchive: for blockBlob
  - delete: for blockBlob and appendBlob

### Lifecycle policies
A policy is a collection of rules, and each rule includes a filter set and an action set. Actions are applied to the filtered blobs when the run condition is met. To add new one go to your storage account -> Data Management -> Lifecycle management.
Example:
```JSON
{
  "rules": [
    {
      "name": "ruleFoo",    // rule name
      "enabled": true,      // enable or disable rule
      "type": "Lifecycle",  // only Lifecycle is accepted
      "definition": {     
        "filters": {
          "blobTypes": [ "blockBlob" ],           // array of blockBlob, appendBlob or pageBlob
          "prefixMatch": [ "container1/foo" ],    // array of prefix string started always with container name
          "blobIndexMatch" : [ "fooTest" ]        // array of blob index tag key and value conditions                            
        },
        "actions": {
          "baseBlob": {
            "tierToCool": { "daysAfterModificationGreaterThan": 30 },                 // only supported for block blob 
            "tierToArchive": { "daysAfterModificationGreaterThan": 90 },              // only supported for block blob 
            "enableAutoTierToHotFromCool": {"daysAfterModificationGreaterThan": 90},  // supported for baseBlob and block blob
            "delete": { "daysAfterModificationGreaterThan": 2555 }                    // supported for block blob and appendBlob
          },
          "version": {
            "delete": { "daysAfterModificationGreaterThan": 90 }
          }, 
          "snapshot": {
            "delete": { "daysAfterCreationGreaterThan": 90 }   // daysAfterCreationGreaterThan is the condition for snapshots only 
          }
        }
      }
    }
  ]
}
```

### Blob Storage Client Library
Main classes .NET Library:
 - BlobClient: manipulate Azure Storage blobs
 - BlobClientOptions: client configuration options for connecting
 - BlobContainerClient: manipulate Azure Storage containers and their blobs
 - BlobServiceClient: manipulate Azure Storage service resources and blob containers
 - BlobUriBuilder: modify the Uri instance to point to different Azure Storage resources like an account, container, or blob