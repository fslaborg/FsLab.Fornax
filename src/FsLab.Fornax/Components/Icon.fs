module internal IconComponent

open Html

let icon (iconClass:string) =
    span [Class"icon"] [
        i [Class iconClass] []
    ]