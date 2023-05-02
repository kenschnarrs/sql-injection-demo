# sql-injection-demo

## Setup:

### Frontend
1. ```cd frontend```
2. ```npm start```

### Backend
1. ```cd backend```
2. ```dotnet run```

### Database
1. Download a MySQL database
2. Set up the configuration as so:
```"server=localhost;user=root;database=sys;port=3306;password=my_password2"```
3. Create a ```APP_USERS``` table with with a primary key ```"id"```
4. Run the app and click "regenerate tables"

## Information
There are three controllers. One is a secure controller in which SQL Injection is prevented using Dapper. Another is an insecure controller in which strongs are directly concatenated. If you follow the instructions that are shown when running the app, you will notice that you can select all users (rather than your own) and drop database tables, etc. See the video below for a walkthrough:
[Demonstration Video](https://youtu.be/qaQhtr0lupU)

