
turn text file into CSV so write out name, content, author as comma seperated values 

test the code .. need to mock file system.


turn post method into form of db persistance / saving 

Add mongo db 
save Posts to a database.
1. install mongo get working independently. Done 
 
2. hook the two systems up.

make async instead 
using: http://blog.aspcore.net/post/2017/07/19/mongodb-crud-operations-in-asp-net-core-with-c

NOW
Get and get by title working. 


To do: 

from front end : GET
Serve the frontend blog page ... Listen for query param..
then serve a certain page.
when click on a link it passes in identifier as query param.

Fix error with postTime
Post 
Update
Delete.
Error handling.

deploy mongo - do don't have to mannually run it

Test it 
Refactor
depolying it.

Deploy app and DB in docker containers 
orchestrate them with docker compose
deployment and hosting - deploying a docker container
 







How to update info in the database: http://mongodb.github.io/node-mongodb-native/api-articles/nodekoarticle1.html



Learnings from GET:

About action results (its cool that you can see them in the network tab like when your looking on the front end)  
and the arrow functions (how the first thing is the object / the thing you would be passing to it in the parenthesis.. 
then after the arrow is the function (with the return implied ?)! Also how it’s better to make things async so you can 
handle lots of requests and await is like a bookmark ... so where you’d put a hold when you know something is going to take
 a long time? Also errors and what they actually are and bubbling up means through the program to the interface).

