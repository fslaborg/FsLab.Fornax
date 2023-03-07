# FsLab.Fornax

Fornax template for fslab websites

This repo contains the source for two packages:
- **FsLab.Fornax** [![](https://img.shields.io/nuget/v/FsLab.Fornax)](https://www.nuget.org/packages/FsLab.Fornax/) is a library containing components for [fornax]() in the fslab style.
- FsLab.Fornax.Template [![](https://img.shields.io/nuget/v/FsLab.Fornax.Template)](https://www.nuget.org/packages/FsLab.Fornax.Template/) is a `dotnet new` template for instantly getting a fornax website in the fslab style up and running.

# Using the template

## install

`dotnet new install FsLab.Fornax.Template::*`

## cli usage

```
FsLab.Fornax.Template (F#)
Author: Kevin Schneider

Usage:
  dotnet new fslab-web [options] [template options]

Options:
  -n, --name <name>       The name for the output being created. If no name is specified, the name of the output
                          directory is used.
  -o, --output <output>   Location to place the generated output.
  --dry-run               Displays a summary of what would happen if the given command line were run if it would result
                          in a template creation.
  --force                 Forces content to be generated even if it would change existing files.
  --no-update-check       Disables checking for the template package updates when instantiating a template.
  --project <project>     The project that should be used for context evaluation.
  -lang, --language <F#>  Specifies the template language to instantiate.
  --type <project>        Specifies the template type to instantiate.

Template options:
  -bu, --base-url <base-url>                  The base url of the deployed site, will be used when building the static
                                              htmls to prefix urls
                                              Type: string
  -st, --site-title <site-title>              The title of the site, will be used in page metadata
                                              Type: string
  -sd, --site-description <site-description>  The description of the site, will be used in page metadata
                                              Type: string
```

## developing the website

In the root of your generated folder, run

```
dotnet tool restore
dotnet fornax watch
```

## publishing the website

In the root of your generated folder, run

```
dotnet fornax build
```

the output will be in the `_public` folder.