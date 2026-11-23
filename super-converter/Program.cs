using Microsoft.Win32;

Console.WriteLine("Hello, World!");

const string MenuKeyPath = @"Software\Classes\*\shell\OptionTest";

if(args.Length == 0)
{
    Install();
}
else if (args[0] == "--uninstall")
{
    Uninstall();
}
else
{
    Console.WriteLine("Option test was clicked for:");
    Console.WriteLine(args[0]);
}


void Install()
{
    string exePath = Environment.ProcessPath;

    using RegistryKey menuKey = Registry.CurrentUser.CreateSubKey(MenuKeyPath);
    menuKey.SetValue("", "Test Option!");
    menuKey.SetValue("Icon", exePath);

    using RegistryKey commandKey = menuKey.CreateSubKey("command");
    commandKey.SetValue("", $"\"{exePath}\" \"%1\"");

    Console.WriteLine("Installed! Right-click any file in File Explorer to see \"Option test\".");
    Console.WriteLine("On Windows 11, click \"Show more options\" first.");
}

void Uninstall()
{
    Registry.CurrentUser.DeleteSubKeyTree(MenuKeyPath, throwOnMissingSubKey: false);
    Console.WriteLine("Removed \"Option test\" from the right-click menu.");
}