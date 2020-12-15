# Documentation webservice WATIHOTEL


## Introduction 
Bienvenue dans la documentation du webservice watiHotel. 
Dans cette documentation nous étudierons l'utilisation et 
la construction du webservice watiHotel. 

En effet, ce webservice permet notament de récupérer
la liste de tous les hôtels partenaires,
ainsi que toutes les destinations disponibles.

Ici le principe est simple, seulement deux type d'objet sont présent
dans les données :

* **hotels** : 
Liste de tous les hôtels partenaires.

* **destinations** : 
Liste de toutes les destinations de tous les hôtels référencés. 


## Modèles des ressources
On entant par ressource, toutes les données par types qui transitent
dans le fichier JSON du web service. 
Toutes les ressources sont englobées dans une même balise "DATA".

  ```
  {
    "data" : 
    {
        "hotels" : {...}
        "destinations" : {...}
        "reservations" : {...}
    }
  }
  ```


*******

#### Ressources d'un hôtel  
| Libelle         | Type        |  Description 
| -----           |-----        | -----
| id              | `integer`   | Numéro unique permettant d'identifier un hôtel
| name            | `string`    | Nom de l'hôtel
| description     | `string`    | Courte description de l'hotel
| destination     | `integer`   | Identifiant de la destination liée à l'hôtel
| address         | `string`    | Adresse complète de l'hotel (n° voie + rue)
| price           | `decimal`   | Prix en euro d'une reservation d'une chambre. <br> Le tarif est le même pour toutes les chambres de l'hôtel. <br>
| room_available  | `integer`   | Nombre de chambres encore disponible dans l'hôtel.<br> Ne peut pas être supérieur à la capacité max. <br> Si à 0 l'hôtel devient indisponible
| room_max        | `integer`   | Nombre de chambres maximum d'un hôtel
| image           | `string`    | Chemin menant à l'image de présentation de l'hôtel

*******

#### Ressources d'une réservation 
| Libelle    | Type        |  Description 
| -----      |-----        | -----  
| id         | `integer`   | Numéro unique permettant d'identifier une réservation      
| date_start | `date`      | Date à laquelle la réservation commence (chambre occupée)
| date_end   | `date`      | Date à laquelle la réservation se termine (chambre occupée est de-nouveau disponible)
| hotel      | `object`    | Identifiant de l'hôtel associé

*******

#### Ressources d'une destination 
| Libelle    | Type        |  Description 
| -----      |-----        | -----  
| id         | `integer`   | Numéro unique permettant d'identifier une destination      
| city       | `string`    | Nom de la ville de la destination
| country    | `string`    | Nom du pays de la destination 
| image      | `string`    | Chemin menant à l'image de la destination

*******

## Réponses des requêtes

#### 200 Requête Réussie
  ```
  {
    "data" : {...} [type=array]
  }
  ```
*******

#### 400 Demande Incorrect
  ```
  {
    "error": "Bad Request Error", [type=string]
    "message": "One of the parameters is invalid" [type=string]
  }
  ```
*******

#### 401 Non authorisé
  ```
  {
    "error": "Unauthorized", [type=string]
    "message": "Error you have no export right" [type=string]
  }
  ```
*******

#### 403 Interdiction
  ```
  {
    "error": "Forbidden", [type=string]
    "message": "You are not allowed to access this request, only Prescriber admin are allowed" [type=string]
  }
  ```
*******

#### 404 Non trouvé
  ```
  {
    "error": "Not Found", [type=string]
    "message": "Entry for Resource not found" [type=string]
  }
  ```
*******

#### 424 Echec de dépendance
  ```
  {
    "error": "Failed Dependency", [type=string]
    "message": "The request failed" [type=string]
  }
  ```
*******

#### 429 Requêtes trop nombreuses
  ```
  {
    "error": "Too Many Requests", [type=string]
    "message": "Only 60 requests per minute are allowed" [type=string]
  }
  ```
*******

###### Author: *Vo Tran Thanh Luong*. Also, I would like to thank all the contributors/translators for your work making this greater.