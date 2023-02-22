#Import-Module ServerManager
#Add-WindowsFeature MSMQ-Server
#Add-WindowsFeature MSMQ-ADIntegration
#Add-WindowsFeature MSMQ-HTTP
#Add-WindowsFeature MSMQ-Multicast
#Add-WindowsFeature MSMQ-DCOMProxy
#Add-WindowsFeature MSMQ-Server-PS
#Enable-WindowsOptionalFeature -Online -FeatureName MSMQ-ServerCore
#Enable-WindowsOptionalFeature -Online -FeatureName MSMQ-Server-PS

# Import the ServerManager module
Import-Module ServerManager 

# Activate all MSMQ features
Add-WindowsFeature MSMQ-Services,MSMQ-Server,MSMQ-Triggers,MSMQ-ADIntegration,MSMQ-HTTP 

# Refresh the server manager
Import-Module ServerManager 

# Check if the MSMQ features are installed
Get-WindowsFeature MSMQ*
