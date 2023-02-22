Import-Module ServerManager
Add-WindowsFeature MSMQ-Server
Add-WindowsFeature MSMQ-ADIntegration
Add-WindowsFeature MSMQ-HTTP
Add-WindowsFeature MSMQ-Multicast
Add-WindowsFeature MSMQ-DCOMProxy
Add-WindowsFeature MSMQ-Server-PS
Enable-WindowsOptionalFeature -Online -FeatureName MSMQ-ServerCore
Enable-WindowsOptionalFeature -Online -FeatureName MSMQ-Server-PS
