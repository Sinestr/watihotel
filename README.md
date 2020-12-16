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

#### **Adresse de l'api : http://watihotelapi.azurewebsites.net/**

## Modèles des ressources
On entant par ressource, toutes les données par types qui transitent
dans le fichier JSON du web service. 
Toutes les ressources sont englobées dans un objet "DATA".

json_sample :

  ```
  {
    "Hotels":
    {
      "Id": 1,
      "Name": "",
      "Description" : "",
      "Destination" : 1,
      "Address": "",
      "Price" : 0,
      "Room_available": 0,
      "Room_max": 0,
      "Image" : "",
      "Disponible": object,
    },
  
    "Disponible":
    {
      "Room_available": 0,
      "Date_dispo": "yyyy-MM-dd",
    },
  
    "Reservations":
    {
      "Id": 1,
      "Date_start": "yyyy-MM-dd",
      "Date_end": "yyyy-MM-dd",
      "Status": false,
      "Hotel" : 1
    },
  
    "Destinations" :
    {
      "Id" : 1,
      "City" : "",
      "Country" : "",
      "Image" : ""
    }
  }
  ```


*******

#### Ressources d'un hôtel  
| Libelle         | Type        |  Description 
| -----           |-----        | -----
| Id              | `integer`   | Numéro unique permettant d'identifier un hôtel
| Name            | `string`    | Nom de l'hôtel
| Description     | `string`    | Courte description de l'hotel
| Destination     | `integer`   | Identifiant de la destination liée à l'hôtel
| Address         | `string`    | Adresse complète de l'hotel (n° voie + rue)
| Price           | `decimal`   | Prix en euro d'une reservation d'une chambre. <br> Le tarif est le même pour toutes les chambres de l'hôtel. <br>
| Room_max        | `integer`   | Nombre de chambres maximum d'un hôtel
| Image           | `string`    | Chemin menant à l'image de présentation de l'hôtel
| Disponible      | `object`    | Liste des dates réservées dans l'hôtel

*******

#### Ressources d'une disponibilité 
| Libelle        | Type        |  Description 
| -----          |-----        | -----  
| Room_available | `integer`   | Nombre de chambres encore disponible dans l'hôtel.
| Date_room      | `date`      | **"yyyy-MM-dd"** Date à laquelle la réservation commence (chambre occupée)

*******

#### Ressources d'une réservation 
| Libelle    | Type        |  Description 
| -----      |-----        | -----  
| Id         | `integer`   | Numéro unique permettant d'identifier une réservation      
| Date_start | `date`      | **"yyyy-MM-dd"** Date à laquelle la réservation commence (chambre occupée)
| Date_end   | `date`      | **"yyyy-MM-dd"** Date à laquelle la réservation se termine (chambre occupée est de-nouveau disponible)
| Status     | `boolean`   | false = impayé | true = payé
| Hotel      | `integer`   | Identifiant de l'hôtel associé

*******

##### Ressources d'une destination 
| Libelle    | Type        |  Description 
| -----      |-----        | -----  
| Id         | `integer`   | Numéro unique permettant d'identifier une destination      
| City       | `string`    | Nom de la ville de la destination
| Country    | `string`    | Nom du pays de la destination 
| Image      | `string`    | Chemin menant à l'image de la destination

*******

## Les routes et leurs fonctionnalités
Ici une requete va permettre de récupérer des informations provenants 
des données Wati Hôtel (REQUETE GET). Néanmoins, elle va aussi pouvoir effectuer
des actions précises sur les données Wati Hotel (REQUETE POST).

### Requêtes GET

* **[Route("watiHotel")]**  
    * Liste de tous les hôtels partenaires, de toutes les destinations et de réservations.
    
* **http://watihotelapi.azurewebsites.net/watiHotel/hotels** 
    * Liste de toutes de tous les hôtels partenaires. 
    
* **http://watihotelapi.azurewebsites.net/watiHotel/hotel/id/{idHotel}**
    * Obtient un hôtel par son identifiant, si aucun hôtel n'existe avec cet ID le résultat sera null.

* **http://watihotelapi.azurewebsites.net/watiHotel/hotel/nom/{nomHotel}**
    * Obtenir un hotel par son nom, si aucun hôtel n'existe avec ce nom le résultat sera null.

* **http://watihotelapi.azurewebsites.net/watiHotel/hotel/{idHotel}/reservations**
    * Retourne toutes les réservations d'un hôtel par son identifiant.
    
* **http://watihotelapi.azurewebsites.net/watiHotel/reservations**
    * Liste de toutes les réservations effectuées.   
    
* **http://watihotelapi.azurewebsites.net/watiHotel/reservation/id/{idReservation}*
    * Obtient une reservation par son identifiant, si aucune réservation n'existe avec cet ID le résultat sera null.
    
* **http://watihotelapi.azurewebsites.net/watiHotel/destinations**
    * Liste de toutes les destinations possibles.   
    
* **http://watihotelapi.azurewebsites.net/watiHotel/destination/id/{idDestination}**
    * Obtient une destination par son identifiant, si aucune destination n'existe avec cet ID le résultat sera null
    
*****
    
### Requêtes POST  

#### Réserver un hôtel
En effet le but de cette requête est d'envoyer une nouvelle réservation. 
Pour cela il va falloir envoyer :
 * une date de début de réservation
 * une date de fin de réservation
 * identifiant de l'hôtel, dans lequel la réservation souhaite se dérouler

Toutes les données correspondantes (**cf. Model de ressources**).

Si tout ce passe bien on retourne :
```
"Type": "Success: Reserversation complete",
"Message": "La réservation pour l'hôtel Hotel Marin Contact Hotel a bien été prise en compte !"
``` 

Si jamais la réservation ne s'éffectue pas, c'est qu'on retourne une erreur. 
En voici la liste : 
```
"error" : "Not Available" [type=string]
"message" : "Aucune chambre disponible pour cet hôtel" [type=string]
```  

```
"error" : "Not Found" [type=string]
"message" : "L'hôtel n'existe pas. Veuillez choisir un hôtel présent sur le liste !" [type=string]
```

```
"error" : "Error Date" [type=string]
"message" : "Dates de réservation incorrectes" [type=string]
```