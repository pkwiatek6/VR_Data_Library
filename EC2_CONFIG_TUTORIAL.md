# EC2 Instance Shell Connection Configuration
## Windows
### PuTTy
- Generate Putty Key file using PuTTyGen on the .pem key
  - Open PuTTy Key Generator
    - Click Load
      - Change the file-type to All Files(*.*)
      - Select the .pem key
      - Select OK
    - Click Save Private Key
      - Select YES
  - Open PuTTy
    - Hostname is ec2-54-208-235-237.compute-1.amazonaws.com
    - Data->Auto-login username is ubuntu
    - Go to SSH->Auth
      - click browse
        - Select ppk file generated from PuTTyGen
    - Go back to Session and save session as some arbitrary name you'll remember
    - On your first connection it'll prompt about a fingerprint just say yes
    - To reuse session just click load next time puTTy is started
### PowerShell/GitBash/Windows Terminal Preview
- Download .pem file and change permissions on the file by doing the following
  - Right click and go to properties
  - Security -> Advanced...
  - Click Disable inheritance
    - When prompted you have two options
      - Convert Existing permissions (Recommended)
        - Remove all lines in the Table that aren't your username
      - Remove All Permissions
        - Add Full Control to your username
- Follow the Linux/Mac Instructions disregard the chmod instructions

## Linux/Mac
- Contact me if you do **not** have OpenSSH or some kind of ssh client(This is highly unlikely)
- from your HOME directory (~) cd into .ssh
- copy the .pem file from slack into the .ssh directory
- run chmod 400 on {Filename}.pem
- Confirm chmod 700 for the .ssh directory
- Create or edit a file called config inside the .ssh directory and put the following inside

```
Host {Some_name_you_decide}  
  HostName ec2-54-208-235-237.compute-1.amazonaws.com  
  User ubuntu  
  IdentityFile /home/djdus/.ssh/{key_file_name}.pem
```

- From Try to run ssh {Some_name_you_decide} and when it prompts for a fingerprint say yes
- If it fails double-check file permissions. This is something that may happen on windows