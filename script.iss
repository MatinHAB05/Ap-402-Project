; =============================
;      Inno Setup Script
;   Full .NET Runtime Installer
; =============================

[Setup]
AppName=RestaurantApp
AppVersion=1.0.0
DefaultDirName={pf}\RestaurantApp
OutputDir=output
OutputBaseFilename=RestaurantApp_Setup
Compression=lzma
SolidCompression=yes
LicenseFile=license.txt
; آیکون برنامه (اختیاری)
SetupIconFile=publish\AppIcon.ico

[Files]
; کل خروجی پابلیش را کپی کن
Source: "publish\*"; DestDir: "{app}"; Flags: recursesubdirs

; فایل Runtime را در سیستم موقتی کپی کن
Source: "windowsdesktop-runtime-8.0.26-win-x64.exe"; DestDir: "{tmp}"

[Icons]
; Shortcut در Start Menu
Name: "{group}\RestaurantApp"; Filename: "{app}\RestaurantApp.exe"
; Shortcut روی دسکتاپ
Name: "{commondesktop}\RestaurantApp"; Filename: "{app}\RestaurantApp.exe"; Tasks: desktopicon

[Tasks]
Name: "desktopicon"; Description: "Create a desktop shortcut"; Flags: unchecked

[Run]
; اگر .NET Desktop Runtime نصب نبود، نصبش کن
Filename: "{tmp}\windowsdesktop-runtime-8.0.26-win-x64.exe"; \
    Parameters: "/install /quiet /norestart"; \
    StatusMsg: "Installing .NET Desktop Runtime..."; \
    Check: not IsDotNetInstalled

; اجرای برنامه بعد از نصب (اختیاری)
Filename: "{app}\RestaurantApp.exe"; Description: "Run RestaurantApp"; Flags: postinstall nowait skipifsilent

[Code]
function IsDotNetInstalled: Boolean;
begin
  Result := RegKeyExists(HKLM, 
    'SOFTWARE\dotnet\Setup\InstalledVersions\x64\sharedfx\Microsoft.WindowsDesktop.App\8.0');
end;
