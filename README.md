Giacom - Call Detail Record (CDR) is a Back-end server written in C#.

Covering note:
1. C# is a comfortable technology which allows developer to implement HTTP Server that managing APIs.
2. Giacom server uses also Entity Framework ORM which provides built-in functionalities to manage database migrations/updates.

Assumstions:
1. Server allows user to:
   a) Add a new single call detail record,
   b) Get all call detail records,
   c) Get average, max and min call duration,
   d) Get call detail records from time period,
   e) Remove call detail record,
   f) Upload *.csv file which contains multiple call detail records.

Given more time:
1. Add validations,
2. Create statistics how long does a call last between caller and recipient,
Suggestion (for a further time):
Introduction to AI -> teach an ANN to determine (predict?) which days caller will call recipient and how long that call might take.
