namespace FsLab.Fornax.Components

open Html
open FsLab.Fornax.Helpers


type RootOption = 
    | Title of string
    | PrefixUrl of (string -> string)
    | AdditionalHeadTags of HtmlElement list

type internal RootConfig = {
    mutable Title : string
    mutable PrefixUrl: string -> string
    mutable AdditionalHeadTags: HtmlElement list
} with
    static member defaultConfig() =
        {
            Title = ""
            PrefixUrl = id
            AdditionalHeadTags = []
        }
    static member ofOptions (opts: RootOption list) =

            let config = RootConfig.defaultConfig()

            opts
            |> List.iter (fun opt ->
                match opt with
                | Title t -> config.Title <- t
                | PrefixUrl f -> config.PrefixUrl <- f
                | AdditionalHeadTags t -> config.AdditionalHeadTags <- t
            )

            config

type Root() =

    static member root (rootOptions: RootOption list) (children: HtmlElement list) =
        
        let config = RootConfig.ofOptions rootOptions

        html [Class "has-navbar-fixed-top"] [
            head [] [
                meta [CharSet "utf-8"]
                meta [Name "viewport"; Content "width=device-width, initial-scale=1"]
                title [] [!! config.Title]
                link [Rel "icon"; Type "image/png"; Sizes "32x32"; Href "/images/favicon.png"]
                link [Rel "stylesheet"; Href "https://maxcdn.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css"]
                link [Rel "stylesheet"; Href "https://fonts.googleapis.com/css?family=Nunito+Sans"]
                link [Rel "stylesheet"; Href "https://cdnjs.cloudflare.com/ajax/libs/bulma/0.9.1/css/bulma.min.css"]
                link [Rel "stylesheet"; Href "https://cdn.jsdelivr.net/npm/bulma-carousel@4.0.4/dist/css/bulma-carousel.min.css"]
                link [Rel "stylesheet"; Type "text/css"; Href (config.PrefixUrl "/style/style.css")]
                link [Rel "stylesheet"; Type "text/css"; Href "https://cdn.jsdelivr.net/npm/@creativebulma/bulma-collapsible@1.0.4/dist/css/bulma-collapsible.min.css"]
            
                script [ Defer true; Src "https://kit.fontawesome.com/0d3e0ea7a6.js"; CrossOrigin "anonymous"] []
            
                script [ Defer true; Type "text/javascript"; Src "https://cdn.jsdelivr.net/npm/@creativebulma/bulma-collapsible@1.0.4/dist/js/bulma-collapsible.min.js"] []
                script [ Defer true; Type "text/javascript"; Src ("https://cdn.jsdelivr.net/npm/bulma-carousel@4.0.4/dist/js/bulma-carousel.min.js") ] []
            
                script [ Defer true; Type "text/javascript"; Src (config.PrefixUrl "/js/prism.js") ] []
                script [ Defer true; Type "text/javascript"; Src (config.PrefixUrl "/js/slider.js") ] []
                script [ Defer true; Type "text/javascript"; Src (config.PrefixUrl "/js/navbar.js") ] []
                
                yield! config.AdditionalHeadTags
            ]
            body [] []
        ]