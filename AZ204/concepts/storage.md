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

 ### Blob Storage Metadata
  - System properties: some correspond to certain standard HTTP headers
  - User-defined metadata: one or more name-value pairs that you specify. You can use metadata to store additional values with the resource.

 - Header Format: x-ms-meta-name:string-value
 - Get Headers from a container: ``` GET/HEAD https://myaccount.blob.core.windows.net/mycontainer?restype=container ```
 - Get Headers from a blob: ``` GET/HEAD https://myaccount.blob.core.windows.net/mycontainer/myblob?comp=metadata ```
 - Set headers on a container: ``` PUT https://myaccount.blob.core.windows.net/mycontainer?comp=metadata&restype=container ```
 - Set headers on a blob: ``` PUT https://myaccount.blob.core.windows.net/mycontainer/myblob?comp=metadata ```



## Cosmos DB

The base unit for global distribution is the Azure Cosmos Account which contains a unique DNS name. There is a limit of 50 Azure Cosmos Accounts for each subscription (can be increased by support).
An Azure Cosmos account can have multiple databases (Keyspace on cassandra API, and Not available on Table API) and can have some Azure Cosmos Containers.
The Azure cosmos containers is horizontally partitioned and ditributed across regions and could have dedicated provisioned throughput (exclusively throughput reserved for that container) or shared provisioned throughput (throughput shared with all containers in the same database).
The Azure Comso Item located on the containers is mapped to different specific entities, Item for SQL Api, Row in Cassandra API, Document on MongoDb API, Node or edge on Gremplin API or Item for Table API.

Description for RU's (Request Units): https://docs.microsoft.com/en-us/azure/cosmos-db/request-units

### Consistency levels
From strong consistency to weaker consistency these are the consistency levels:
 - Strong: guarantee the reads are the last version, but it's the lowest option
 - Bounded Staleness
 - Session: is the optimal and recommended option (default option)
 - Consistent prefix
 - Eventual: for highest availability and the lowest latency

### Supported APIs
 - Core (SQL) Api: document in JSON format, queries in SQL and  full availability of new features
 - Cassandra API: column-oriented, queries in CQL
 - MongoDb API: document in BSON format, some features are not available
 - Gremplin API: data as edges and vertices, graph queries, best for dynamic data with complex relations
 - Table API: key/value format, best than Azure Table storage

### Resources Provisioning
The cost of provisioning resources is measured with request units (RUs):
 - Provisioned throughput mode: fixed provisioning of RUs per second basis
 - Serverless mode: any provision required, charged by consume
 - Autoscale mode: autoscale RUs based on usage

### Partitioning
A container has some logical partitions which items has the same partition key, the number of different partition keys determine the number of logical partitions.
A physical partition can hold one logical partition or more, that depends of the Ru/s (max 10000Ru/s per physical partition) and total data storage (max 50Gb by partition), this partitions are managed by Azure.

#### Synthetic Partition Key
Is a partition key with many distinct values in it, available kinds:
 - concatenate properties
 - random suffix (improve write throughput but difficult to read)
 - pre-calculated suffix (improve write throughput and easy to read)


## SQL Database

Description for DTUs: https://docs.microsoft.com/en-us/azure/azure-sql/database/service-tiers-dtu?view=azuresql
