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


let generate (ctx : SiteContents) (projectRoot: string) (page: string) =
    generate' ctx page