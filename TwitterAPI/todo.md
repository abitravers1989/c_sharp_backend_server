TODO 
1.Check tag is valid category.
2.Deploy 
3.Hack in and try to ruin.
4.Make safe 





Launching Friday 22nd July

EC2 aws = virtual machines

insance goes into vpc - virtual private cloud 
security group like a firewall that goes around instance 
ssh - allow connections from port 22 from anywhere on the internet source 0.0.0.0/0
once set up instance need to go and disable SSHs 
Most common hack is people would start mining crypto on your instanse or doing crimia activity from your vm as they can just keep guessing passwords 

need to add http so people can access it through iternet instead of just through shh

will allow connections from port 80 (the standard port for http traffic)- that what the browser runs on 

https runs on 443 


if you wanted to set the Shh to one IP address ie your home then you set it to this IP
then set up a vpn which directs traffic to a comp or rasberry pie running at your home address then use this machine to access your insanstance.
setup a comp at home. SSH into your home comp with 
VPN is just SSH - can use a password 
or a pen key - public private keys. -- way to do authentication!! 
public private keys are more robust. (encrytion and alice and bob thing )

public key that aws will have then a private key that only i will have 
when i do sshing then i use this private key to get into it

Public DNS: ec2-34-245-139-42.eu-west-1.compute.amazonaws.com (can see instance if put this address in browser address bar)
need to make copy of private key ... .pem 

--------




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
 








 To do 
 make app use https

 secure PUT and Delete 
 bearer token authentication implementation C sharp
 https://andrewlock.net/creating-and-trusting-a-self-signed-certificate-on-linux-for-use-in-kestrel-and-asp-net-core/








 https://www.humankode.com/asp-net-core/develop-locally-with-https-self-signed-certificates-and-asp-net-core





How to update info in the database: http://mongodb.github.io/node-mongodb-native/api-articles/nodekoarticle1.html



Learnings from GET:

About action results (its cool that you can see them in the network tab like when your looking on the front end)  
and the arrow functions (how the first thing is the object / the thing you would be passing to it in the parenthesis.. 
then after the arrow is the function (with the return implied ?)! Also how it’s better to make things async so you can 
handle lots of requests and await is like a bookmark ... so where you’d put a hold when you know something is going to take
 a long time? Also errors and what they actually are and bubbling up means through the program to the interface).

