module internal FooterComponent

open Html
open FsLab.Fornax

let footerIconLink (iconClass:string) (text:string) (link:string) = 
    div [Class "icon-text is-white"] [
        span [Class"icon"] [
            i [Class iconClass] []
        ]
        span [] [a [Class "footer-link"; Href link] [!! text]]
    ]

let footerBlock children = 
    div [Class "block"] children

let fslabInfoFooterBlock =
    [
        div [Class "block"] [
            h3 [Class "subtitle is-white"] [!!"FsLab - the project incubation space for data science in F#"]
        ]
        div [Class "block"] [
            p [] [!!"FsLab is only possible due to the joined forces of F# open source contributors."]
        ]
        div [Class "block"] [
            p [] [!!"This website is created and maintained by individual FsLab open source contributors."]
        ]
        div [Class "block"] [
            footerIconLink "fas fa-code-branch" "website source code" "https://github.com/fslaborg/fslaborg.github.io"
            footerIconLink "far fa-handshake" "FsLab contributors" "https://github.com/orgs/fslaborg/people"
        ]
    ]

let fslabMoreFooterBlock =
    [
        div [Class "block"] [
            h3 [Class "subtitle is-white"] [!!"More"]
        ]
        div [Class "block"] [
            div [Class "block"] [
                footerIconLink "fab fa-github" "the FsLab organisation on github" "https://github.com/fslaborg?type=source"
                footerIconLink "fab fa-twitter" "FsLab on twitter" "https://twitter.com/fslaborg"
            ]
            div [Class "block"] [
                footerIconLink "fas fa-cubes" "endorsed packages" "https://fslab.org/packages.html"
                footerIconLink "fas fa-plus" "add a package to the list" "https://github.com/fslaborg/fslaborg.github.io#add-a-project-to-the-packages-site"
                                
            ]
            div [Class "block"] [
                footerIconLink "fas fa-graduation-cap" "blog" "https://fslab.org/blog"
                footerIconLink "fas fa-plus" "start posting on the FsLab blog" "https://github.com/fslaborg/blog?tab=readme-ov-file#add-content"
            ]
        ]
    ]

let fslabExternalFooterBlock =
    [
        div [Class "block"] [
            h3 [Class "subtitle is-white"] [!!"External resources"]
        ]
        div [Class "block"] [
            ul [] [
                li [] [a [Href "https://github.com/fsprojects?type=source"; Class "footer-link"] [!!"fsprojects - general F# project incubation space"]]
                li [] [a [Href "https://fsharp.org/"; Class "footer-link"] [!!"fsharp.org"]]
            ]
        ]
    ]

let fslabFooter col1 col2 col3 = 
    footer [Class "footer has-bg-darkmagenta"] [
        div [Class "container"] [
            div [Class "columns"] [
                div [Class "column is-4 m-4"] col1
                div [Class "column is-4 m-4"] col2
                div [Class "column is-4 m-4"] col3
            ]
        ]
    ]