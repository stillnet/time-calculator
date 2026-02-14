# Time Calculator

A simple Windows Forms app for adding and subtracting time values with a running total.

![Time Calculator screenshot](.github/screenshot.gif)

## Usage

Type time values in HHMM format (no colon needed):
- `35` → 0:35 (35 minutes)
- `120` → 1:20 (1 hour 20 minutes)
- `-45` → subtract 45 minutes

**Keyboard shortcuts:**
- **Enter** - Add to total
- **C** or **Escape** - Clear all
- **Backspace** (empty input) - Undo last entry

## Download

Download the latest release from the [Releases](../../releases) page.

Or install from PowerShell — this downloads the exe, places it in your local app folder, and creates a Start Menu shortcut:

```powershell
$installDir = "$env:LOCALAPPDATA\TimeCalculator"
New-Item -Path $installDir -ItemType Directory -Force | Out-Null
$repo = "stillnet/time-calculator"
$asset = (Invoke-RestMethod "https://api.github.com/repos/$repo/releases/latest").assets |
    Where-Object { $_.name -like "*.exe" } | Select-Object -First 1
$ProgressPreference = 'SilentlyContinue'
Invoke-WebRequest $asset.browser_download_url -OutFile "$installDir\TimeCalculator.exe"
$shell = New-Object -ComObject WScript.Shell
$shortcut = $shell.CreateShortcut("$env:APPDATA\Microsoft\Windows\Start Menu\Programs\Time Calculator.lnk")
$shortcut.TargetPath = "$installDir\TimeCalculator.exe"
$shortcut.Save()
```

To uninstall, remove the folder and shortcut:

```powershell
Remove-Item "$env:LOCALAPPDATA\TimeCalculator" -Recurse -Force
Remove-Item "$env:APPDATA\Microsoft\Windows\Start Menu\Programs\Time Calculator.lnk" -Force
```

## Building from Source

Requires [.NET 6 SDK](https://dotnet.microsoft.com/download) or later.

```
dotnet build
dotnet run
```

To create a self-contained executable:
```
dotnet publish -c Release -r win-x64 --self-contained -p:PublishSingleFile=true
```

Output: `bin\Release\net6.0-windows\win-x64\publish\TimeCalculator.exe`
