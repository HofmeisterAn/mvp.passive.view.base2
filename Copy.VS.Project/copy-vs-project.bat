@Echo off

Set TEMPLATE_NAME=Mvp.Passive.View.Base2
Set TEMPLATE_NAME_NEW=Mvp.Passive.View.Base2.New

Echo Remove .git directory.
for /d /r .. %%a in (.git\) do if exist "%%a" rmdir /s /q "%%a"

Echo Remove obj directory.
for /d /r .. %%a in (obj\) do if exist "%%a" rmdir /s /q "%%a"

Echo Remove bin directory.
for /d /r .. %%a in (bin\) do if exist "%%a" rmdir /s /q "%%a"

Echo Clean README.md.
break > ..\README.md

Echo Copy project to new name.

Set LIST=Midelware Model Presenter View

for %%i in (%LIST%) do (
  vsrename.exe %TEMPLATE_NAME%.%%i %TEMPLATE_NAME_NEW%.%%i ..\%TEMPLATE_NAME%.%%i
)

vsrename.exe %TEMPLATE_NAME% %TEMPLATE_NAME_NEW% ..\%TEMPLATE_NAME%
vsrename.exe %TEMPLATE_NAME% %TEMPLATE_NAME_NEW% ..