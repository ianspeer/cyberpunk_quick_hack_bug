# Cyberpunk 2077 Breach Protocol|Quick Hack Bug

There is a bug in Cyberpunk 2077 that prevents users from receiving quick hacks from breach protocol on access points. This is outlined [on the CD Projekt Red forums](https://forums.cdprojektred.com/index.php?threads/not-getting-quickhacks-from-access-points.11061788) on a number of threads. 

If you'd like to contribute, please create a pull request or request access to the google sheet.

### Misunderstandings around quickhacks
- Quick hacks only display the highest rated version in the Cyberdeck inventory so it can be difficult to determine when you receive a new quick hack. This bug is separate from that behavior. The quick hack inventory display is outlined well in [this comment by Hayte](https://forums.cdprojektred.com/index.php?threads/not-getting-quickhacks-from-access-points.11061788/page-11#post-12938581) on the cyberpunk forums.
- The Datamine Viruoso doesn't give 100% chance to get a component. It increases your chance by 100% (doubling it).

### Minimum Requirements to receive (legendary) quick hacks
There are a number of terminals with increased rate to receive legendaries. It's possible to glitch/cheat out of Watson directly after The Rescue and receive a quickhack at the terminals in the Serial Suicide mission. The only requirements seem to be the minimum level of int to hack the console (10). There is a lower chance, but you can receive legendary quickhacks at level 3 int as outlined in [this video](https://www.youtube.com/watch?v=03IFHh7vNXI).

# Testing
All saves, unless otherwise indicated, are running on patch 1.31.

## Testing methods
 1) Load save.
 2) Give character 12 int and Virtuoso perk to speed testing via Simple Menu mod.
 3) Use Simple Menu mod to teleport to previously marked location (i.e. in front of an access point from Gig: Serial Suicide).
 4) Test nearby access points that require 10 int from Gig: Serial Suicide.
 5) Re-load save and repeat.

## Leads
- [Spreadsheet](https://docs.google.com/spreadsheets/d/1c7ecwMkDuBdhVa_tihP4BBcrnbKVNVzieakJS2CGlj0/edit?usp=sharing) with bugged/successful attempts. This also keeps track of different fixes that have been attempted and a list of fixes to try.
  
- Quest Fact comparison
  - Quest facts have been exported from the saves and separated into:
    - factsWithDifferingValues.json - facts that match on hash and name, but have a different value. 
    - identicalfacts.json - facts that match on hash, name, and value.
    - uniqueBuggedFacts.json - facts that only exist in the bugged playthrough
    - uniqueSuccessfulFacts.json - facts that only exist in the successful playthrough

 - The [CyberCAT SimpleGUI Save Editor](https://www.nexusmods.com/cyberpunk2077/mods/718) was forked to allow importing quest facts to a given save. After finding the save where the bug was first encountered, I imported the full list of quest facts from the working save 39 minutes prior. This failed to fix the issue. 
 - Some quest facts are changed on load/during runtime, so some additional testing is required before ruling this out as a potential fix.
    
## Dead Ends
- Cybertweak game logs for successful and bugged attempts.
  - The [cybertweak images folder](https://github.com/ianspeer/cyberpunk_quick_hack_bug/tree/master/cybertweak%20images) contains screenshots of the logs from each attempt.
  - The logs don't seem to indicate any problem.

### Useful tools
 - [Cyber Engine Tweaks](https://wiki.redmodding.org/cyber-engine-tweaks/) for game debug messages, commands, and running other tools.
 - [CyberCAT SimpleGUI Save Editor](https://www.nexusmods.com/cyberpunk2077/mods/718) for removing quest items and setting quest facts.
 - [Simple Menu](https://www.nexusmods.com/cyberpunk2077/mods/818) for teleporting to watson and giving perk/level points.
 
### Helpful comments
 - [page 4 - Xirton](https://forums.cdprojektred.com/index.php?threads/not-getting-quickhacks-from-access-points.11061788/page-4#post-12683303)
 - [page 5 - CrackedGoddess](https://forums.cdprojektred.com/index.php?threads/not-getting-quickhacks-from-access-points.11061788/page-5#post-12703742)
 - [page 7 - 1cmf](https://forums.cdprojektred.com/index.php?threads/not-getting-quickhacks-from-access-points.11061788/page-7#post-12778163)
 - [page 10 - HardyVisto](https://forums.cdprojektred.com/index.php?threads/not-getting-quickhacks-from-access-points.11061788/page-10post-12847559)
 - [page 10 - tahapenes](https://forums.cdprojektred.com/index.php?threads/not-getting-quickhacks-from-access-points.11061788/page-10#post-12896825)
 - [page 11 - Hayte](https://forums.cdprojektred.com/index.php?threads/not-getting-quickhacks-from-access-points.11061788/page-11#post-12938581)
 - [Gaming Mod Squad Video](https://www.youtube.com/watch?v=M5iRzzzT5Vo)

