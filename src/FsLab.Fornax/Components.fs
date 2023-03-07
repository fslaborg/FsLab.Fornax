namespace FsLab.Fornax

type Components() =

    /// <summary>
    /// An icon component using font awesome.
    /// </summary>
    /// <param name="iconClass">the font awesome icon class</param>
    static member Icon(iconClass: string) = IconComponent.icon iconClass

    /// <summary>
    /// Default head tags, for example to load the fslab style package
    /// </summary>
    /// <param name="siteTitle">The title set in the metadata section of the head</param>
    static member DefaultHeadTags(siteTitle: string) = DefaultHeadTagsComponent.defaultHeadTags siteTitle

    /// <summary>
    /// A sticky-top navbar component with customizable menu items and social links
    /// </summary>
    /// <param name="LogoSource">the source url for the logo image in the left corner</param>
    /// <param name="LogoLink">The link for clicking on the logo</param>
    /// <param name="MenuEntries">the entries on the left of the lavbar</param>
    /// <param name="SocialLinks">the social links on the right of the navbar</param>
    static member Navbar(
        ?LogoSource: string, 
        ?LogoLink: string, 
        ?MenuEntries: HtmlElement list, 
        ?SocialLinks: HtmlElement list
    ) = 
        let logoSource = defaultArg LogoSource (TemplateConfig.PrefixUrl "/images/favicon.png")
        let logoLink = defaultArg LogoLink (TemplateConfig.PrefixUrl "/")
        let menuEntries = defaultArg MenuEntries []
        let socialLinks = defaultArg SocialLinks []

        NavbarComponent.fslabNavbar logoSource logoLink menuEntries socialLinks

    /// <summary>
    /// A component containing a link with a font awesome icon to the left.
    /// </summary>
    /// <param name="iconClass">the font awesome icon class</param>
    /// <param name="text">the link text next to the icon</param>
    /// <param name="link">the link url</param>
    static member FooterIconLink(
        iconClass: string, 
        text: string, 
        link: string
    ) =
        FooterComponent.footerIconLink iconClass text link

    /// <summary>
    /// A footer block to use in the footer component
    /// </summary>
    /// <param name="children">contents of this block</param>
    static member FooterBlock(children: HtmlElement list) = FooterComponent.footerBlock children

    /// <summary>
    /// A footer component containing three columns of content
    /// </summary>
    /// <param name="Column1">The left column. Contains info text about fslab per default</param>
    /// <param name="Column2">The middle column. Contains informational and social links for fslab per default./param>
    /// <param name="Column3">The right column. Contains additional external F# sources per default</param>
    static member Footer(
        ?Column1: HtmlElement list, 
        ?Column2: HtmlElement list, 
        ?Column3: HtmlElement list
    ) =
        
        let c1 = defaultArg Column1 FooterComponent.fslabInfoFooterBlock
        let c2 = defaultArg Column2 FooterComponent.fslabMoreFooterBlock
        let c3 = defaultArg Column3 FooterComponent.fslabExternalFooterBlock

        FooterComponent.fslabFooter c1 c2 c3
