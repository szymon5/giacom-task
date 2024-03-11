using GiacomTask.Controllers;
using GiacomTask.Models;
using GiacomTask.Services;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Newtonsoft.Json;
using System.Text.Json.Nodes;
using System.Text;
using System;
using GiacomTask.DbCommunication.Models;
using System.Net.Http;

namespace GiacomTaskTest
{
    public class CallDetailsControllerTest : IClassFixture<WebApplicationFactory<Program>>
    {
        HttpClient httpClient;

        public CallDetailsControllerTest(WebApplicationFactory<Program> app)
        {
            httpClient = app.CreateClient();
        }

        [Fact]
        public async void GetAllCalls_Test_MustReturnWholeListOfCallDetails()
        {
            var httpResponse = await httpClient.GetAsync("https://localhost:5001/CallDetails/GetAllCalls");
            var response = await httpResponse.Content.ReadAsStringAsync();

            if (!string.IsNullOrEmpty(response))
            {
                var list = JsonConvert.DeserializeObject<List<CallDetail>>(response);
                if(list != null) Assert.NotEmpty(list);
                return;
            }
            
            Assert.Fail("List is empty");
        }

        [Fact]
        public async void GetAverageCallDuration_Test_MustReturnAverageCallDetailDuration()
        {
            var httpResponse = await httpClient.GetAsync("https://localhost:5001/CallDetails/GetAverageCallDuration");
            var response = await httpResponse.Content.ReadAsStringAsync();

            if (!string.IsNullOrEmpty(response))
            {
                var avgDuration = Convert.ToInt64(response);
                Assert.True(avgDuration >= 0);
            }
            else Assert.Fail("Average call duration error");
        }

        [Fact]
        public async void GetMaxCallDuration_Test_MustReturnMaxCallDetailDuration()
        {
            var httpResponse = await httpClient.GetAsync("https://localhost:5001/CallDetails/GetMaxCallDuration");
            var response = await httpResponse.Content.ReadAsStringAsync();

            if (!string.IsNullOrEmpty(response))
            {
                var maxDuration = Convert.ToInt64(response);
                Assert.True(maxDuration >= 0);
            }
            else Assert.Fail("Max call duration error");
        }

        [Fact]
        public async void GetMinCallDuration_Test_MustReturnMinCallDetailDuration()
        {
            var httpResponse = await httpClient.GetAsync("https://localhost:5001/CallDetails/GetMinCallDuration");
            var response = await httpResponse.Content.ReadAsStringAsync();

            if (!string.IsNullOrEmpty(response))
            {
                var minDuration = Convert.ToInt64(response);
                Assert.True(minDuration >= 0);
            }
            else Assert.Fail("Min call duration error");
        }

        [Fact]
        public async void GetCallsFromTimePeriod_Test_MustReturnListOfCallDetail()
        {
            GetCallsFromTimePeriodModel getCallsFromTimePeriodModel = new GetCallsFromTimePeriodModel()
            {
                DateFrom = "2016-08-01",
                DateTo = "2016-08-31"
            };

            var callsFromTimePerion = JsonConvert.SerializeObject(getCallsFromTimePeriodModel);

            var content = new StringContent(callsFromTimePerion,Encoding.UTF8, "application/json");
            var httpResponse = await httpClient.PostAsync("https://localhost:5001/CallDetails/GetCallsFromTimePeriod", content);
            var response = await httpResponse.Content.ReadAsStringAsync();

            if (!string.IsNullOrEmpty(response))
            {
                var list = JsonConvert.DeserializeObject<List<CallDetail>>(response);
                if (list != null) Assert.NotEmpty(list);
                return;
            }
            
            Assert.Fail("List is empty");
        }

        [Fact]
        public async void AddNewCallDetailRecord_Test_MustReturn_NewCallDetailRecordHasBeenAdded()
        {
            AddCallDetailsModel addCallDetailsModel = new AddCallDetailsModel()
            {
                CallerID = "123451234512",
                Recipient = "543215432121",
                CallDate = DateOnly.Parse("2024-11-24"),
                EndTime = TimeOnly.Parse("22:44:00"),
                Duration = 12,
                Cost = "0.123",
                Reference = "ABCDEFGHIJK",
                Currency = "GBP"

            };

            var newCallDetailRecord = JsonConvert.SerializeObject(addCallDetailsModel);

            var content = new StringContent(newCallDetailRecord, Encoding.UTF8, "application/json");
            var httpResponse = await httpClient.PostAsync("https://localhost:5001/CallDetails/AddNewCallDetailRecord", content);
            var response = await httpResponse.Content.ReadAsStringAsync();

            if (!string.IsNullOrEmpty(response))
            {
                Assert.Equal("New call detail record has been added.", response);
                return;
            }

            Assert.Fail("List is empty");
        }

        //callDetailID must be taken from the database every time that test is being executed
        [Fact]
        public async void DeleteCallDetailRecord_Test_MustReturn_CallDetailRecordHasBeenDeleted()
        {
            var callDetailID = "143402";
            var httpResponse = await httpClient.DeleteAsync($"https://localhost:5001/CallDetails/DeleteCallDetailRecord/{callDetailID}");
            var response = await httpResponse.Content.ReadAsStringAsync();

            if (!string.IsNullOrEmpty(response))
            {
                Assert.Equal("Call detail record has been deleted.", response);
                return;
            }

            Assert.Fail("List is empty");
        }

        [Fact]
        public async void DeleteCallDetailRecord_Test_MustReturn_SuchCallDetailDoesNotExist()
        {
            var httpResponse = await httpClient.DeleteAsync("https://localhost:5001/CallDetails/DeleteCallDetailRecord/12345678");
            var response = await httpResponse.Content.ReadAsStringAsync();

            if (!string.IsNullOrEmpty(response))
            {
                Assert.Equal("Such call detail does not exist.", response);
                return;
            }

            Assert.Fail("List is empty");
        }

        [Fact]
        public async void UploadNewCallDetailRecordsFromFile_Test_MustReturn_CallDetailRecordsHaveBeenUploaded()
        {
            var httpResponse = await httpClient.PostAsync("https://localhost:5001/CallDetails/UploadNewCallDetailRecordsFromFile",
                new MultipartFormDataContent
                {
                    { new StreamContent(File.Open(@"C:\Users\szymi\Pulpit\giacom-file\call_detail.csv", FileMode.Open)), "file", "call_detail" }
                });

            var response = await httpResponse.Content.ReadAsStringAsync();

            if (!string.IsNullOrEmpty(response))
            {
                Assert.Equal("Call detail records have been uploaded.", response);
                return;
            }

            Assert.Fail("List is empty");
        }
    }
}