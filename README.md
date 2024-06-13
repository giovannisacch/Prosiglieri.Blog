# Prosiglieri.Blog

## Running the application:
To run this application you just need to run docker-compose up on our root folder 
Swagger at http://localhost:5000/swagger/index.html

## Decisions:
### Architectural:
I used a relational database because I have created many more projects with it, which makes development quicker. However, since we expect to have more reads than writes, a NoSQL database like MongoDB would be a better fit.
Since we expect to have more operations for getting all posts than creating a comment, I decided to create a property for the comment count on blog posts to avoid a join in comments every time a user needs a list.
To make it quicker, I'm updating the comment count when adding a comment. However, considering scaling and concurrency, throwing an event to add the comment to a queue or using a trigger that updates it when a new comment is added would be better.

### Code decisions:
In a project where we expect to have more entities in the future, I would create a BaseRepository to reuse simple CRUD operations.
Since we didn't add validations, I just maintained public setters without set methods on my domains.
Usually, I use an Either class to handle application service errors, but since I only have it on AddComment, I'm just returning null.
I didn't add tests to the application service since testing mappings and domain logic covers pretty much what we have in this project.
