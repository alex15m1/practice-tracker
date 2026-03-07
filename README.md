# Practice Tracker

This is a small web app I made with ASP.NET Core MVC to track daily (instrumental) practice sessions. You can add practice entries and see them on a calendar with corresponding colors.
Each day shows up as good, okay, or bad depending on what was practiced and how long the practice session was.

This application was built get an introduction on how ASP.NET MVC works and how to connect a web app to a database using Entity Framework Core.

The app stores practice sessions in a SQLite database. The controller reads the entries from the database and decides what status each day should have. The calendar then shows the results.

Main parts of the project:

- PracticeEntry model (represents a practice session)
- ApplicationDbContext (handles the database connection)
- PracticeController (gets data and sends it to the views)
- Razor views for the calendar, creating entries, and listing entries

Features:
- add practice entries
- store them in a database
- view all entries
- see a calendar of the current month
- days are marked good / okay / bad

Tech used:
- ASP.NET Core MVC
- C#
- Entity Framework Core
- SQLite

Practice score is based on things like:
- minutes practiced
- warm up
- scales
- intonation
- technical exercises

Rough rules:
- score 5+ = good
- score 3+ = okay
- below that = bad

Author:  
Alex Martinez
