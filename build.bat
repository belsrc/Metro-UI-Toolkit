REM Build the project exe
"C:\Windows\Microsoft.NET\Framework\v4.0.30319\msbuild.exe" "E:\Programming\!Csharp\Metro UI Toolkit\Metro-UI-Toolkit\MetroUiToolkit.sln" /property:Configuration=Release

REM Generate SandCastle Documentation
"C:\Windows\Microsoft.NET\Framework\v4.0.30319\msbuild.exe" "E:\Programming\!Csharp\Metro UI Toolkit\Metro-UI-Toolkit\MutDocs\MutDocs.shfbproj"

REM Clean up
COPY "E:\Programming\!Csharp\Presentation.css" "E:\Programming\!Csharp\Metro UI Toolkit\Metro-UI-Toolkit\MutDocs\Help\styles"
COPY "E:\Programming\!Csharp\TOC.css" "E:\Programming\!Csharp\Metro UI Toolkit\Metro-UI-Toolkit\MutDocs\Help"
"C:\Program Files\7-Zip\7z.exe" a -mx9 "E:\Programming\!Csharp\Metro UI Toolkit\Metro-UI-Toolkit\MutDocs.7z" "E:\Programming\!Csharp\Metro UI Toolkit\Metro-UI-Toolkit\MutDocs\Help"

REM Open the generate docs
"E:\Programming\!Csharp\Metro UI Toolkit\Metro-UI-Toolkit\MutDocs\Help\Index.html"
exit