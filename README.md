[![Build status](https://ci.appveyor.com/api/projects/status/github/bytedev/ByteDev.Markdown?branch=master&svg=true)](https://ci.appveyor.com/project/bytedev/ByteDev-Markdown/branch/master)
[![NuGet Package](https://img.shields.io/nuget/v/ByteDev.Markdown.svg)](https://www.nuget.org/packages/ByteDev.Markdown)
[![License: MIT](https://img.shields.io/badge/License-MIT-green.svg)](https://github.com/ByteDev/ByteDev.Markdown/blob/master/LICENSE)

# ByteDev.Markdown

.NET Standard library of markdown related functionality.

## Installation

ByteDev.Markdown has been written as a .NET Standard 2.0 library, so you can consume it from a .NET Core or .NET Framework 4.6.1 (or greater) application.

ByteDev.Markdown is hosted as a package on nuget.org.  To install from the Package Manager Console in Visual Studio run:

`Install-Package ByteDev.Markdown`

Further details can be found on the [nuget page](https://www.nuget.org/packages/ByteDev.Markdown/).

## Release Notes

Releases follow semantic versioning.

Full details of the release notes can be viewed on [GitHub](https://github.com/ByteDev/ByteDev.Markdown/blob/master/docs/RELEASE-NOTES.md).

## Usage

### Md Helper

The `Md` helper class allows you to create markdown strings.

Reference the namespace: `ByteDev.Markdown.Helper`.

`Md` methods:

- Italic
- Bold
- Strike
- Blockquote
- HorizontalRule
- Header1
- Header2
- Header3
- Header4
- Header5
- Header6
- Code
- CodeBlock
- Link
- Image
- ListUnordered
- ListOrdered
- ListTask
- TableHeader
- TableRow
