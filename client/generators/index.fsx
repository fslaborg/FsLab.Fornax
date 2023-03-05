#r "../_lib/Fornax.Core.dll"
#load "layout.fsx"

open Html

let generate' (ctx : SiteContents) (_: string) =
    Layout.layout ctx "Home" [
        section [Class "hero is-info is-medium is-bold"] [
            div [Class "hero-body"] [
                div [Class "container has-text-centered"] [
                    h1 [Class "title"] [!!"sup"]
                ]
            ]
        ]
    ]

// For a generator file to be used in fornax (meaning as a generator in the Fornax config in `config.fsx`),
// it must always end with a `generate` function that returns a string (which is the content that gets written to a file)
let generate (ctx : SiteContents) (projectRoot: string) (page: string) =
    generate' ctx page