#r "nuget: FsLab.Fornax, 0.0.0"

#if WATCH
let urlPrefix = 
  ""
#else
let urlPrefix = 
  "{{BASE_URL}}"
#endif

let prefixUrl url = sprintf "%s/%s" urlPrefix url