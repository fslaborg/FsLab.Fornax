namespace FsLab.Fornax

type Components() =

    static member Icon(iconClass: string) = IconComponent.icon iconClass

    static member DefaultHeadTags(siteTitle: string) = DefaultHeadTagsComponent.defaultHeadTags siteTitle

    static member Navbar(
        ?LogoLink: string,
        ?MenuEntries: HtmlElement list,
        ?SocialLinks: HtmlElement list
    ) = 
        let logoLink = defaultArg LogoLink (TemplateConfig.PrefixUrl "/images/favicon.png")
        let menuEntries = defaultArg MenuEntries []
        let socialLinks = defaultArg SocialLinks []

        NavbarComponent.fslabNavbar logoLink menuEntries socialLinks

    static member FooterIconLink(
        iconClass: string,
        text: string,
        link: string
    ) =
        FooterComponent.footerIconLink iconClass text link

    static member FooterBlock(children: HtmlElement list) = FooterComponent.footerBlock children

    static member Footer(
        ?Column1: HtmlElement list,
        ?Column2: HtmlElement list,
        ?Column3: HtmlElement list
    ) =
        
        let c1 = defaultArg Column1 FooterComponent.fslabInfoFooterBlock
        let c2 = defaultArg Column2 FooterComponent.fslabMoreFooterBlock
        let c3 = defaultArg Column3 FooterComponent.fslabExternalFooterBlock

        FooterComponent.fslabFooter c1 c2 c3
