# Moodle feladat, 30-as csapat
- Kiss Bálint
- Hortobágyi Axel
- Zsigár Péter
## Környezet Beüzemelés

SQlite hozzáadása nuget csomagokhoz.
A projektet [Visual Studio 2022](https://visualstudio.microsoft.com/downloads/) (64bit) Version 17.9.5 valósítottuk meg.

A projekt futtatásához szükséges a [.Net 8.0](https://dotnet.microsoft.com/en-us/download) letöltése is.

## Swagger beüzemelése

A Swagger megfelleő működéséhez a [Visual Studion](https://visualstudio.microsoft.com/downloads/) belül több dolgot is szükséges lesz letölteni.

A NuGetPackage managerből(*amelyet úgy tudunk előhozni a jobb oldalon található Solution Explorernél jobb klikkelünk a Moodle projektre majd ->Manage NuGet Packages*) letöltjük a Swashbuckle.AspNetCore-t 6.5.0 verzióját.

Előfurdulhat hogy a Visual Studio nem ismeri fel az Annotations könyvtárat.Ennek a problémának a kiküszöbölését úgy érhetjük el hogy Package Manager Consoleból(*A felső navigációs sorban a Windows gomb melletti keresőnél rákeresünk*) lefuttatjuk az alábbi sort:*Install-Package Swashbuckle.AspNetCore.Annotations -Version 6.2.3*

A program futtatásához használt protokoll:**HTTP**


