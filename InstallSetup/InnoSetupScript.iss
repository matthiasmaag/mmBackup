; Script generated by the Inno Setup Script Wizard.
; SEE THE DOCUMENTATION FOR DETAILS ON CREATING INNO SETUP SCRIPT FILES!

#define MyAppName "mmBackup"
#define MyAppVersion "1.0"
#define MyAppPublisher "Matthias Maag"
#define MyAppExeName "mmBackup.exe"

[Setup]
; NOTE: The value of AppId uniquely identifies this application. Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{8BCE167B-99AA-4088-A88B-BC824A1C2C4F}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
;AppVerName={#MyAppName} {#MyAppVersion}
AppPublisher={#MyAppPublisher}
DefaultDirName={autopf}\{#MyAppName}
DefaultGroupName={#MyAppName}
AllowNoIcons=yes
; Remove the following line to run in administrative install mode (install for all users.)
PrivilegesRequired=lowest
PrivilegesRequiredOverridesAllowed=dialog
OutputDir=D:\Source\CSharp\mmBackup\InstallSetup
OutputBaseFilename=mmBackupSetup1.0
Compression=lzma
SolidCompression=yes
WizardStyle=modern

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"
Name: "german"; MessagesFile: "compiler:Languages\German.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
Source: "D:\Source\CSharp\mmBackup\bin\Release\mmBackup.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\Source\CSharp\mmBackup\bin\Release\Caliburn.Micro.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\Source\CSharp\mmBackup\bin\Release\Caliburn.Micro.Platform.Core.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\Source\CSharp\mmBackup\bin\Release\Caliburn.Micro.Platform.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\Source\CSharp\mmBackup\bin\Release\mmBackup.exe.config"; DestDir: "{app}"; Flags: ignoreversion
Source: "D:\Source\CSharp\mmBackup\bin\Release\System.Windows.Interactivity.dll"; DestDir: "{app}"; Flags: ignoreversion
; NOTE: Don't use "Flags: ignoreversion" on any shared system files

[Icons]
Name: "{group}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{group}\{cm:UninstallProgram,{#MyAppName}}"; Filename: "{uninstallexe}"
Name: "{autodesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent

