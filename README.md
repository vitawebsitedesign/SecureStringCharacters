### What
This .NET Standard library allows you to read individual characters in a `SecureString`

https://www.nuget.org/packages/MichaelNguyen.Utility.SecureStringCharacters/

### Install
```bash
Install-Package MichaelNguyen.Utility.SecureStringCharacters
```
https://www.nuget.org/packages/MichaelNguyen.Utility.SecureStringCharacters/

### Usage
Import namespace...
```c#
using SecureStringCharacters;
```

...then start getting characters:
```c#
mySecureString.GetChar(0);
```

### Helpers
Performing a synchronous `Action` on each character (e.g.: `Console.WriteLine`):
```c#
mySecureString.ForEachChar(Console.WriteLine);
```

Performing an async `Func` on each character (e.g.: `StreamWriter.WriteAsync`):
```c#
using (var streamWriter = new StreamWriter(...))
{
  mySecureString.ForEachCharAsync(streamWriter.WriteAsync);
}
```

### Contributing
Pull requests are welcome. Please ensure the test suite passes before opening a PR.
