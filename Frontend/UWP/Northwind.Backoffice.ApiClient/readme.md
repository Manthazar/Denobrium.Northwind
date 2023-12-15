When exploring the tech for a reference implementation, I concluded UWP would be a good choice as a middleground between WPF and WinUI2/3. 
Like this I would also gain some migration experience.

However, after doing the first baby steps with UWP, supposedly newer than WPF, it turned out that UWP actually got stuck on ancient techs, not supporting .NET Standard or any newer C# version.

Also, it cannot reference a .NET Framework or .NET CORE library and has to rely on its own format.

Said that this app will not be a good investment as the reference app for long time and we shall migrate to WinUI.
