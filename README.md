# SurveyMakerKata

## Pourquoi ce Kata?
Ce Kata à été créé à l'occasion du Meet-Up: "Apréro Tech #5"
Il sert de base à une reflexion sur le refactoring de code legacy.

### Le code est immonde!
En effet. C'est le but! Identifier les problème de dette technique qu'on trouverai typiquement dans du code legacy, et les corriger du mieux possible!

### Et comment faire ?
Il faut procéder par étapes :
* Lire le code
* Ajouter des Tests Unitaires avec NUnit et NFluent
* Refactorer le code par petites itérations régulières
* Et recommencer !

## Pourquoi en C#.NET ?
Le C# est mon language de prédilection ! Alors quitte à présenter du code, autant le faire dans un language auquel je suis à l'aise !

### Que faut il pour utiliser se Kata?
Je me suis limité à l'utilisation de librairies simples et disponibles gratuitement, comme NUnit et NFluent.

## Ai-je le droit de cloner / modifier ce repo?
Bien sûr ! Il est la pour s'entrainer !

### Quel ont été les étapes de refactorisation de ce code ?

Hash du commit	| Commentaire
ad338c3a61		| Base du code, classes peu ou pas interfacés, principes SOLID non respecté.
158e6b3d01		| Ecriture en JSON, création du QuestionHelper pour sortir les traitement des questions du code principal
f8867b3a06		| Plus d'interfaces, QuestionHelper n'est plus une classe statique et peu être mocké
				| Ecriture de deux fichiers JSON pour matcher la demande de KONG
7eab7c42db		| Ajout de tests, ce qui aurait dû être la première étape de cette refactorisation...
73098b972d		| Ajout des dernières classes, séparation du code et tests. Refactorisation terminée.
