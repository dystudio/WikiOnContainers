# Wiki app that can be deployed independently

This is Aiursoft Wiki App independent version. It was not a service of Aiursoft micro-service platform so that it allows you to deploy it to your own server.

Wiki app is based on .NET Core 2.0.

Wiki app allows wiki workers to focus on writing wiki in markdown. It will automatic fetch new wiki updates, compile the markdown to HTML, and print a friendly web page for viewers.

## How to run


### Dependencies

* .NET Core 2.0 SDK 

Download it [here](https://www.microsoft.com/net), supports Windows, Linux and Mac

### Run with command

Please excuse the following commands in the project folder:

```bash
$ dotnet restore
$ dotnet run
```

In development mode, the app will automatically create its database. It is using an SQLite database. But you can change its database to SQL Server or MySQL easily.

For more info about switching database, please reference document of [EF Core](https://docs.microsoft.com/en-us/ef/core/providers/).

In production mode, you need to create the database by the following command:

```bash
$ dotnet ef database update
```

### Run in Visual Studio

Please install Visual Studio 2017 with .NET Core development kit.

1. Double click the `.sln` file.
2. Strike `F5`.

### How to fetch wiki data from git provider

1. Create a new git repo to maintain your wiki content. All your wiki need to be written in markdown.

```
For example, I've created this repo:
https://github.com/AiursoftWeb/Home
```

2. Create a file named `structure.json` and commit it to your git repository.

```
For example, I've put the file here:
https://github.com/AiursoftWeb/Home/blob/master/structure.json
```

3. Publish the git repository to Github.com or Gitlab.com or you own Gogs service.
```
For example, I've published this repo here:
https://github.com/AiursoftWeb/Home
```

4. Get the URL of the raw content of that `structure.json`
```
For example, my URL is:
https://raw.githubusercontent.com/AiursoftWeb/Home/master/structure.json
```
5. Change the `ResourcesUrl` property in `appsettings.json` to your url. But do NOT append `structure.json`.

```
For example, my Reources url is:
https://raw.githubusercontent.com/AiursoftWeb/Home/master/
```
6. Make sure that the Wiki app has the right to access that content.

7. Start the wiki app. Send an empty HTTP post request to `/home/seed`. This will trigger the wiki app to fetch any data from the resources. The app will get all articles and compile the markdown to HTML and save it in its database.

```
For example, on my local machine, I can execute the command:
$ curl -d "" http://localhost:5000/home/seed
```

8. Configure your web hook on your git service provider. When any push operation send an post request to `http://yourwikiservice/home/seed`. This will allow wiki app automatic fetch data when the git repo was changed.

9. After configuring those steps, you can focus on writing document and push it to git service. Wiki app will always be displaying the latest document.


## How to contribute

There are many ways to contribute to the project: logging bugs, submitting pull requests, reporting issues, and creating suggestions.

Even if you have push rights on the repository, you should create a personal fork and create feature branches there when you need them. This keeps the main repository clean and your personal workflow cruft out of sight.

We're also interested in your feedback for the future of this project. You can submit a suggestion or feature request through the issue tracker. To make this process more effective, we're asking that these include more information to help define them more clearly.