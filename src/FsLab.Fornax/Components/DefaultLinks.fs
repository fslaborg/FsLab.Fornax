module internal DefaultHeadTagsComponent

open Html
open FsLab.Fornax

let defaultHeadTags siteTitle = [
    meta [CharSet "utf-8"]
    meta [Name "viewport"; Content "width=device-width, initial-scale=1"]
    title [] [!! siteTitle]
    link [Rel "icon"; Type "image/png"; Sizes "32x32"; Href (TemplateConfig.PrefixUrl "/images/favicon.png")]
    link [Rel "stylesheet"; Href "https://maxcdn.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css"]
    link [Rel "stylesheet"; Href "https://fonts.googleapis.com/css?family=Nunito+Sans"]
    script [ Defer true; Src "https://kit.fontawesome.com/0d3e0ea7a6.js"; CrossOrigin "anonymous"] []
    link [Rel "stylesheet"; Href "https://cdn.jsdelivr.net/npm/@fslab/fslab-styles"]
]