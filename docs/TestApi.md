# IO.Swagger.Api.TestApi

All URIs are relative to *https://localhost:8080*

Method | HTTP request | Description
------------- | ------------- | -------------
[**FinishTest**](TestApi.md#finishtest) | **GET** /test/finish/{testId} | конец теста и получение результата
[**GetAllTests**](TestApi.md#getalltests) | **GET** /test/all | Получить список тестов
[**GetLastResult**](TestApi.md#getlastresult) | **GET** /test/latest/{userUuid} | получение последнего результата
[**GetTestAnswer**](TestApi.md#gettestanswer) | **GET** /test/{testId}/{questionId} | получить вопрос и варианты ответа
[**PostTestAnswer**](TestApi.md#posttestanswer) | **POST** /test/{testId}/{questionId}/{answerId} | отправить ответ
[**StartTest**](TestApi.md#starttest) | **GET** /test/start/{testId} | запуск теста и получение количества вопросов


<a name="finishtest"></a>
# **FinishTest**
> long? FinishTest (long? userUuid, long? testId)

конец теста и получение результата

метод предназначен для завершения теста

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class FinishTestExample
    {
        public void main()
        {
            var apiInstance = new TestApi();
            var userUuid = 789;  // long? | выбранный пользователь
            var testId = 789;  // long? | testId для поиска нужного теста

            try
            {
                // конец теста и получение результата
                long? result = apiInstance.FinishTest(userUuid, testId);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling TestApi.FinishTest: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **userUuid** | **long?**| выбранный пользователь | 
 **testId** | **long?**| testId для поиска нужного теста | 

### Return type

**long?**

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getalltests"></a>
# **GetAllTests**
> List<Test> GetAllTests ()

Получить список тестов

метод предназначен для получения списка тестов

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class GetAllTestsExample
    {
        public void main()
        {
            var apiInstance = new TestApi();

            try
            {
                // Получить список тестов
                List&lt;Test&gt; result = apiInstance.GetAllTests();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling TestApi.GetAllTests: " + e.Message );
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**List<Test>**](Test.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getlastresult"></a>
# **GetLastResult**
> long? GetLastResult (long? userUuid)

получение последнего результата

метод предназначен для получения списка всех операций

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class GetLastResultExample
    {
        public void main()
        {
            var apiInstance = new TestApi();
            var userUuid = 789;  // long? | userUuid для поиска

            try
            {
                // получение последнего результата
                long? result = apiInstance.GetLastResult(userUuid);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling TestApi.GetLastResult: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **userUuid** | **long?**| userUuid для поиска | 

### Return type

**long?**

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="gettestanswer"></a>
# **GetTestAnswer**
> Question GetTestAnswer (long? userUuid, long? testId, long? questionId)

получить вопрос и варианты ответа

метод предназначен для получения вариантов ответа

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class GetTestAnswerExample
    {
        public void main()
        {
            var apiInstance = new TestApi();
            var userUuid = 789;  // long? | выбранный пользователь
            var testId = 789;  // long? | testId для поиска нужного теста
            var questionId = 789;  // long? | questionId для поиска нужного вопроса

            try
            {
                // получить вопрос и варианты ответа
                Question result = apiInstance.GetTestAnswer(userUuid, testId, questionId);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling TestApi.GetTestAnswer: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **userUuid** | **long?**| выбранный пользователь | 
 **testId** | **long?**| testId для поиска нужного теста | 
 **questionId** | **long?**| questionId для поиска нужного вопроса | 

### Return type

[**Question**](Question.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="posttestanswer"></a>
# **PostTestAnswer**
> Answer PostTestAnswer (long? userUuid, long? testId, long? questionId, long? answerId)

отправить ответ

метод предназначен для отправления ответа на вопрос

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class PostTestAnswerExample
    {
        public void main()
        {
            var apiInstance = new TestApi();
            var userUuid = 789;  // long? | выбранный пользователь
            var testId = 789;  // long? | testId для поиска нужного теста
            var questionId = 789;  // long? | questionId для поиска нужного вопроса
            var answerId = 789;  // long? | answerId для поиска нужного вопроса

            try
            {
                // отправить ответ
                Answer result = apiInstance.PostTestAnswer(userUuid, testId, questionId, answerId);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling TestApi.PostTestAnswer: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **userUuid** | **long?**| выбранный пользователь | 
 **testId** | **long?**| testId для поиска нужного теста | 
 **questionId** | **long?**| questionId для поиска нужного вопроса | 
 **answerId** | **long?**| answerId для поиска нужного вопроса | 

### Return type

[**Answer**](Answer.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="starttest"></a>
# **StartTest**
> long? StartTest (long? userUuid, long? testId)

запуск теста и получение количества вопросов

метод предназначен для запуска теста и получения количества вопросов

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class StartTestExample
    {
        public void main()
        {
            var apiInstance = new TestApi();
            var userUuid = 789;  // long? | выбранный пользователь
            var testId = 789;  // long? | testId для поиска

            try
            {
                // запуск теста и получение количества вопросов
                long? result = apiInstance.StartTest(userUuid, testId);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling TestApi.StartTest: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **userUuid** | **long?**| выбранный пользователь | 
 **testId** | **long?**| testId для поиска | 

### Return type

**long?**

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

