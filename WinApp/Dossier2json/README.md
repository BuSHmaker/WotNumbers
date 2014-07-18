World of Tanks Dossier Cache to JSON 
------------------------------------
Version v9.2.0


### About

* Author: Marius Czyz aka Phalynx
* Contact: marius.czyz@gmail.com
* Website: http://www.vbaddict.net
* Wiki: http://wiki.vbaddict.net
* Repo: https://github.com/Phalynx/WoT-Dossier-Cache-to-JSON

### Respect for my work
Please respect my work invested in this project. You have to give me credit on your application or website.


### Demo Systems:
* vBAddict WoT Performance Analyzer Charts http://www.vbaddict.net
* WOT Statistics http://www.vbaddict.net/wotstatistics
* WotDossier http://forum.worldoftanks.ru/index.php?/topic/890389-

 
### Dossier File Structure
* More information regarding the file structure on the Developer Wiki:
* http://www.vbaddict.net/content/10-WoT-Developer-Wiki


### Supported Versions
* WoT 0.4.x (dossier version 10)
* WoT 0.5.x (dossier version 17)
* WoT 0.6.x, 0.7.1.x, 0.7.2.x, 0.7.3.x (dossier version 18)
* Wot 0.7.4.x, 0.7.5.x (dossier version 20)
* WoT 0.8.0.x, 0.8.1.x (dossier version 22)
* WoT 0.8.2.x (dossier version 24)
* WoT 0.8.3.x (dossier version 26)
* WoT 0.8.4.x, 0.8.5.x (dossier version 27)
* WoT 0.8.6.x, 0.8.7.x (dossier version 28)
* WoT 0.8.8.x (dossier version 29)
* WoT 0.8.9.x, 0.8.10.x (dossier version 65)
* WoT 0.8.11.x (dossier version 69)
* WoT 0.9.0.x (dossier version 77)
* WoT 0.9.1.x (dossier version 81)
* WoT 0.9.2.x (dossier version 85)


### Contributors WoTDC2J.py
* Phalynx
* Gottzilla
* NJSaaiman



### Usage
* wotdc2j.py <dossier.dat> [rfkst]

#### Parameters
* -f - By setting f the JSON will be formatted for better human readability
* -r - By setting r the JSON will contain all fields with their values and recognized names
* -k - By setting k the JSON will not contain Kills/Frags
* -s - By setting s the JSON will not include tank info and outputs to console
* -t - By setting s the JSON will include tank information, use this in combination with -s



#### Example
* python.exe wotdc2j.py dossier.dat -f -r
