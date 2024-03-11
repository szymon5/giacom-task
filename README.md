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

Currently server has 8 end-points:
1. GetAllCalls:
   link: https://<ip_address>:<port>/CallDetails/GetAllCalls
   body: none
   method: GET
2. link: https://<ip_address>:<port>/CallDetails/GetAverageCallDuration
   body: none
   method: GET
3. link: https://<ip_address>:<port>/CallDetails/GetMaxCallDuration
   body: none
   method: GET
4. link: https://<ip_address>:<port>/CallDetails/GetMinCallDuration
   body: none
   method: GET
5. link: https://<ip_address>:<port>/CallDetails/GetCallsFromTimePeriod
   body (raw -> JSON):
   method: GET
   {
    "DateFrom": "2016-08-01",
    "DateTo": "2016-08-31"
   }
6. link: https://<ip_address>:<port>/CallDetails/AddNewCallDetailRecord
   body (raw -> JSON):
   method: GET
   {
    "CallerID": "123456789012",
    "Recipient": "098765432123",
    "CallDate": "2024-03-10",
    "EndTime": "21:25:00",
    "Duration": 50,
    "Cost": "0.222",
    "Reference": "abcA9724701EEBBA95CA2CC5617BA93E4",
    "Currency": "GBP"
   }
8. link: https://<ip_address>:<port>/CallDetails/DeleteCallDetailRecord/52151
   body: none
   method: DELETE
9. link: https://<ip_address>:<port>/CallDetails/UploadNewCallDetailRecordsFromFile
   body: (form-data):
   method: POST
   Key: file
   Value: <name_of_csv_file>.csv


Given more time:
1. Add validations,
2. Create swagger spec,
2. Create statistics how long does a call last between caller and recipient,
Suggestion (for a further time):
Introduction to AI -> teach an ANN to determine (predict?) which days caller will call recipient and how long that call might take.

Pending:
Tests
