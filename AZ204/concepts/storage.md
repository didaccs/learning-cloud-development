# Storage

## Blob Storage

### Account Types
 - Standard:  Standard storage account type for blobs, file shares, queues, and tables. (not accept NFS file shares)
 - Premium block blobs: for high transactions rates, or to use smaller objects or for  low storage latency.
 - Premium page blobs
 - Premium file share: for azure files (accept NFS file shares)

### Tiers for block blob
 - Hot: expensive to store but cheap to access (default option on new storage accounts)
 - Cool: expensive to access but cheap to store (recommend to store data at least 30 days infrequently accessed)
 - Archive: most expensive to access but most cheap to store (recommend to store data at least 180 days infrequently accessed)

### Blob types
 - Block blobs: text and binary data, up to about 4.7 TB
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


