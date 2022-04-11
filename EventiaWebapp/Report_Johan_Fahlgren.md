# [INLÄMNINGSUPPGIFT ASP.NET](https://github.com/johan-fahlgren/ASPNETCore_Inlamningsuppgift1-2)


## Reflektioner

- Sidan känns rätt behörighetssäker då man måste vara inloggad och ha rätt roll för att komma åt
  relevanta sidor. Några första steg som skulle förbättra är att det åtminstone finnas
  tvåstegsverifiering, alternativ epost för recovery och kanske något tidsintervall som lösenord
  måste bytas inom. 

- En vidare utveckling av strukturen skulle kanske vara att flytta min original `Pages`-mapp till 
  `Areas` och skapa egna utöver `Identity`-mappen, kanske ett Main med Events och sedan för de 
  olika rollerna. Koden känns just nu lite svårnavigerat när man tittar på den.   

- Valde att lösa förfrågan om att få rollen "orginizatör" genom att skapa en ny Model-klass 
  `RoleApplication`  
  Genom att bryta ut det till en egen Model finns möjligheten att bygg vidare på den senare om 
  man exempelvis vill ta in mer information orginizatören som orginisationsnummer etc. 
  Vid en sådan vidare utveckling borde kanske tabell förhålladet gå från One-to-Many till ett 
  One-to-One förhållade så att en `EventiaUser` bara kan kopplas till en orginization. 
  
- Som vanligt saknar min kod `if-statements` när det ska hämtas och jämnföras data. något jag
  vill bli bättre på. Samt att lära mig mer om och utnyttja `Logger klassen` i dessa. 

<br/>

> Johan Fahlgren, 2022-04-11
