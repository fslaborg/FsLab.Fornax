#r "../_lib/Fornax.Core.dll"
#load "../globals.fsx"
#if !FORNAX
#load "../loaders/pageloader.fsx"
#load "../loaders/globalloader.fsx"
#endif

open Html
open FsLab.Fornax

let injectWebsocketCode (webpage:string) =
    let websocketScript =
        """
        <script type="text/javascript">
          var wsUri = "ws://localhost:8080/websocket";
      function init()
      {
        websocket = new WebSocket(wsUri);
        websocket.onclose = function(evt) { onClose(evt) };
      }
      function onClose(evt)
      {
        console.log('closing');
        websocket.close();
        document.location.reload();
      }
      window.addEventListener("load", init, false);
      </script>
        """
    let head = "<head>"
    let index = webpage.IndexOf head
    webpage.Insert ( (index + head.Length + 1),websocketScript)
let getBgColorForActiveItem (siteTitle:string) =
    match siteTitle with
    | "Home" -> "is-active-link-magenta"
    | "Data science packages" -> "is-active-link-lightmagenta"
    | "Tutorials and Blogposts" -> "is-active-link-darkmagenta"
    | _ -> siteTitle


let layout (ctx : SiteContents) active bodyCnt =
    let pages = ctx.TryGetValues<Pageloader.Page> () |> Option.defaultValue Seq.empty
    let siteInfo = ctx.TryGetValue<Globalloader.SiteInfo> ()
    let ttl =
        siteInfo
        |> Option.map (fun si -> si.title)
        |> Option.defaultValue ""

    let menuEntries =
        pages
        |> Seq.map (fun p ->
            let cls = if p.title = active then (sprintf "navbar-item %s smooth-hover" (getBgColorForActiveItem active)) else "navbar-item"
            a [Class cls; Href p.link] [!! p.title ]
        )
        |> Seq.toList

    html [Class "has-navbar-fixed-top"] [
        head [] [
            yield! Components.DefaultHeadTags ttl
            script [Src (Globals.prefixUrl "js/navbar.js")] []
            script [Src (Globals.prefixUrl "js/prism.js")] []
        ]
        body [] [
            Components.Navbar(
                LogoLink = (Globals.prefixUrl "images/favicon.png"),
                MenuEntries = menuEntries,
                SocialLinks = [
                    a [Class "navbar-item is-magenta"; Href "https://twitter.com/fslaborg"] [Components.Icon "fab fa-twitter"]
                    a [Class "navbar-item is-magenta"; Href "https://github.com/fslaborg"] [Components.Icon "fab fa-github"]
                ]
            )
            yield! bodyCnt
        ]
        Components.Footer()
    ]

let render (ctx : SiteContents) cnt =
  cnt
  |> HtmlElement.ToString
#if WATCH
  |> injectWebsocketCode 
#endif