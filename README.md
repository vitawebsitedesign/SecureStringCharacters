### What
This .NET Standard library allows you to read individual characters in a `SecureString`

The compiled Nuget package has been made available [on Nuget.org](https://www.nuget.org/packages/MichaelNguyen.Utility.SecureStringCharacters/)

### Install
```bash
Install-Package MichaelNguyen.Utility.SecureStringCharacters
```

### Usage
Import namespace...
```c#
using SecureStringCharacters;
```

...then start getting characters:
```c#
mySecureString.GetChar(0);
```

This repo contains an "example usage" project.

### Helpers
Performing a synchronous `Action` on each character (e.g.: `Console.WriteLine`):
```c#
mySecureString.ForEachChar(Console.WriteLine);
```

Performing an async `Func` on each character (e.g.: `StreamWriter.WriteAsync`):
```c#
using (var streamWriter = new StreamWriter(...))
{
  await mySecureString.ForEachCharAsync(async c =>
    await streamWriter.WriteAsync((char)c)
  );
}
```

### Contributing
Pull requests are welcome. Please ensure the test suite passes before opening a PR.
