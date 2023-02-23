# Import the ServerManager module
Import-Module ServerManager 

# Activate all MSMQ features
Add-WindowsFeature MSMQ-Services,MSMQ-Server,MSMQ-Triggers,MSMQ-ADIntegration,MSMQ-HTTP 

# Refresh the server manager
Import-Module ServerManager 

# Check if the MSMQ features are installed
Get-WindowsFeature MSMQ*
