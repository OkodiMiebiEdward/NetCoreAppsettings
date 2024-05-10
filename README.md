Prior to .Net Core, sensitive information were stored in web.config for web applications and app.config for other UI like console and desktop. With the introduction of .Net Core, there are
actually 5 areas were information can be safely stored to be used in the application. These areas are:
1.Command line
2.Environment Variable
3.User Secret
4.Environment specific Json File e.g Appsettings.development.json
5.Appsettings.json 

These areas are quite important. This project generally diaplays how information like connection strings can be easily accessed.
