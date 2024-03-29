﻿module internal NavbarComponent

open Html
open FsLab.Fornax

let fslabNavbar (isFixed: bool) (logoSource:string) (logoLink:string) (menuEntries: HtmlElement list) (socialLinks: HtmlElement list) =
    

    nav [Class (if isFixed then "navbar is-fixed-top" else "navbar")] [
        div [Class "navbar-brand"] [
            a [Class "navbar-item"; Href logoLink] [
                    img [Src logoSource; Alt "Logo"]
                ]
            a [
                Class "navbar-burger"; 
                HtmlProperties.Custom ("data-target", "navMenu"); 
                HtmlProperties.Custom ("aria-label", "menu"); 
                HtmlProperties.Role "button"
                HtmlProperties.Custom ("aria-expanded", "false")
            ] [
                span [HtmlProperties.Custom ("aria-hidden","true")] []
                span [HtmlProperties.Custom ("aria-hidden","true")] []
                span [HtmlProperties.Custom ("aria-hidden","true")] []
            ]
        ]
        div [Id "navMenu"; Class "navbar-menu"] [
            div [Class "navbar-start"] menuEntries
            div [Class "navbar-end"] socialLinks
        ]
    ]