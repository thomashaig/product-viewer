# product-viewer

This project is to demonstrate the learning of .NET Core and use it for a product database view. Initially, the project will be following the project "Building your first .NET Core API tutorial from Pluralsight, before branching and creating the project itself as well as a Vue templated front end.

## Installation and run

Code was build using Visual Studio Code wist MSSQL Server. The database install is local and will be built in the migration file, along with seeding the products. The migration will not be re-run once the database is built.

To begin on command line use dotnet run

The page main page can be viewed at localhost:5001

In Visual Studio the program should be able to run using the standard "Play" button.

## A description of the project

I was able to follow the .NET Core tutorial full after setting up my own local instance of SQLServer. Also using Visual Studio Code instead of Visual Studio I was able to learn more of the dotnet command line tools, which I feel are useful.

The overall tutorial, with some alterations, I believe was able to satisfy the requirements of the test. The tutorial more or less created a set of products (in the tutorial, cities) that could additionally be "drilled down" to explore features (tutorial: points of interest). Additionally, it added endpoints for adding, editing and deleting those features. I hooked 2 of these end-points, adding and deleting, into my front end. This would allow for features to be deleted and re-added to update which, while not ideal, would suffice. So edit could be left as an addition, which would likely be next on the "feature list". Additionally, endpoints could and would need to be created for adding products themselves. As products could add features at the same time, this would take additional work, and again, would be the next part of this process. It would need some additional scoping for the best user flow to do this.

The front end of the project was built in Vue, and to extend myself and make it a more true SPA I used Vue Router for the routing components, which again, was a learning experience. I believe with a better understanding of the .NET build chain I would be able to split this into multiple files better and to have better templates and separation of concerns. Although for the scale of the project the current layout none the less suffices. Additionally, in the toolchain, I did not compile any SASS files. I did not add many additional styles; however this would be an essential step in my learning. Many companies have a reasonably strict build chain process, and this would be one of the first things I would be enthusiastic to learn.

For the styling, while I wanted to use a framework other than Bootstrap, I thought that this might be too much of an extension at this point. I used Bootstrap 4 and used some of the newer features to give some level of extension to what I was doing, as currently, I had only used Bootstrap 3.3 before this. Material design was considered and would be something I'd like to learn offline in the very near future.

A simple script seeds the products. This script could be easily improved and more random seed generation done, by using Lorum Ipsum style generators, again; however I would have needed to investigate the best way to do this. I believe the seeder itself is enough to cover products in such a way they can be displayed and used. However, if this were a real system things such as pagination and lazy loading would need to be considered.

## What could be improved?

Several things could be improved. Scale, for example, would be problematic for the current viewer, as mentioned above, things such as pagination or lazy loading would need to be considered.

Also considering user flow, the delete is automatic, and a confirmation of this action would indeed be worthwhile.

Styling wise, besides actual layout, transitions, which are reasonably simple to implement using Vue, could be added to the feature cards, such as a flip effect for when adding features.

Datawise would need to consider product images and feature images, and how these would be uploaded. Also on this, an expansion of the products, with things such as snippets (to display as summaries on the main page), prices, etc. would be useful. At a higher level "featured products" could feature more prominently on the home page, for example.

A consideration of this would end up a full SPA or if pages such as Privacy Policies etc. would be separate routes would also need to be considered. Again, with more experience with the toolchain, I could better split components and concerns which would make this decision easier.

GIT Branching wise I started late and could have also used a better structure based on the lessons. I believe I was able to use it partially correctly.

## Summary

Overall I think following the tutorial I did was the best way to approach this. Moreover, by not using their example code, and also using VS Code instead of VS, I was able to make enough mistakes of my own that I believe I was able to learn a significant amount about .NET Core in general. .NET Core has a large number of similarities to Laravel and was not as much of a jump as I thought it might be.

With the use of Vue I attempted to extend myself a bit and the experience was quite humbling in that I learnt that there is probably a lot more to learn!

Code styling wise I wish I had done more commenting during the tutorial, as cross-referencing with my notes is harder than expected. I also need to look at my consistency on bracketing etc. A code style guide is something I need to learn to better adhere to, and I hope that your organisation has one!

## Thank you

Thank you again for the opportunity to present this project, and I hope that it satisfies that I am both willing and able to learn. I look forward to any feedback and am willing and able to make any changes if necessary.
