## Introduction

Synthesis assignment semester 2 - DuelSys consisting of website application, desktop application and documentation.
Vartan Dyulgeryan - i482834

# Reference links

- [Website application - Synthesis DuelSys inc.](https://i482834.luna.fhict.nl)

If you're new to .NET you'll want to check out the tutorial, but if you're
already a seasoned developer considering building your own .NET app with GitLab,
this should all look very familiar.

## Notes
**URS - design/wireframes**

I know the design is alot different from the wireframes, that is because
for the desktop application to show the matches via calendar after some thought i realised 
that it will just get too complicated to display it and then updating the scored of the matches as well will get 
more complicated.

For the website at first i wanted to create a profile page but changed to leader board
so that i could finish on time with the synthesis implementing one _major_ and one _minor_ requirement
The requirements are updated for the leader board and i removed the ones with the profile page.

**Desktop application**

For the score validation method is not the best to do two things at once because
methods are supposed to do only one thing for example one bool method for the score is it valid 
and one method of return type Match were it determines who is the winner.

## Major Requirements - Functional Requirements

_**FR-07: Support multiple sport types**_

Extend the software solution to also support different sport types (e.g. basketball, tennis, 
quidditch, league of legends, chess, etc.). It should be possible, for a staff member, to 
specify which sport type when creating new tournament. Make sure that when registering 
the result of a game the official scoring rules are followed. 

## Minor Requirements - Functional Requirements

_**FR-09: Support leader board**_

Extend the software solution to also support a leader board. When there is an ongoing 
tournament, any interested party (e.g. a sport enthusiast, a player) can retrieve the list of 
players participating in the tournament, ordered based on their current position/rank in the 
tournament.  
