# Project Title: MSMQ_Subscriber_Process

# Project Description: 
Inter App Communication using [Microsoft Message Queuing (MSMQ)](https://learn.microsoft.com/en-us/previous-versions/windows/desktop/msmq/ms711472(v=vs.85)) between two Windows Presentation Foundation [WPF](https://learn.microsoft.com/en-us/dotnet/desktop/wpf/overview/?view=azurestackps-2.5.0) Applications to demostrate messaging with MSMQ using Model View View-Model pattern, such that when Application 1 (process A) publishes data Application 2 (process B) subscribes automatically to recieve the data from the queue.

This Application reads the machine name, runs a PowerShell Script to activate MSMQ without manually activating MSMQ, checks if the machine has private or public queues then creates a queue.  If none is found it prompts the user with an alert that it could not create queue. Exceptions were handled while the app creates and sends data to the queue.

# Dependencies:
**.NET 6**

**Packages:**
**MSMQ Messaging 1.0.4** , 
**Prism Core 8.1.97**

# How to Run the Project: 
* Clone the Project
* Run with Visual Studio 2022. 
* The executable file (.exe) will be published soon for you to download.


# Badges
![GitHub all releases](https://img.shields.io/github/downloads/Samuel-Jaja/MSMQ_MVVM_Application/total)
![GitHub language count](https://img.shields.io/github/languages/count/Samuel-Jaja/MSMQ_MVVM_Application)
![GitHub file size](https://img.shields.io/github/repo-size/Samuel-Jaja/MSMQ_MVVM_Application)
![GitHub top language](https://img.shields.io/github/languages/top/Samuel-Jaja/MSMQ_MVVM_Application?color=yellow)
![GitHub forks](https://img.shields.io/github/forks/Samuel-Jaja/MSMQ_MVVM_Application?style=social)

![GitHub forks](https://img.shields.io/twitter/follow/senibo_sj?style=social)
